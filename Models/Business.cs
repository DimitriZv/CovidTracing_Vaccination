using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project334.Models
{
    public class Business
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "The Address is required")]
        public Address CompanyAddress { get; set; }

        [Display(Name = "Phone number")]
        [Required(ErrorMessage = "The Phone number is required")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        
        [Required(ErrorMessage = "The ABN is required")]
        [RegularExpression("([0-9]+)", ErrorMessage = "11 numbers from 1 to 9")] // for numbers that need to start with a zero
        [StringLength(11, ErrorMessage = "ABN cannot be longer than 11 numbers")]
        public int ABN { get; set; }

        ICollection<BusinessActivity> DailyActivities { get; set; }
    }
}
