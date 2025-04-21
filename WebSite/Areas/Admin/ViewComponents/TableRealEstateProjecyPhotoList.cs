using Microsoft.AspNetCore.Mvc;
using WebSite.DataLayer.Entities.RealEstate;

namespace WebSite.Areas.Admin.ViewComponents
{
    public class TableRealEstateProjectPhotoList : ViewComponent
    {        
        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<RealEstateProjectPhoto> list)
        {
            return await Task.FromResult((IViewComponentResult)View("TableRealEstateProjectPhotoList", list));
        }
    }
}
