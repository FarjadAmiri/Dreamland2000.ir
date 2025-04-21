using Microsoft.AspNetCore.Mvc;
using WebSite.DataLayer.Entities.RealEstate;

namespace WebSite.Areas.Admin.ViewComponents
{
    public class TableRealEstateOptionList : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<RealEstateJoinOption> list)
        {
            return await Task.FromResult((IViewComponentResult)View("TableRealEstateOptionList", list));
        }


    }
}
