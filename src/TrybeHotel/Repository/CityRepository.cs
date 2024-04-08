using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class CityRepository : ICityRepository
    {
        protected readonly ITrybeHotelContext _context;
        public CityRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        public IEnumerable<CityDto> GetCities()
        {
            try
            {
                var res = _context.Cities.Select(c => new CityDto()
                {
                    CityId = c.CityId,
                    name = c.Name
                }).ToList();
                return res;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public CityDto AddCity(City city)
        {
            try
            {
                _context.Cities.Add(city);
                _context.SaveChanges();
                var nCity = _context.Cities.First(c => c.CityId == city.CityId);
                var res = new CityDto()
                {
                    CityId = nCity.CityId,
                    name = nCity.Name
                };
                return res;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

    }
}