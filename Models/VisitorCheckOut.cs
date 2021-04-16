using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project334.Models
{
    /*public enum SexVisitorCheckOut
    {
        Male, Female
    }*/
    public class VisitorCheckOut : Person
    {
        public override int ID { get; set; }
        public override string MobilePhone { get; set; }
        public override string LastName { get; set; }
        public override string FirstMidName { get; set; }
        public override string Email { get; set; }

        [Display(Name = "CheckOut Date Time:")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid Format")]
        public DateTime CheckOut { get; set; }
    }
}