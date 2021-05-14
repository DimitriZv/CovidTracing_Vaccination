using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project334.Models
{
    public enum Sex
    {
        Male, Female
    }

    public class DangerousCase : Person
    {
        public override int ID { get; set; }
        public override string MobilePhone { get; set; }
        public override string LastName { get; set; }
        public override string FirstMidName { get; set; }
        public override string Email { get; set; }

        [Display(Name = "Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid Format")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "The Sex is required")]
        [Display(Name = "Gender")]
        public Sex Sex { get; set; }


        [Display(Name = "Confirm Virus Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid Format")]
        public DateTime ConfirmDate { get; set; }

        [Required(ErrorMessage = "The HasVaccine is required")]
        [Display(Name = "Has vaccine?")]
        public bool HasVaccine { get; set; }

        public virtual ICollection<AddressDate> VisitedPlaces { get; set; }
    }
}