namespace BookingSystem.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string BookingType { get; set; } // hotel, flight, restaurant è ò.ä.
        public DateTime ReservationDate { get; set; }
    }
}
