using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Models
{
    public class CarRental
    {
        public int Id { get; set; }

        [Required]
        public string CarBrand { get; set; } = string.Empty;

        [Required]
        public string CarModel { get; set; } = string.Empty;

        public int Year { get; set; }

        [Required]
        public decimal DailyPrice { get; set; }

        [Required]
        public string Location { get; set; } = string.Empty;

        public bool IsDeleted { get; set; } = false;
    }
}
