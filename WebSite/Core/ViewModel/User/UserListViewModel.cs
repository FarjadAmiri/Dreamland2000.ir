using WebSite.DataLayer.Entities.User;

namespace WebSite.Core.ViewModel.User
{
    public class UserListViewModel
    {
        public List<Users>? UserList { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }
}
