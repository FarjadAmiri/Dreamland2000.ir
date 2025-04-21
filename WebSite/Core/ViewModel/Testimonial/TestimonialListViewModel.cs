namespace WebSite.Core.ViewModel.Testimonial
{
    public class TestimonialListViewModel
    {
        public List<DataLayer.Entities.Testimonial.Testimonial>? TestimonialList { get; set; }

        public string? SearchText { get; set; }

        public int CurrentPage { get; set; }

        public int PageCount { get; set; }

        public int TotalCount { get; set; }
    }
}
