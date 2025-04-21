using WebSite.Core.Services;
using WebSite.Core.Utility;
using WebSite.DataLayer.Entities.User;
using Microsoft.AspNetCore.Mvc;
using WebSite.Core.ViewModel.Account;
using WebSite.Core.ViewModel.User;

namespace WebSite.Areas.Admin.Controllers
{
    public class UserAdminAreaController : BaseController
    {
        private readonly IGenericRepository<Users> _userRepository;
        private readonly IGenericRepository<UserJoinRole> _userJoinRoleRepository;
        private readonly IUserService _userService;
        private readonly IUploadService _uploadService;


        public UserAdminAreaController(IGenericRepository<Users> userRepository, IGenericRepository<UserJoinRole> userJoinRoleRepository, IUserService userService, IUploadService uploadService)
        {
            _userRepository = userRepository;
            _userJoinRoleRepository = userJoinRoleRepository;
            _userService = userService;
            _uploadService = uploadService;
        }

        [HttpGet("admin/user/list")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var userList = await _userService.GetAllUserList(page);

            return View(userList);
        }

        //user profile
        [HttpGet("admin/user/profile/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            //find user
            var user = await _userRepository.GetById(id);

            return View(user);
        }

        //add new user
        [HttpGet("admin/user/new")]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost("admin/user/new"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddNewUserByAdminViewModel viewmodel, IFormFile? uploadPhoto)
        {

            //check model validation
            if (!ModelState.IsValid)
            {
                TempData["AlertMessage"] = AlertResource.FailRequestAlert;
                TempData["AlertType"] = "alert-warning";

                return View(viewmodel);
            }

			//mobile duplicate check
			var userList = await _userRepository.Get(
				m => m.Mobile == viewmodel.Mobile);
			if (userList.Any())
			{
				TempData["AlertMessage"] = AlertResource.ExistMobileAlert;
				TempData["AlertType"] = "alert-warning";
				return View(viewmodel);
			}

			//new user
			Users user = new Users()
            {
                Mobile = viewmodel.Mobile,
                FirstName = viewmodel.FirstName,
                LastName = viewmodel.LastName,
                Email = viewmodel.Email,
                Password = PasswordHelper.EncodePasswordMd5(viewmodel.Mobile!),
            };

            //upload photo 
            if (uploadPhoto != null)
            {
                if (!MyFile.IsImage(uploadPhoto))
                {
                    TempData["AlertMessage"] = AlertResource.NotValidPhotoFormatAlert;
                    TempData["AlertType"] = "alert-warning";

                    return View(viewmodel);
                }
                user.Photo = _uploadService.UploadPhoto(uploadPhoto, "wwwroot/upload/user");
            }

            //save user
            await _userRepository.Add(user);

            //user role 
            UserJoinRole userRole = new UserJoinRole()
            {
                RoleRefId = 3,
                UserRefId = user.Id
            };
            await _userJoinRoleRepository.Add(userRole);

            TempData["AlertMessage"] = AlertResource.SuccessRequestAlert;
            TempData["AlertType"] = "alert-success";

            return RedirectToAction("Details",new{id = user.Id});
        }


        //update user
        [Route("admin/user/update/{id}")]
        public async Task<IActionResult> Edit(int id) // id = user id
        {
            //user
            var user = await _userRepository.GetById(id);

            UpdateUserProfileByAdminViewModel viewmodel = new UpdateUserProfileByAdminViewModel()
            {
                UserRefId = user.Id,
                Mobile = user.Mobile,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };

            return View(viewmodel);
        }


        [HttpPost("admin/user/update/{id}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateUserProfileByAdminViewModel viewmodel, IFormFile? uploadPhoto)
        {
            //check model validation
            if (!ModelState.IsValid)
            {
                TempData["AlertMessage"] = AlertResource.FailRequestAlert;
                TempData["AlertType"] = "alert-warning";
                return View(viewmodel);
            }

            //mobile duplicate check
            var userList = await _userRepository.Get(
	            m => m.Mobile == viewmodel.Mobile);
            if (userList.Count() > 1)
            {
	            TempData["AlertMessage"] = AlertResource.ExistMobileAlert;
	            TempData["AlertType"] = "alert-warning";
	            return View(viewmodel);
			}

            //user
            var user = await _userRepository.GetById(viewmodel.UserRefId);

            //update user
            user.FirstName = viewmodel.FirstName;
            user.LastName = viewmodel.LastName;
            user.Email = viewmodel.Email;
            user.Mobile = viewmodel.Mobile;

            //upload photo 
            if (uploadPhoto != null)
            {
                if (!MyFile.IsImage(uploadPhoto))
                {
                    TempData["AlertMessage"] = AlertResource.NotValidPhotoFormatAlert;
                    TempData["AlertType"] = "alert-warning";

                    return View(viewmodel);
                }

                //delete old photo
                if (viewmodel.Photo != "default.jpg")
                {
                    _uploadService.RemovePhoto(viewmodel.Photo!, "wwwroot/upload/user");
                }

                viewmodel.Photo = _uploadService.UploadPhoto(uploadPhoto, "wwwroot/upload/user");
            }

            //save user
            await _userRepository.Update(user);

            TempData["AlertMessage"] = AlertResource.SuccessRequestAlert;
            TempData["AlertType"] = "alert-success";

            return RedirectToAction("Details", new { id = viewmodel.UserRefId });

        }


        //reset password
        [Route("admin/user/password/reset/{id}")]
        public async Task<ActionResult> ResetPassword(int id) //id = user id
        {
            //find user 
            var user = await _userRepository.GetById(id);

            ResetPasswordViewModel viewmodel = new ResetPasswordViewModel()
            {
                UserRefId = user.Id,
                User = user,
            };

            return View(viewmodel);
        }


        [HttpPost("admin/user/password/reset/{id}"), ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel viewmodel)
        {
            //find user
            var user = await _userRepository.GetById(viewmodel.UserRefId!.Value);
            viewmodel.User = user;

            //check model validation
            if (!ModelState.IsValid)
            {
                TempData["AlertMessage"] = AlertResource.FailRequestAlert;
                TempData["AlertType"] = "alert-warning";

                return View(viewmodel);
            }

            //new password
            string newPassword = PasswordHelper.EncodePasswordMd5(viewmodel.NewPassword!);
            user.Password = newPassword;

            //save user
            await _userRepository.Update(user);

            TempData["AlertMessage"] = AlertResource.SuccessRequestAlert;
            TempData["AlertType"] = "alert-warning";

            return RedirectToAction("Details", "UserAdminArea", new { id = user.Id });
        }

        //search
        [HttpGet("admin/user/search")]
        public IActionResult Search()
        {
            SearchUserViewModel viewmodel = new SearchUserViewModel();

            return View(viewmodel);
        }

        [HttpPost("admin/user/search"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Search(SearchUserViewModel viewmodel)
        {
            //check search type 
            if (viewmodel.UserSearchTypeId == null || viewmodel.UserSearchTypeId == -1)
            {
                TempData["AlertMessage"] = AlertResource.FailRequestAlert;
                TempData["AlertType"] = "alert-warning";
                return View(viewmodel);
            }
            

            //check search text 
            if (viewmodel.SearchText == null)
            {
                TempData["AlertMessage"] = AlertResource.FailRequestAlert;
                TempData["AlertType"] = "alert-warning";
                return View(viewmodel);
            }
            


            if (viewmodel.UserSearchTypeId == 1)
            {
                var userList = await _userRepository.Get(
                    e => e.Mobile!.Contains(viewmodel.SearchText));
                viewmodel.UserList = userList.ToList();

                return View(viewmodel);
            }

            if (viewmodel.UserSearchTypeId == 2)
            {
                var userList = await _userRepository.Get(
                    e => e.Email!.Contains(viewmodel.SearchText));
                viewmodel.UserList = userList.ToList();

                return View(viewmodel);
            }

            if (viewmodel.UserSearchTypeId == 3)
            {
                var userList = await _userRepository.Get(
                    e => e.FirstName!.Contains(viewmodel.SearchText) ||
                         e.LastName!.Contains(viewmodel.SearchText) ||
                         (e.FirstName + " " + e.LastName).Contains(viewmodel.SearchText)
                    );
                viewmodel.UserList = userList.ToList();

                return View(viewmodel);
            }
            return View(viewmodel);
        }

        //active user
        [Route("admin/user/active/{id}")]
        public async Task<IActionResult> ActiveUser(int id) // id = user id
        {
            //user 
            var user = await _userRepository.GetById(id);

            //update user active status
            user.IsActive = true;

            //save user
            await _userRepository.Update(user);

            TempData["AlertMessage"] = AlertResource.SuccessRequestAlert;
            TempData["AlertType"] = "alert-success";

            return RedirectToAction("Details", new { id = user.Id });
        }

        //de active user
        [Route("admin/user/deactive/{id}")]
        public async Task<IActionResult> DeActiveUser(int id) // id = user id
        {
            //user 
            var user = await _userRepository.GetById(id);

            //update user active status
            user.IsActive = false;

            //save user
            await _userRepository.Update(user);

            TempData["AlertMessage"] = AlertResource.SuccessRequestAlert;
            TempData["AlertType"] = "alert-success";

            return RedirectToAction("Details", new { id = user.Id });
        }

        //remove user
        [Route("admin/user/remove/{id}")]
        public async Task<IActionResult> DeleteUser(int id) // id = user id
        {
            //user 
            var user = await _userRepository.GetById(id);
            
            //save user
            await _userRepository.Delete(user.Id);

            TempData["AlertMessage"] = AlertResource.SuccessRequestAlert;
            TempData["AlertType"] = "alert-success";

            return RedirectToAction("Details", new { id = user.Id });
        }
    }
}
