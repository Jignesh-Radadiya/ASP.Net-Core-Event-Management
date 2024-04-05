using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace JP.Models
{
    public class Bookingedit 
    {
      
            [Key]
            public int Id { get; set; }

            [Required(ErrorMessage = "Check-in date is required")]
            [Display(Name = "Username")]
            public DateTime Username { get; set; }

            [Required(ErrorMessage = "Check-out date is required")]
            [Display(Name = "Check-out Date")]
            public DateTime Email
        { get; set; }

            [Required(ErrorMessage = "Event is required")]
            [Display(Name = "Events")]
            public string MobileNo { get; set; }

            [Required(ErrorMessage = "Event Place is required")]
            [Display(Name = "Event Place")]
            public string EventName { get; set; }

        [Required(ErrorMessage = "Number of adults is required")]
        [Display(Name = "Number of Adults")]
        public int Date { get; set; }

        [Required(ErrorMessage = "Number of children is required")]
        [Display(Name = "Number of Children")]
        public int EventPlace { get; set; }

      
    }
}

