using BookingSystem.Data;
using BookingSystem.Models;
using BookingSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
        {
            var hotels = await _hotelService.GetAllHotelsAsync();
            return Ok(hotels);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            var hotel = await _hotelService.GetHotelByIdAsync(id);
            if (hotel == null)
                return NotFound();

            return Ok(hotel);
        }

        [HttpPost]
        public async Task<ActionResult> CreateHotel([FromBody] Hotel hotel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _hotelService.AddHotelAsync(hotel);
            return CreatedAtAction(nameof(GetHotel), new { id = hotel.Id }, hotel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateHotel(int id, [FromBody] Hotel hotel)
        {
            if (id != hotel.Id)
                return BadRequest("ID mismatch");

            await _hotelService.UpdateHotelAsync(hotel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHotel(int id)
        {
            await _hotelService.DeleteHotelAsync(id);
            return NoContent();
        }
    }
}
