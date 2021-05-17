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
    [Authorize(Roles = "Admin,Government,Medical,Patient")]
    public class DetailsModel : PageModel
    {
        private readonly Project334.Data.Project334Context _context;

        public DetailsModel(Project334.Data.Project334Context context)
        {
            _context = context;
        }

        public MedicalInstitution MedicalInstitution { get; set; }
        public IList<BookAppointment> BookAppointments { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var contacts = from c in _context.BookAppointments
                           select c;
            var med = from f in _context.MedicalInstitutions
                           select f;*/

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
            else if (User.IsInRole("Patient")) 
            {
                BookAppointments = await _context.BookAppointments
                .Include(g => g.Patient)
                .Where(h => h.MedicalInstitutionID == id)
                .Where(f => f.Patient.Email == userName)
                .ToListAsync();

                MedicalInstitution = await _context.MedicalInstitutions
                 .AsNoTracking()
                 .FirstOrDefaultAsync(m => m.ID == id);
                //contacts = contacts.Where(c => c.Email == userName);
                /*contacts = contacts
                    .Include(g => g.Patient)
                    .Where(h => h.MedicalInstitutionID == id)
                    .Where(s => s.Patient.Email == userName);

                med = med
                .Include(s => s.Appointment)
                    .ThenInclude(f => f.BookAppointment)
                    .ThenInclude(b => b.Patient)
                    .Where(c => c.Email == userName);*/
            }

            /*BookAppointments = await contacts
                .Include(g => g.Patient)
                .Where(h => h.MedicalInstitutionID == id)
                .ToListAsync();

            MedicalInstitution = await med
                .Include(s => s.Appointment)
                    .ThenInclude(f => f.BookAppointment)
                    .ThenInclude(b => b.Patient)
                .Include(s => s.Appointment)
                    .ThenInclude(v => v.Vaccine)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);*/




            /*BookAppointments = await _context.BookAppointments
                .Include(g => g.Patient)
                .Where(h => h.MedicalInstitutionID == id)
                //.OrderBy(i => i.MedicalInstitutionID)
                .ToListAsync();*/

                /*MedicalInstitution = await _context.MedicalInstitutions
                    //.Include(h => h.MedicalAddress)
                    .Include(s => s.Appointment)
                        .ThenInclude(f => f.BookAppointment)
                        .ThenInclude(b => b.Patient)
                    .Include(s => s.Appointment)
                        .ThenInclude(v => v.Vaccine)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.ID == id);*/

            if (MedicalInstitution == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
