namespace BookingSystem.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public required string CustomerName { get; set; }
        public required string BookingType { get; set; } // hotel, flight, restaurant � �.�.
        public DateTime ReservationDate { get; set; }
    }
}
