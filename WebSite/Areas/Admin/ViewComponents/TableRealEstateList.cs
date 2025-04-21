using Microsoft.AspNetCore.Mvc;
using WebSite.DataLayer.Entities.RealEstate;

namespace WebSite.Areas.Admin.ViewComponents
{
    public class TableRealEstateList : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<RealEstate> list)
        {
            return await Task.FromResult((IViewComponentResult)View("TableRealEstateList", list));
        }


    }
}
