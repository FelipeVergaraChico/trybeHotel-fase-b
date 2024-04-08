using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class RoomRepository : IRoomRepository
    {
        protected readonly ITrybeHotelContext _context;
        public RoomRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        public IEnumerable<RoomDto> GetRooms(int HotelId) {
            throw new NotImplementedException();
        }

        public RoomDto AddRoom(Room room) {
            try
            {
                var r = _context.Rooms.Add(room);
                _context.SaveChanges();
                var newHotel = _context.Hotels.Find(room.HotelId);
                var newCity = _context.Cities.FirstOrDefault(c => c.CityId == newHotel.CityId);
                return new RoomDto {
                    roomId = r.Entity.RoomId,
                    name = r.Entity.Name,
                    image = r.Entity.Image,
                    capacity = r.Entity.Capacity,
                    hotel = new HotelDto {
                        hotelId = newHotel.HotelId,
                        name = newHotel.Name,
                        address = newHotel.Address,
                        cityId = newHotel.CityId,
                        cityName = newCity.Name
                    }
                };
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public void DeleteRoom(int RoomId) {
            try
            {
                var r = _context.Rooms.Find(RoomId);
                _context.Rooms.Remove(r);
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }
    }
}