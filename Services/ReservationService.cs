using BookingSystem.Data;
using BookingSystem.Repositories;
using BookingSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace BookingSystem.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _repository;

        public ReservationService(IReservationRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Reservation>> GetAllAsync() => _repository.GetAllAsync();

        public Task<Reservation?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

        public Task AddAsync(Reservation reservation) => _repository.AddAsync(reservation);

        public Task UpdateAsync(Reservation reservation) => _repository.UpdateAsync(reservation);

        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}
