using System.ComponentModel.DataAnnotations;

namespace JP.Models
{
    public class UserModel
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
        public string Password { get; set; }
    }
}
