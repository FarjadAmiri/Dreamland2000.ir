using WebSite.Core.ViewModel.Testimonial;
using WebSite.DataLayer.Entities.Testimonial;

namespace WebSite.Core.Services
{

    public interface ITestimonialService
    {
        Task<TestimonialListViewModel> GetTestimonialList(int page = 1,int countPerPage = 100,int language=-1);
        Task<IEnumerable<Testimonial>> GetTestimonialLatestList(int take = 100, int language = -1);
    }


    public class TestimonialService : ITestimonialService
    {
        private readonly IGenericRepository<Testimonial> _testimonialRepository;

        public TestimonialService(IGenericRepository<Testimonial> testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }


        public async Task<TestimonialListViewModel> GetTestimonialList(int page = 1,int countPerPage = 100, int language = -1)
        {
            var testimonialList = await _testimonialRepository.Get(
                orderBy: q => q.OrderByDescending(d => d.LastUpdate));

            

            //language filter
            if (language != -1)
            {
                testimonialList = testimonialList.Where(l => l.LanguageRefId == language);
            }

            testimonialList = testimonialList.ToList();

            int take = countPerPage;
            int skip = (page - 1) * take;
            TestimonialListViewModel viewModel = new TestimonialListViewModel()
            {
                TestimonialList = testimonialList.Skip(skip).Take(take).ToList(),
                CurrentPage = page,
                PageCount = testimonialList.Count() / take,
                TotalCount = testimonialList.Count(),
            };

            
            return viewModel;
        }

        public async Task<IEnumerable<Testimonial>> GetTestimonialLatestList(int take = 100, int language = -1)
        {
            var testimonialList = await _testimonialRepository.Get(
                orderBy: q => q.OrderByDescending(d => d.LastUpdate));

            //language filter
            if (language != -1)
            {
                testimonialList = testimonialList.Where(l => l.LanguageRefId == language);
            }

            return testimonialList.Take(take);

        }
      
    }
}
