using WebSite.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.ViewComponents
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

	        var testimonialList = await _testimonialService.GetTestimonialLatestList(10,1);

            return await Task.FromResult((IViewComponentResult)View("TestimonialLatestListSlider12Col", testimonialList));
        }
    }
}
