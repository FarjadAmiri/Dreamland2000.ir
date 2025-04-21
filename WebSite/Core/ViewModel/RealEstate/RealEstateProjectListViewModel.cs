namespace WebSite.Core.ViewModel.RealEstate
{
    public class RealEstateProjectListViewModel
    {
        public List<DataLayer.Entities.RealEstate.RealEstateProject>? ProjectList { get; set; }

        public string? SearchText { get; set; }

        public int CurrentPage { get; set; }

        public int PageCount { get; set; }

        public int TotalCount { get; set; }
    }
}
