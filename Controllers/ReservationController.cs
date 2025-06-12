using BookingSystem.Data;
using BookingSystem.Services;
using Microsoft.AspNetCore.Mvc;
using BookingSystem.Models;


namespace BookingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetReservations()
        {
            var reservations = await _reservationService.GetAllAsync();
            return Ok(reservations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservation(int id)
        {
            var reservation = await _reservationService.GetByIdAsync(id);
            if (reservation == null)
                return NotFound();
            return Ok(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(Reservation reservation)
        {
            await _reservationService.AddAsync(reservation);
            return CreatedAtAction(nameof(GetReservation), new { id = reservation.Id }, reservation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservation(int id, Reservation reservation)
        {
            if (id != reservation.Id)
                return BadRequest("ID mismatch");

            var existing = await _reservationService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _reservationService.UpdateAsync(reservation);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var existing = await _reservationService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _reservationService.DeleteAsync(id);
            return NoContent();
        }
    }
}
