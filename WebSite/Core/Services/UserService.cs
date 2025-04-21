using WebSite.Core.Utility;
using WebSite.Core.ViewModel.User;
using WebSite.DataLayer.Entities.User;



namespace WebSite.Core.Services
{
    public interface IUserService
    {

        Task<UserListViewModel> GetAllUserList(int page = 1,string search="");
        Task<IEnumerable<Users>> GetUserList();


        Task<Users> GetCurrentUserByUserName(string userName);

        Task<Users> GetUserByMobile(string id);

        Task<Users> GetUserByEmail(string id);

        Task<Users> GetUserById(int id);

        Task<bool> MobileExist(string id);

        Task<bool> EmailExist(string id);
        
        Task<bool> UserIsSuperAdmin(int id); // id  user id

        Task<bool> UserIsAdmin(int id); // id  user id

        UserListViewModel GetUsers(int page = 1, string filter = "");

        List<int> GetUserRolesIdList(int id);

        Task<string> GetUserSerialNumberByUserId(int id);

        Task UpdateUserLastActivityDateAsync(int id);

        Task<List<Role>> FindUserRolesAsync(int id);

        Task<bool> IsUserInRole(int userId, int roleId);

        Task<List<Users>> FindUsersInRoleAsync(int id);


       

      

      

    }


    public class UserService : IUserService
    {
        private readonly IGenericRepository<Users> _userRepository;
        private readonly IGenericRepository<UserJoinRole> _userJoinRoleRepository;
        private readonly IUnitOfWork _unitOfWork;


        public UserService(IGenericRepository<Users> userRepository, IGenericRepository<UserJoinRole> userJoinRoleRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _userJoinRoleRepository = userJoinRoleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserListViewModel> GetAllUserList(int page = 1, string search = "")
        {
            var userList = await _userRepository.Get(
                orderBy: q => q.OrderByDescending(d => d.RegisterDate));

           
            if (search != "")
            {
                userList = userList.Where(i => (i.FirstName != null && i.LastName!= null) && (i.FirstName.Contains(search) || i.LastName!.Contains(search)));
            }

            userList = userList.ToList();
            int take = 100;
            int skip = (page-1 ) * take;
            UserListViewModel viewModel = new UserListViewModel()
            {
                UserList = userList.Skip(skip).Take(take).ToList(),
                CurrentPage = page,
                PageCount = userList.Count() / take
            };

            return viewModel;
        }

        public async Task<IEnumerable<Users>> GetUserList()
        {
            var userList = await _userRepository.Get(
                orderBy: q => q.OrderByDescending(d => d.RegisterDate));

            return userList;
        }

        public async Task<Users> GetCurrentUserByUserName(string userName)
        {
            var user = await GetUserByMobile(userName);
            return user;
        }
        
        public async Task<Users> GetUserByMobile(string id) // id = mobile
        {
            var objUserList = await _userRepository.Get(
                m => m.Mobile == id);

            return objUserList.FirstOrDefault();
        }

        public async Task<Users> GetUserById(int id) // id= user id
        {
            var objUserList = await _userRepository.Get(
                m => m.Id == id);

            return objUserList.FirstOrDefault();
        }

        public async Task<Users> GetUserByEmail(string id) // id = email
        {
            var objUserList = await _userRepository.Get(
                m => m.Email == id);

            return objUserList.FirstOrDefault();
        }

        public List<int> GetUserRolesIdList(int id) // id = user id
        {
            return _userJoinRoleRepository.Get().Result.Select(r => r.RoleRefId).ToList();
        }

        public async Task<bool> MobileExist(string id) // id = mobile
        {
            var obj = await _userRepository.Get
                (m => m.Mobile == id);

            return obj.Any();
        } 
        
        public async Task<bool> UserIsSuperAdmin(int id) // id = user id
        {
            var objUserRoleList = await _userJoinRoleRepository.Get(
                u => u.UserRefId == id);

            if (objUserRoleList.Any(r => r.RoleRefId == 1))
            {
                return true;
            }
            //----------------------------------------------------------
            return false;
        }

        public async Task<bool> UserIsAdmin(int id) // id = user id
        {
            var objUserRoleList = await _userJoinRoleRepository.Get(
                u => u.UserRefId == id);

            if (objUserRoleList.Any(r => r.RoleRefId == 2))
            {
                return true;
            }
            //----------------------------------------------------------
            return false;
        }

        public async Task<bool> EmailExist(string id) // id = email
        {
            var obj = await _userRepository.Get(
                m => m.Email == id);

            return obj.Any();
        }
        
        public UserListViewModel GetUsers(int page = 1, string filter = "")
        {
            var result = _unitOfWork.Context.Users;
            // Show Item In Page
            int take = 20;
            int skip = (page - 1) * take;

            UserListViewModel list = new UserListViewModel();
            list.CurrentPage = page;
            list.PageCount = result.Count() / take;
            list.UserList = result.Skip(skip).Take(take).ToList();

            return list;
        }

        public async Task<string> GetUserSerialNumberByUserId(int id) // id = user id
        {
            var objUser = await _userRepository.GetById(id);
            return objUser.SerialNumber;
        }

        public async Task UpdateUserLastActivityDateAsync(int id) // id = user id
        {
            var objUser = await _userRepository.GetById(id);
            if (objUser.LastLoggedIn != null)
            {
                var updateLastActivityDate = TimeSpan.FromMinutes(2);
                var currentUtc = DateTimeOffset.UtcNow;
                var timeElapsed = currentUtc.Subtract(objUser.LastLoggedIn.Value);
                if (timeElapsed < updateLastActivityDate)
                {
                    return;
                }
            }
            objUser.LastLoggedIn = DateTimeOffset.UtcNow;
            await _userRepository.Update(objUser);
        }

        public async Task<List<Role>> FindUserRolesAsync(int id) // id = user id
        {
            var objUserRoleList = await _userJoinRoleRepository.Get(
                u => u.UserRefId == id,
                includes: "Role,User");
            var objRoleList = objUserRoleList.Select(r => r.Role);

            return objRoleList.ToList();
        }

        public async Task<bool> IsUserInRole(int userId, int roleId)
        {
            var objUserRoleList = await _userJoinRoleRepository.Get(
                u => u.UserRefId == userId);
            if (objUserRoleList.Any(r => r.RoleRefId == roleId))
            {
                return true;
            }
            return false;
        }

        public async Task<List<Users>> FindUsersInRoleAsync(int id) // id = role id
        {
            var objUserJoinRoleList = await _userJoinRoleRepository.Get(
                u => u.RoleRefId == id,
                includes: "User");

            var objUserList = objUserJoinRoleList.Select(u => u.User);
            return objUserList.ToList();
        }

     
    }
}
