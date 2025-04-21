using Microsoft.AspNetCore.Mvc;
using WebSite.DataLayer.Entities.RealEstate;

namespace WebSite.Areas.Admin.ViewComponents
{
    public class TableRealEstatePhotoList : ViewComponent
    {        
        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<RealEstatePhoto> list)
        {
            return await Task.FromResult((IViewComponentResult)View("TableRealEstatePhotoList", list));
        }
    }
}
