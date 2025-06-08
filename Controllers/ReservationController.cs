using Microsoft.AspNetCore.Mvc;
using BookingSystem.Data;
using BookingSystem.Models;

namespace BookingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly BookingContext _context;

        public ReservationController(BookingContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetReservations() =>
            Ok(_context.Reservations.ToList());

        [HttpPost]
        public IActionResult CreateReservation(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
            return Ok(reservation);
        }
    }
}
