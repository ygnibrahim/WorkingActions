using HotelFinder.DataAccess.Abstract;
using HotelFinderEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAccess.Concrete
{
    public class HotelRepository : IHotelRepository
    {
        public Hotel CreateHotel(Hotel hotel)
        {
            using (var hotelDbContext = new AppDbContext())
            {
                hotelDbContext.Hotels.Add(hotel);
                hotelDbContext.SaveChanges();
                return hotel;
            }
        }

        public void DeleteHotelById(int id)
        {
            using (var hotelDbContext = new AppDbContext())
            {
                var deleteHotel = GetHotelById(id);
                hotelDbContext.Remove(deleteHotel);
                hotelDbContext.SaveChanges();
            }
        }

        public List<Hotel> GetAllHotel()
        {
            using (var hotelDbContext = new AppDbContext())
            {
                return hotelDbContext.Hotels.ToList();
            }
        }

        public Hotel GetHotelById(int id)
        {
            using (var hotelDbContext = new AppDbContext())
            {
                return hotelDbContext.Hotels.Find(id);
            }
        }

        public Hotel GetHotelByName(string name)
        {
            using(var hotelDbContext = new AppDbContext())
            {
                return hotelDbContext.Hotels.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
            }
        }

        public Hotel UpdateHotel(Hotel hotel)
        {
            using (var hotelDbContext = new AppDbContext())
            {
                hotelDbContext.Hotels.Update(hotel);
                hotelDbContext.SaveChanges();
                return hotel;

            }
        }
    }
}
