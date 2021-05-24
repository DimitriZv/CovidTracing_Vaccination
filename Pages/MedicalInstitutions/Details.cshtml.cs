using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project334.Data;
using Project334.Models;

namespace Project334.Pages.MedicalInstitutions
{
    //[Authorize(Roles = "Admin,Government,Medical,Patient")]
    public class DetailsModel : PageModel
    {
        private readonly Project334.Data.Project334Context _context;

        public DetailsModel(Project334.Data.Project334Context context)
        {
            _context = context;
        }

        public MedicalInstitution MedicalInstitution { get; set; }
        public IList<BookAppointment> BookAppointments { get; set; }
        public IList<Appointment> Appointments { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IQueryable<Appointment> appointmentsQ = from s in _context.Appointments
                                                    select s;

            var userName = User.FindFirstValue(ClaimTypes.Name); //should be an email

            if (User.IsInRole("Admin") || User.IsInRole("Government") || User.IsInRole("Medical"))
            {
                BookAppointments = await _context.BookAppointments
                .Include(g => g.Patient)
                .Where(h => h.MedicalInstitutionID == id)
                .ToListAsync(); 

               MedicalInstitution = await _context.MedicalInstitutions
                .Include(s => s.Appointment)
                    .ThenInclude(f => f.BookAppointment)
                    .ThenInclude(b => b.Patient)
                .Include(s => s.Appointment)
                    .ThenInclude(v => v.Vaccine)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            }
            else if (User.IsInRole("Patient") /*|| !User.Identity.IsAuthenticated*/) 
            {
                BookAppointments = await _context.BookAppointments
                .Include(g => g.Patient)
                .Where(h => h.MedicalInstitutionID == id)
                .Where(f => f.Patient.Email == userName)
                .ToListAsync();

                appointmentsQ = appointmentsQ
                    .Include(d => d.BookAppointment)
                        .ThenInclude(k => k.Patient)
                        .Where(s => s.BookAppointment.Patient.Email.ToUpper().Contains(userName.ToUpper()))
                    .Include(l => l.Vaccine);
                Appointments = await appointmentsQ.AsNoTracking().ToListAsync();

                MedicalInstitution = await _context.MedicalInstitutions
                 .AsNoTracking()
                 .FirstOrDefaultAsync(m => m.ID == id);
            }
            else
            {
                MedicalInstitution = await _context.MedicalInstitutions
                 .AsNoTracking()
                 .FirstOrDefaultAsync(m => m.ID == id);
            }

            if (MedicalInstitution == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
