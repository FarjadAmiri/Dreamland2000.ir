using WebSite.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Areas.English.ViewComponents
{
    public class TestimonialLatestListSlider12Col : ViewComponent
    {

        private readonly ITestimonialService _testimonialService;

        public TestimonialLatestListSlider12Col(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

	        var testimonialList = await _testimonialService.GetTestimonialLatestList(10,2);

            return await Task.FromResult((IViewComponentResult)View("TestimonialLatestListSlider12Col", testimonialList));
        }
    }
}
