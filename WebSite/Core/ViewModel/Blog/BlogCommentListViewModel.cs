using WebSite.DataLayer.Entities.Blog;

namespace WebSite.Core.ViewModel.Blog
{
    public class BlogCommentListViewModel
    {
        public List<BlogComment>? CommentList { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int TotalCount { get; set; }
    }
}
