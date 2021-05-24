using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project334.Data;
using Project334.Models;

namespace Project334.Pages.Vaccines
{
    public class DetailsModel : PageModel
    {
        private readonly Project334.Data.Project334Context _context;

        public DetailsModel(Project334.Data.Project334Context context)
        {
            _context = context;
        }

        public Vaccine Vaccine { get; set; }
        public Appointment Appointment { get; set; }
        public MedicalInstitution MedicalInstitution { get; set; }
        public Patient Patient { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IQueryable<Appointment> appointmentQ = from s in _context.Appointments
                                              select s;
            IQueryable<MedicalInstitution> medicalInstitutionQ = from s in _context.MedicalInstitutions
                                                   select s;
            IQueryable<Patient> patientsQ = from s in _context.Patients
                                                      select s;
            IQueryable<Vaccine> vaccinesQ = from s in _context.Vaccines
                                            select s;

            Appointment = appointmentQ
                .Include(s => s.BookAppointment)
                .AsNoTracking()
                .FirstOrDefault(s => s.Vaccine.VaccineID == id);

            MedicalInstitution = medicalInstitutionQ.FirstOrDefault(d => d.ID == Appointment.MedicalInstitutionID);
            
            Vaccine = vaccinesQ.AsNoTracking().FirstOrDefault(m => m.VaccineID == id);
            int patId = Vaccine.PatientID;

            Patient = patientsQ.AsNoTracking().FirstOrDefault(f => f.ID == patId);

            Vaccine = await _context.Vaccines
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.VaccineID == id);

            if (Vaccine == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
