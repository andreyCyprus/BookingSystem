using BookingSystem.Data;
using BookingSystem.Models;
using BookingSystem.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurants()
        {
            var restaurants = await _restaurantService.GetAllRestaurantsAsync();
            return Ok(restaurants);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> GetRestaurant(int id)
        {
            var restaurant = await _restaurantService.GetRestaurantByIdAsync(id);
            if (restaurant == null)
                return NotFound();
            return Ok(restaurant);
        }
        [HttpPost]
        public async Task<ActionResult> CreateRestaurant([FromBody] Restaurant restaurant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _restaurantService.AddRestaurantAsync(restaurant);
            return CreatedAtAction(nameof(GetRestaurant), new { id = restaurant.Id }, restaurant);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRestaurant(int id, [FromBody] Restaurant restaurant)
        {
            if (id != restaurant.Id)
                return BadRequest("ID mismatch");
            await _restaurantService.UpdateRestaurantAsync(restaurant);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRestaurant(int id)
        {
            await _restaurantService.DeleteRestaurantAsync(id);
            return NoContent();
        }
    }
}