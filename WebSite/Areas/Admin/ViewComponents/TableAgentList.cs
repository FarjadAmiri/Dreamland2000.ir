using Microsoft.AspNetCore.Mvc;
using WebSite.DataLayer.Entities.Agent;
namespace WebSite.Areas.Admin.ViewComponents
{
    public class TableAgentList : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<Agent> list)
        {
            return await Task.FromResult((IViewComponentResult)View("TableAgentList", list));
        }


    }
}
