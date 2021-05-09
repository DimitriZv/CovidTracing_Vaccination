using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project334.Data;
using Project334.Models;

namespace Project334.Pages.BookAppointments
{
    public class DetailsModel : PageModel
    {
        private readonly Project334.Data.Project334Context _context;

        public DetailsModel(Project334.Data.Project334Context context)
        {
            _context = context;
        }

        public BookAppointment BookAppointment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BookAppointment = await _context.BookAppointments
                .Include(s => s.Patient)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.BookAppointmentID == id);

            if (BookAppointment == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
