using HotelFinder.Business.Abstract;
using HotelFinderEntities;
using Microsoft.AspNetCore.Mvc;

namespace HotelFinder.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        /// <summary>
        /// Get all Hotels
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var hotel = _hotelService.GetAllHotel();
            return Ok(hotel); //200 OK
        }

        /// <summary>
        /// Get hotel by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetHotelById/{id}")]
        public IActionResult Get(int id)
        {
            var hotel = _hotelService.GetHotelById(id);
            if (hotel != null)
            {
                return Ok(hotel);
            }
            return NotFound(); //404
        }

        [HttpGet]
        [Route("GetHotelByName/{name}")]
        public IActionResult Get(string name)
        {
            var hotel = _hotelService.GetHotelByName(name);
            if (hotel != null)
            {
                return Ok(hotel);
            }
            return NotFound(); //404
        }

        /// <summary>
        /// post hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                var createdHotel=_hotelService.CreateHotel(hotel);
                return Ok(createdHotel);
            }
            return BadRequest(ModelState);    
        }
        /// <summary>
        /// put hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] Hotel hotel)
        {
            if(_hotelService.GetHotelById(hotel.Id) != null)
            {
                return Ok(_hotelService.UpdateHotel(hotel));
            }
            return NotFound();
        }

        /// <summary>
        /// delete hotel by id
        /// </summary>
        /// <param name="id"></param>

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(_hotelService.GetHotelById(id) != null)
            {
                _hotelService.DeleteHotelById(id);
                return Ok();
            }
            return NotFound();
        }

    }
}
