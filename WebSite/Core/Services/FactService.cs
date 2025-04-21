using WebSite.DataLayer.Entities.Fact;

namespace WebSite.Core.Services
{
    public interface IFactService
    {
        Task<IEnumerable<Fact>> GetFactList(int language=-1);

        
    }


    public class FactService : IFactService
    {
        private readonly IGenericRepository<Fact> _factRepository;

        public FactService(IGenericRepository<Fact> factRepository)
        {
            _factRepository = factRepository;
        }

        public async Task<IEnumerable<Fact>> GetFactList(int language = -1)
        {
            var factList = await _factRepository.Get(
                orderBy:q=>q.OrderBy(s=>s.Sort));

            if (language != -1)
            {
                factList = factList.Where(l => l.LanguageRefId == language);
            }

            return factList;
        }

    }
}
