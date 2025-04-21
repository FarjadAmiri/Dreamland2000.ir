using System.Linq;
using WebSite.DataLayer.Entities.User;

namespace WebSite.Core.Services
{
    public interface IPermissionService
    {
        bool CheckPermission(int permissionId, string userName);
    }
    public class PermissionService : IPermissionService
    {
        private readonly IGenericRepository<Users> _userRepository;
        private readonly IUserService _userService;
        private readonly IGenericRepository<UserJoinRole> _userJoinRoleRepository;
        private readonly IGenericRepository<PermissionJoinRole> _permissionJoinRoleRepository;

        public PermissionService(IGenericRepository<Users> userRepository, IGenericRepository<UserJoinRole> userJoinRoleRepository, IGenericRepository<PermissionJoinRole> pJrRepository, IUserService userService)
        {
            _userRepository = userRepository;
            _userJoinRoleRepository = userJoinRoleRepository;
            _permissionJoinRoleRepository = pJrRepository;
            _userService = userService;
        }

        public bool CheckPermission(int permissionId, string userName)
        {
            var userList = _userRepository.Get(
                m=>m.Mobile==userName).Result.ToList();
            var user = userList.FirstOrDefault();

            var objUserRoleList = _userJoinRoleRepository.Get(
                u => u.UserRefId == user.Id).Result.ToList();

            if (!objUserRoleList.Any())
                return false;

            var permissionRoleList = _permissionJoinRoleRepository.Get(
                p => p.PermissionRefId == permissionId).Result.ToList();

            foreach (var item in permissionRoleList)
            {
                if (objUserRoleList.Any(r => r.RoleRefId == item.RoleRefId))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
