using WebSite.Core.Services;
using WebSite.Core.Utility;
using WebSite.DataLayer.Entities.User;
using Microsoft.AspNetCore.Mvc;
using WebSite.Core.ViewModel.User;

namespace WebSite.Areas.User.Controllers
{
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public class ProfileUserAreaController : BaseController
    {
        private readonly IGenericRepository<Users> _userRepository;
        private readonly IUserService _userService;


        public ProfileUserAreaController(IGenericRepository<Users> userRepository, IUserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        [Route("user/profile")]
        public async Task<IActionResult> Profile()
        {
            //current user 
            var userName = User.Identity!.Name;
            var user = await _userService.GetCurrentUserByUserName(userName!);

          

            return View(user);
        }

        //change password 
        [HttpGet("user/profile/password/change")]
        public async Task<ActionResult> ChangePassword()
        {
            //current user 
            var userName = User.Identity!.Name;
            var user = await _userService.GetCurrentUserByUserName(userName!);


            ChangePasswordByUserViewModel viewmodel = new ChangePasswordByUserViewModel
            {
                UserRefId = user.Id,
            };

            return View(viewmodel);
        }

        [HttpPost("user/profile/password/change"), ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordByUserViewModel viewmodel)
        {
            //check model validation
            if (!ModelState.IsValid)
            {
                TempData["AlertMessage"] = AlertResource.FailRequestAlert;
                TempData["AlertType"] = "alert-warning";

                return View(viewmodel);
            }

            //find user
            var user = await _userRepository.GetById(viewmodel.UserRefId);

            //check old password
            string oldPassword = PasswordHelper.EncodePasswordMd5(viewmodel.OldPassword!);
            if (oldPassword != user.Password)
            {
                TempData["AlertMessage"] = AlertResource.OldPasswordIncorrectAlert;
                TempData["AlertType"] = "alert-warning";

                return View(viewmodel);
            }

            //new password
            string newPassword = PasswordHelper.EncodePasswordMd5(viewmodel.NewPassword!);
            user.Password = newPassword;

            //save user
            await _userRepository.Update(user);

            TempData["AlertMessage"] = AlertResource.SuccessRequestAlert;
            TempData["AlertType"] = "alert-success";

            return RedirectToAction("Index", "Home");
        }
    }
}