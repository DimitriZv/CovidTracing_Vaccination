using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Project334.Models
{
    public class BusinessActivity
    {
        [Key]
        public int BusinessActivityID { get; set; }

        [Display(Name = "Business ID")]
        [Required(ErrorMessage = "Business ID is required")]
        [Range(1, 10000)]
        public int BusinessID { get; set; }

        [Required(ErrorMessage = "The Working Date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Working Date")]
        public DateTime WorkingDate { get; set; }
        
        public virtual ICollection<VisitorCheckIn> VisitorCheckIn { get; set; }
        public virtual ICollection<VisitorCheckOut> VisitorCheckOut { get; set; }
    }
}