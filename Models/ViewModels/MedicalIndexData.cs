using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project334.Models.ViewModels
{
    public class MedicalIndexData
    {
        public IEnumerable<MedicalInstitution> MedicalInstitutions { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
        public IEnumerable<BookAppointment> BookAppointments { get; set; }
    }
}
