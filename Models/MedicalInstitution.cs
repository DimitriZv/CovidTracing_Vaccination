using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project334.Models
{
    public class MedicalInstitution
    {
        [Key]
        public int MedicalInstitutionID { get; set; }

        [Required(ErrorMessage = "The Address is required")]
        [Display(Name = "Medical Address")]
        public Address MedicalAddress { get; set; }

        [Display(Name = "Medical name")]
        [Required(ErrorMessage = "The Company name is required")]
        [StringLength(30)]
        public string Name { get; set; }

        [Display(Name = "Phone number")]
        [Required(ErrorMessage = "The Phone number is required")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Mobile number is ten digits")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        
        public virtual ICollection<Appointment> Appointment { get; set; }
        //public virtual ICollection<BookAppointment> BookAppointments { get; set; }
    }
}
