using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project334.Models
{
    public class Business
    {
        [Key]
        public int BusinessID { get; set; }

        [Required(ErrorMessage = "The Address is required")]
        [Display(Name = "Company Address")]
        public Address CompanyAddress { get; set; }

        [Display(Name = "Company name")]
        [Required(ErrorMessage = "The Company name is required")]
        [StringLength(30)]
        public string Name { get; set; }

        [Display(Name = "Phone number")]
        [Required(ErrorMessage = "The Phone number is required")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number is ten digits")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "The ABN is required")]
        [StringLength(11, ErrorMessage = "ABN cannot be longer than 11 numbers")]
        //[Range(10000000000, 99999999999, ErrorMessage = "11 digits from 1 to 9")]
        //[RegularExpression(@"([0-9]+)", ErrorMessage = "11 digits from 0 to 9")]
        [RegularExpression(@"[0-9]*\.?[0-9]+", ErrorMessage = "11 digits from 0 to 9")]
        public string ABN { get; set; }

        public virtual ICollection<BusinessActivity> DailyActivities { get; set; }
    }
}
