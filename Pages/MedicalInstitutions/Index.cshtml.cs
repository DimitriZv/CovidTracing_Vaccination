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
    //[Authorize(Roles = "Admin,Government,Medical")]
    public class IndexModel : PageModel
    {
        private readonly Project334.Data.Project334Context _context;

        public IndexModel(Project334.Data.Project334Context context)
        {
            _context = context;
        }

        public string CurrentFilter { get; set; }
        public IList<MedicalInstitution> MedicalInstitution { get; set; }

        public async Task OnGetAsync(string searchString)
        {
            CurrentFilter = searchString;

            var contacts = from c in _context.MedicalInstitutions
                           select c;

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userName = User.FindFirstValue(ClaimTypes.Name); //should be an email

            if (User.IsInRole("Admin") || User.IsInRole("Government"))
            {

            }
            else if (User.IsInRole("Medical"))
            {
                contacts = contacts.Where(c => c.Email == userName);
            }
            else if (User.IsInRole("Patient") && searchString == "ShowMyVisitedPlaces")
            {
               contacts = contacts.Where(p => p.Appointment.Any(s => s.BookAppointment.Patient.Email == userName));
            }
            else
            {
                
            }

            MedicalInstitution = await contacts
                .AsNoTracking()
                .ToListAsync();

            /*MedicalInstitution = await _context.MedicalInstitutions
                //.Include(s => s.MedicalAddress)
                .AsNoTracking()
                .ToListAsync();*/
        }
    }
}
