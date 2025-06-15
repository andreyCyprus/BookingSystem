namespace BookingSystem.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public ICollection<Reservation>?Reservation { get; set; }
        public bool IsDeleted { get; set; } = false;

    }

}