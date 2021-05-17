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

namespace Project334.Pages.MedicalInstitutions
{
    [Authorize(Roles = "Admin,Government")]
    public class DeleteModel : PageModel
    {
        private readonly Project334.Data.Project334Context _context;

        public DeleteModel(Project334.Data.Project334Context context)
        {
            _context = context;
        }

        [BindProperty]
        public MedicalInstitution MedicalInstitution { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MedicalInstitution = await _context.MedicalInstitutions.FirstOrDefaultAsync(m => m.ID == id);

            if (MedicalInstitution == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MedicalInstitution = await _context.MedicalInstitutions.FindAsync(id);

            if (MedicalInstitution != null)
            {
                _context.MedicalInstitutions.Remove(MedicalInstitution);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
