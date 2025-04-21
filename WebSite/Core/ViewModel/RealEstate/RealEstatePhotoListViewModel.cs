namespace WebSite.Core.ViewModel.RealEstate
{
    public class RealEstatePhotoListViewModel
    {
        public List<DataLayer.Entities.RealEstate.RealEstatePhoto>? PhotoList { get; set; }

        public string? SearchText { get; set; }

        public int CurrentPage { get; set; }

        public int PageCount { get; set; }

        public int TotalCount { get; set; }
    }
}
