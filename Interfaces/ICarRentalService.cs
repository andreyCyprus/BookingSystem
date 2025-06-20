using BookingSystem.Models;

namespace BookingSystem.Interfaces
{
    public interface ICarRentalService
    {
        Task<IEnumerable<CarRental>> GetAllCarRentalsAsync();
        Task<CarRental?> GetCarRentalByIdAsync(int id);
        Task AddCarRentalAsync(CarRental carRental);
        Task UpdateCarRentalAsync(CarRental carRental);
        Task<bool> DeleteCarRentalAsync(int id);
    }
}
