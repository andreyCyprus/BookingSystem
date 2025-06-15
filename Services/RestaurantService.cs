using System.Collections.Generic;
using System.Threading.Tasks;
using BookingSystem.Models;
using BookingSystem.Repositories;
using BookingSystem.Interfaces;

namespace BookingSystem.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }
        public async Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync()
        {
            return await _restaurantRepository.GetAllAsync();
        }
        public async Task<Restaurant?> GetRestaurantByIdAsync(int id)
        {
            return await _restaurantRepository.GetByIdAsync(id);
        }
        public async Task AddRestaurantAsync(Restaurant restaurant)
        {
            await _restaurantRepository.AddAsync(restaurant);
        }
        public async Task UpdateRestaurantAsync(Restaurant restaurant)
        {
            await _restaurantRepository.UpdateAsync(restaurant);
        }
        public async Task<bool> DeleteRestaurantAsync(int id)
        {
            var restaurant = await _restaurantRepository.GetByIdAsync(id);

            if (restaurant == null || restaurant.IsDeleted)
                return false;

            restaurant.IsDeleted = true;
            await _restaurantRepository.UpdateAsync(restaurant);

            return true;
        }


    }
}