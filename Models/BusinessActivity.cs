using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Project334.Models
{
    public class BusinessActivity
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "The Working Date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Working Date")]
        public DateTime WorkingDate { get; set; }
        
        public ICollection<VisitorCheckIn> VisitorCheckIn { get; set; }
        public ICollection<VisitorCheckOut> VisitorCheckOut { get; set; }
    }
}