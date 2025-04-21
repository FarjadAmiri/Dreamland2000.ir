namespace WebSite.Core.ViewModel.Blog
{
    public class BlogListViewModel
    {
        public List<DataLayer.Entities.Blog.Blog>? BlogList { get; set; }

        public string? SearchText { get; set; }

        public int CurrentPage { get; set; }

        public int PageCount { get; set; }

        public int TotalCount { get; set; }
    }
}
