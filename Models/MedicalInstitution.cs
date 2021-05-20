using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project334.Models
{
    public class MedicalInstitution : Address
    {
        /*[Key]
        public int MedicalInstitutionID { get; set; }*/
        public override int ID { get; set; }
        public override string StreetNumber { get; set; }
        public override string StreetName { get; set; }
        public override string City { get; set; }
        public override string State { get; set; }
        public override int ZipCode { get; set; } //public override string ZipCode { get; set; }
        public override string Country { get; set; } = "Australia";

        /*[Required(ErrorMessage = "The Address is required")]
        [Display(Name = "Medical Address")]
        public Address MedicalAddress { get; set; }*/

        [Display(Name = "Medical name")]
        [Required(ErrorMessage = "The Company name is required")]
        [StringLength(30)]
        public string Name { get; set; }

        [Display(Name = "Phone number")]
        [Required(ErrorMessage = "The Phone number is required")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Mobile number is ten digits")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public virtual ICollection<Appointment> Appointment { get; set; }
        //public virtual ICollection<BookAppointment> BookAppointments { get; set; }
    }
}