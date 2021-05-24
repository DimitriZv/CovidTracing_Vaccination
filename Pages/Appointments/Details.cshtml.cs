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

namespace Project334.Pages.Appointments
{
    [Authorize(Roles = "Admin,Medical,Government,Patient")]
    public class DetailsModel : PageModel
    {
        private readonly Project334.Data.Project334Context _context;

        public DetailsModel(Project334.Data.Project334Context context)
        {
            _context = context;
        }

        public Appointment Appointment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userName = User.FindFirstValue(ClaimTypes.Name);

            if (User.IsInRole("Admin") || User.IsInRole("Medical") || User.IsInRole("Government"))
            {
                Appointment = await _context.Appointments
                .Include(v => v.Vaccine)
                .Include(f => f.BookAppointment)
                    .ThenInclude(k => k.Patient)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.AppointmentID == id);
            }

            if (User.IsInRole("Patient"))
            {
                Appointment = await _context.Appointments
                .Include(v => v.Vaccine)
                .Include(f => f.BookAppointment)
                    .ThenInclude(k => k.Patient)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.AppointmentID == id);
                string email = Appointment.BookAppointment.Patient.Email.ToUpper();
                if (userName.ToUpper().Contains(email))
                {
                    return Page();
                }
                else
                {
                    return NotFound();
                }
                
            }

            if (Appointment == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
