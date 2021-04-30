using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project334.Models
{
    /*public enum SexVisitorCheckIn
    {
        Male, Female
    }*/

    public class VisitorCheckIn : Person
    {
        public override int ID { get; set; }
        public override string MobilePhone { get; set; }
        public override string LastName { get; set; }
        public override string FirstMidName { get; set; }
        public override string Email { get; set; }

        [Display(Name = "Business Activity ID")]
        [Required(ErrorMessage = "Business Activity ID is required")]
        [Range(1,10000)]
        public int BusinessActivityID { get; set; }

        [Display(Name = "CheckIn Date Time:")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid Format")]
        public DateTime CheckIn { get; set; }
    }
}