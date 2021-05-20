using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project334.Models
{
    public abstract class Address
    {
        [Key]
        public abstract int ID { get; set; }

        //public virtual int? DangerousCaseID { get; set; }

        [Required(ErrorMessage = "The Street number is required")]
        [StringLength(5)]
        [Display(Name = "Street Number")]
        public abstract string StreetNumber { get; set; }

        [Required(ErrorMessage = "The Street name is required")]
        [StringLength(50)]
        [Display(Name = "Street Name")]
        public abstract string StreetName { get; set; }

        [Required(ErrorMessage = "The City address is required")]
        [StringLength(30)]
        public abstract string City { get; set; }

        [Required(ErrorMessage = "The State address is required")]
        [StringLength(30)]
        public abstract string State { get; set; }

        /*[Required(ErrorMessage = "Zip Code is required")]
        [RegularExpression("([0-9]+)", ErrorMessage = "4 numbers from 0 to 9")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Zip Code cannot be longer than 4 numbers")]
        [Display(Name = "Zip Code")]
        public abstract string ZipCode { get; set; }*/
        [Required(ErrorMessage = "Zip Code is required")]
        [RegularExpression("([0-9]+)", ErrorMessage = "4 numbers from 0 to 9")]
        //[StringLength(4, MinimumLength = 4, ErrorMessage = "Zip Code cannot be longer than 4 numbers")]
        [Range(1000, 9999)]
        [Display(Name = "Zip Code")]
        public abstract int ZipCode { get; set; }

        [StringLength(15)]
        public abstract string Country { get; set; }
        /*public String Country
        { set { Country = "Australia"; } }*/

        [Display(Name = "Address")]
        public string FullAddress
        {
            get
            {
                return StreetNumber + " " + StreetName + " " + City + " " + State;
            }
        }
    }
}

