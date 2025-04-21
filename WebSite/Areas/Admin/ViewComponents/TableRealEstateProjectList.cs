using Microsoft.AspNetCore.Mvc;
using WebSite.DataLayer.Entities.RealEstate;

namespace WebSite.Areas.Admin.ViewComponents
{
    public class TableRealEstateProjectList : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<RealEstateProject> list)
        {
            return await Task.FromResult((IViewComponentResult)View("TableRealEstateProjectList", list));
        }


    }
}
