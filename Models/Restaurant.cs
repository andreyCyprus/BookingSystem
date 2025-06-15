namespace BookingSystem.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        required public string Name { get; set; }
        required public string Address { get; set; } 
        public int Capacity { get; set; }
        public ICollection<Reservation>? Reservation { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}