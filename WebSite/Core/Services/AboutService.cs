using WebSite.DataLayer.Entities.About;

namespace WebSite.Core.Services
{
    public interface IAboutService
    {
        Task<IEnumerable<About>> GetAboutList();

        Task<About> GetAbout(int language);
        
    }

    public class AboutService : IAboutService
    {
        private readonly IGenericRepository<About> _aboutRepository;

        public AboutService(IGenericRepository<About> aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        public async Task<IEnumerable<About>> GetAboutList()
        {
            var aboutList = await _aboutRepository.Get();

            return aboutList;
        }

        public async Task<About> GetAbout(int language)
        {
            var aboutList = await _aboutRepository.Get(
                l => l.LanguageRefId == language);

            return aboutList.First();
        }


    }
}
