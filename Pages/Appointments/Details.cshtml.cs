using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project334.Data;
using Project334.Models;

namespace Project334.Pages.Appointments
{
    [Authorize(Roles = "Admin,Medical,Government")]
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
            
            Appointment = await _context.Appointments
                .Include(v => v.Vaccine)
                .Include(f => f.BookAppointment)
                    .ThenInclude(k => k.Patient)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.AppointmentID == id);

            if (Appointment == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
