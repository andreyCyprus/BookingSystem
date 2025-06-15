using System.Collections.Generic;
using System.Threading.Tasks;
using BookingSystem.Models;
using BookingSystem.Interfaces;
using BookingSystem.Repositories;

namespace BookingSystem.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<IEnumerable<Hotel>> GetAllHotelsAsync()
        {
            return await _hotelRepository.GetAllAsync();
        }

        public async Task<Hotel?> GetHotelByIdAsync(int id)
        {
            return await _hotelRepository.GetByIdAsync(id);
        }

        public async Task AddHotelAsync(Hotel hotel)
        {
            await _hotelRepository.AddAsync(hotel);
        }

        public async Task UpdateHotelAsync(Hotel hotel)
        {
            await _hotelRepository.UpdateAsync(hotel);
        }

        public async Task<bool> DeleteHotelAsync(int id)
        {
            var hotel = await _hotelRepository.GetByIdAsync(id);

            if (hotel == null || hotel.IsDeleted)
                return false;

            hotel.IsDeleted = true;
            await _hotelRepository.UpdateAsync(hotel);

            return true;
        }

    }
}
