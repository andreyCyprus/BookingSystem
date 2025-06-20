using BookingSystem.Interfaces;
using BookingSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookingSystem.Repositories;


namespace BookingSystem.Services
{
    public class CarRentalService : ICarRentalService
    {
        private readonly ICarRentalRepository _carRentalRepository;

        public CarRentalService(ICarRentalRepository carRentalRepository)
        {
            _carRentalRepository = carRentalRepository;
        }

        public async Task<IEnumerable<CarRental>> GetAllCarRentalsAsync()
        {
            return await _carRentalRepository.GetAllAsync();
        }

        public async Task<CarRental?> GetCarRentalByIdAsync(int id)
        {
            return await _carRentalRepository.GetByIdAsync(id);
        }

        public async Task AddCarRentalAsync(CarRental carRental)
        {
            await _carRentalRepository.AddAsync(carRental);
        }

        public async Task UpdateCarRentalAsync(CarRental carRental)
        {
            await _carRentalRepository.UpdateAsync(carRental);
        }

        public async Task<bool> DeleteCarRentalAsync(int id)
        {
            var carRental = await _carRentalRepository.GetByIdAsync(id);
            if (carRental == null || carRental.IsDeleted)
                return false;

            carRental.IsDeleted = true;
            await _carRentalRepository.UpdateAsync(carRental);
            return true;
        }
    }
}
