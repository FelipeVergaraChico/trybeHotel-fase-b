using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class HotelRepository : IHotelRepository
    {
        protected readonly ITrybeHotelContext _context;
        public HotelRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        public IEnumerable<HotelDto> GetHotels()
        {
            throw new NotImplementedException();
        }
        
        public HotelDto AddHotel(Hotel hotel)
        {
            try
            {
                _context.Hotels.Add(hotel);
                _context.SaveChanges();
                var city = _context.Cities.First(c => c.CityId == hotel.CityId);
                if (city != null)
                {
                    return new HotelDto()
                    {
                        hotelId = hotel.HotelId,
                        name = hotel.Name,
                        address = hotel.Address,
                        cityId = hotel.CityId,
                        cityName = city.Name
                    };
                }
                else
                {
                    throw new Exception("City Not Found");
                }
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }
    }
}