using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project334.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentID { get; set; }

        public int MedicalInstitutionID { get; set; }

        public int BookAppointmentID { get; set; }

        public virtual BookAppointment BookAppointment { get; set; }

        [Required(ErrorMessage = "The Appointment Date is required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid Format")]
        [Display(Name = "Appointment Date")]
        public DateTime AppointmentDate { get; set; }

        //public Patient Patient { get; set; }

        public Vaccine Vaccine { get; set; }

        [Required(ErrorMessage = "The Eligibility to Vaccination is required")]
        [Display(Name = "Eligible To Vaccination?")]
        public bool EligibilityToVaccine { get; set; }
        /*{
            get
            {
                return this.EligibilityToVaccine;
            }
            set
            {
                if (BookAppointment.Patient.HadVirus == true)
                {
                    this.EligibilityToVaccine = false;
                } else if (BookAppointment.EligibilityToVaccine == true && BookAppointment.Patient.HadVirus == false)
                {
                    this.EligibilityToVaccine = true;
                }
            }
        }*/
    }
}
