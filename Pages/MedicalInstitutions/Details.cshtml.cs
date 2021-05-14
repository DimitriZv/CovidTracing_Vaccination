using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project334.Data;
using Project334.Models;

namespace Project334.Pages.MedicalInstitutions
{
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

            BookAppointments = await _context.BookAppointments
                .Include(g => g.Patient)
                .Where(h => h.MedicalInstitutionID == id)
                //.OrderBy(i => i.MedicalInstitutionID)
                .ToListAsync();
            
            MedicalInstitution = await _context.MedicalInstitutions
                //.Include(h => h.MedicalAddress)
                .Include(s => s.Appointment)
                    .ThenInclude(f => f.BookAppointment)
                    .ThenInclude(b => b.Patient)
                .Include(s => s.Appointment)
                    .ThenInclude(v => v.Vaccine)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (MedicalInstitution == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
