namespace BookingSystem.Data
{
    public class Reservation
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Type { get; set; } = string.Empty; // Ресторан / Гостиница / Авиабилет и т.д.
    }
}
