using WebSite.DataLayer.Entities.Address;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebSite.Core.Services
{
    public interface IAddressService
    {
        Task<List<SelectListItem>> GetCityListAsSelectListItem();
        Task<IEnumerable<City>> GetCityList(int language = -1);
    }

    public class AddressService : IAddressService
    {
        private readonly IGenericRepository<City> _cityRepository;

        public AddressService(IGenericRepository<City> cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<List<SelectListItem>> GetCityListAsSelectListItem()
        {
            var cityList = await _cityRepository.Get(
                orderBy: q => q.OrderBy(s => s.Sort));

            return cityList.Select(g => new SelectListItem()
            {
                Text = g.Title,
                Value = g.Id.ToString()
            }).ToList();
        }

        public async Task<IEnumerable<City>> GetCityList(int language = -1)
        {
            var cityList = await _cityRepository.Get(
                orderBy: q => q.OrderBy(s => s.Sort));


            //language filter
            if (language != -1)
            {
                cityList = cityList.Where(l => l.LanguageRefId == language);
            }

            cityList = cityList.ToList();
            return cityList;
        }

      

    }
}
