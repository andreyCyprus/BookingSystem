using Microsoft.AspNetCore.Mvc;
using BookingSystem.Models;
using BookingSystem.Interfaces;
using BookingSystem.Data;

namespace BookingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarRentalController : ControllerBase
    {
        private readonly ICarRentalService _carRentalService;

        public CarRentalController(ICarRentalService carRentalService)
        {
            _carRentalService = carRentalService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarRental>>> GetAll()
        {
            var rentals = await _carRentalService.GetAllCarRentalsAsync();
            return Ok(rentals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarRental>> GetById(int id)
        {
            var rental = await _carRentalService.GetCarRentalByIdAsync(id);
            if (rental == null) return NotFound();
            return Ok(rental);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CarRental carRental)
        {
            await _carRentalService.AddCarRentalAsync(carRental);
            return CreatedAtAction(nameof(GetById), new { id = carRental.Id }, carRental);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, CarRental carRental)
        {
            if (id != carRental.Id) return BadRequest();
            await _carRentalService.UpdateCarRentalAsync(carRental);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var success = await _carRentalService.DeleteCarRentalAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
