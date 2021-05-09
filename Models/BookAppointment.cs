using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project334.Models
{
    public class BookAppointment
    {
        [Key]
        public int BookAppointmentID { get; set; }

        public int MedicalInstitutionID { get; set; }

        public virtual Patient Patient { get; set; }

        [Required(ErrorMessage = "The Eligibility to Vaccination is required")]
        [Display(Name = "Eligible To Vaccination?")]
        public bool EligibilityToVaccine { get; set; } = false;

        [Required(ErrorMessage = "The Medicare is required")]
        [StringLength(10, ErrorMessage = "Medicare cannot be longer than 10 digits")]
        [RegularExpression(@"[0-9]*\.?[0-9]+", ErrorMessage = "10 digits from 0 to 9")]
        public string Medicare { get; set; }
    }
}
