namespace BookingSystem.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string BookingType { get; set; } // hotel, flight, restaurant � �.�.
        public DateTime ReservationDate { get; set; }
    }
}
