using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project334.Models
{
    public class Address
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "The Street name is required")]
        [StringLength(50)]
        public String StreetName { get; set; }

        [Required(ErrorMessage = "The Street number is required")]
        [StringLength(5)]
        public String StreetNumber { get; set; }

        [Required(ErrorMessage = "The City address is required")]
        [StringLength(30)]
        public String City { get; set; }

        [Required(ErrorMessage = "The State address is required")]
        [StringLength(30)]
        public String State { get; set; }

        [Required(ErrorMessage = "The Zip Code is required")]
        [StringLength(5)]
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }

        [StringLength(30)]
        public String Country
        {
            set
            {
                Country = "Australia";
            }
        }
    }
}

