using WebSite.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Areas.English.ViewComponents
{
    public class Fact12Col : ViewComponent
    {
        private readonly IFactService _factService;

        public Fact12Col(IFactService factService)
        {
            _factService = factService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var factList = await _factService.GetFactList(2);
                
            return await Task.FromResult((IViewComponentResult)View("Fact12Col", factList));
        }
    }
}
