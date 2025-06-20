using BookingSystem.Data;
using BookingSystem.Interfaces;
using BookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Repositories
{
    public class CarRentalRepository : ICarRentalRepository
    {
        private readonly BookingContext _context;

        public CarRentalRepository(BookingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CarRental>> GetAllAsync()
        {
            return await _context.CarRentals.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<CarRental?> GetByIdAsync(int id)
        {
            return await _context.CarRentals.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        }

        public async Task AddAsync(CarRental carRental)
        {
            await _context.CarRentals.AddAsync(carRental);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CarRental carRental)
        {
            _context.CarRentals.Update(carRental);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(CarRental carRental)
        {
            _context.CarRentals.Remove(carRental);
            await _context.SaveChangesAsync();
        }
    }
}
