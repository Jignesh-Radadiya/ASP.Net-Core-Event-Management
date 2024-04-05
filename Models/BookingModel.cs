using System.ComponentModel.DataAnnotations;

namespace JP.Models
{
    public class BookingModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string MobileNo { get; set; }

        [Required]
        public string EventName { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string EventPlace { get; set; }  
    }
}
