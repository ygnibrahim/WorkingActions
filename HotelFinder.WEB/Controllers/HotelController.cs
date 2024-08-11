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
        public async Task<IActionResult> Get()
        {
            var hotel = await _hotelService.GetAllHotel();
            return Ok(hotel); //200 OK
        }

        /// <summary>
        /// Get hotel by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetHotelById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var hotel = await _hotelService.GetHotelById(id);
            if (hotel != null)
            {
                return Ok(hotel);
            }
            return NotFound(); //404
        }

        [HttpGet]
        [Route("GetHotelByName/{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var hotel =await  _hotelService.GetHotelByName(name);
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
        public async Task<IActionResult> Post([FromBody] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                var createdHotel=await _hotelService.CreateHotel(hotel);
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
        public async Task<IActionResult> Put([FromBody] Hotel hotel)
        {
            if( await _hotelService.GetHotelById(hotel.Id) != null)
            {
                return Ok( await _hotelService.UpdateHotel(hotel));
            }
            return NotFound();
        }

        /// <summary>
        /// delete hotel by id
        /// </summary>
        /// <param name="id"></param>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if( await _hotelService.GetHotelById(id) != null)
            {
                 await _hotelService.DeleteHotelById(id);
                return Ok();
            }
            return NotFound();
        }

    }
}
