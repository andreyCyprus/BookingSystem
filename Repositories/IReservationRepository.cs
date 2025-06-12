using BookingSystem.Data;
using BookingSystem.Models;



namespace BookingSystem.Repositories
{
	public interface IReservationRepository
	{
		Task<IEnumerable<Reservation>> GetAllAsync();
		Task<Reservation?> GetByIdAsync(int id);
		Task AddAsync(Reservation reservation);
		Task UpdateAsync(Reservation reservation);
		Task DeleteAsync(int id);
	}
}
