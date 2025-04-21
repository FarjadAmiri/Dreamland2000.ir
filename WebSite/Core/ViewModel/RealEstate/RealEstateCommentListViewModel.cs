using WebSite.DataLayer.Entities.RealEstate;

namespace WebSite.Core.ViewModel.RealEstate
{
    public class RealEstateCommentListViewModel
    {
        public List<RealEstateComment>? CommentList { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int TotalCount { get; set; }
    }
}
