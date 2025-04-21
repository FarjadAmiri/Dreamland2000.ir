using System.Linq;
using System.Threading.Tasks;
using WebSite.Core.Services;
using WebSite.DataLayer.Entities.Faq;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Areas.English.ViewComponents
{
    public class FaqLatestList12Col : ViewComponent
    {
        private IGenericRepository<Faq> _faqRepository;

        public FaqLatestList12Col(IGenericRepository<Faq> faqRepository)
        {
            _faqRepository = faqRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var faqList = await _faqRepository.Get(
                orderBy: q => q.OrderBy(s => s.Sort));

            return await Task.FromResult((IViewComponentResult)View("FaqLatestList12Col", faqList.Take(6)));
        }
    }
}
