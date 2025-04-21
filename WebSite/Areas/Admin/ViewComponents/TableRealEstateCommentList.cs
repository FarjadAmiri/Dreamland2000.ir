using Microsoft.AspNetCore.Mvc;
using WebSite.DataLayer.Entities.RealEstate;

namespace WebSite.Areas.Admin.ViewComponents
{
    public class TableRealEstateCommentList : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<RealEstateComment> list)
        {
            return await Task.FromResult((IViewComponentResult)View("TableRealEstateCommentList", list));
        }


    }
}
