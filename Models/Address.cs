using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project334.Models
{
    public class Address
    {
        [Key]
        public int ID { get; set; }

        public int? DangerousCaseID { get; set; }

        [Required(ErrorMessage = "The Street number is required")]
        [StringLength(5)]
        [Display(Name = "Street Number")]
        public string StreetNumber { get; set; }

        [Required(ErrorMessage = "The Street name is required")]
        [StringLength(50)]
        [Display(Name = "Street Name")]
        public string StreetName { get; set; }

        [Required(ErrorMessage = "The City address is required")]
        [StringLength(30)]
        public string City { get; set; }

        [Required(ErrorMessage = "The State address is required")]
        [StringLength(30)]
        public string State { get; set; }

        [Required(ErrorMessage = "Zip Code is required")]
        [RegularExpression("([0-9]+)", ErrorMessage = "4 numbers from 0 to 9")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Zip Code cannot be longer than 4 numbers")]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [StringLength(15)]
        public string Country { get; set; } = "Australia";
        /*public String Country
        { set { Country = "Australia"; } }*/
    }
}

