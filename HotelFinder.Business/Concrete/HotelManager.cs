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

        public Hotel CreateHotel(Hotel hotel)
        {
            return _hotelRepository.CreateHotel(hotel);
        }

        public void DeleteHotelById(int id)
        {
            _hotelRepository.DeleteHotelById(id);
        }

        public List<Hotel> GetAllHotel()
        {
            return _hotelRepository.GetAllHotel();
        }

        public Hotel GetHotelById(int id)
        {

            if (id > 0)
            {
                return _hotelRepository.GetHotelById(id);
            }

            throw new Exception("Id must be >1!");
        }

        public Hotel GetHotelByName(string name)
        {
            if (name != null)
            {
                return _hotelRepository.GetHotelByName(name);
            }
            throw new Exception("name don't be null!");
        }

        public Hotel UpdateHotel(Hotel hotel)
        {
            return _hotelRepository.UpdateHotel(hotel);
        }
    }
}
