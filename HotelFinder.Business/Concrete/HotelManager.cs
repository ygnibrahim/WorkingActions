using HotelFinder.Business.Abstract;
using HotelFinder.DataAccess.Abstract;
using HotelFinderEntities;

namespace HotelFinder.Business.Concrete
{
    public class HotelManager : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelManager(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            return await _hotelRepository.CreateHotel(hotel);
        }

        public async Task DeleteHotelById(int id)
        {
            await _hotelRepository.DeleteHotelById(id);
        }

        public async Task<List<Hotel>> GetAllHotel()
        {
            return  await _hotelRepository.GetAllHotel();
        }

        public async Task<Hotel> GetHotelById(int id)
        {

            if (id > 0)
            {
                return  await _hotelRepository.GetHotelById(id);
            }

            throw new Exception("Id must be >1!");
        }

        public async Task<Hotel> GetHotelByName(string name)
        {
            if (name != null)
            {
                return await _hotelRepository.GetHotelByName(name);
            }
            throw new Exception("name don't be null!");
        }

        public async Task<Hotel> UpdateHotel(Hotel hotel)
        {
            return  await _hotelRepository.UpdateHotel(hotel);
        }
    }
}
