using System.ComponentModel.DataAnnotations;

namespace JP.Models
{
    public class AdminEvent
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FileUpload { get; set; }

        [Required]
        [EmailAddress]
        public string EventTitle { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string PackageDetails { get; set; }

        
    }
}


