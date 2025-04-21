namespace WebSite.Core.ViewModel.RealEstate
{
    public class RealEstateListViewModel
    {
        public List<DataLayer.Entities.RealEstate.RealEstate>? RealEstateList { get; set; }

        public string? SearchText { get; set; }

        public int CurrentPage { get; set; }

        public int PageCount { get; set; }

        public int TotalCount { get; set; }
    }
}
