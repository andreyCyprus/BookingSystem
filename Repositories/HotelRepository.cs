using BookingSystem.Data;
using BookingSystem.Models;
using BookingSystem.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly BookingContext _context;

        public HotelRepository(BookingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Hotel>> GetAllAsync()
        {
            return await _context.Hotels.Where(h => !h.IsDeleted).ToListAsync();
        }

        public async Task<Hotel?> GetByIdAsync(int id)
        {
            return await _context.Hotels.FindAsync(id);
        }

        public async Task AddAsync(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel != null)
            {
                hotel.IsDeleted = true;
                _context.Hotels.Update(hotel);
                await _context.SaveChangesAsync();
            }
        }

    }
}
