using Language = WebSite.DataLayer.Entities.Language.Language;

namespace WebSite.Core.Services
{
    public interface ILanguageService
    {
        Task<IEnumerable<Language>> GetLanguageList();
    }

    public class LanguageService : ILanguageService
    {
        private readonly IGenericRepository<Language> _languageRepository;

        public LanguageService(IGenericRepository<Language> languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task<IEnumerable<Language>> GetLanguageList()
        {
            var languageList = await _languageRepository.Get(
                orderBy: q => q.OrderBy(d => d.Sort));

            return languageList;
        }
    }
}
