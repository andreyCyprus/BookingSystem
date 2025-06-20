using BookingSystem.Models;

namespace BookingSystem.Interfaces
{
    public interface ICarRentalRepository
    {
        Task<IEnumerable<CarRental>> GetAllAsync();
        Task<CarRental?> GetByIdAsync(int id);
        Task AddAsync(CarRental carRental);
        Task UpdateAsync(CarRental carRental);
        Task DeleteAsync(CarRental carRental);
    }
}
