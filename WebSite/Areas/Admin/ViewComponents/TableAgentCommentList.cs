using Microsoft.AspNetCore.Mvc;
using WebSite.DataLayer.Entities.Agent;

namespace WebSite.Areas.Admin.ViewComponents
{
    public class TableAgentCommentList : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<AgentComment> list)
        {
            return await Task.FromResult((IViewComponentResult)View("TableAgentCommentList", list));
        }


    }
}
