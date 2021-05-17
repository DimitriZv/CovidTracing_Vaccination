using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project334.Data;
using Project334.Models;

namespace Project334.Pages.DangerousCases
{
    [Authorize(Roles = "Admin,Government")]
    public class EditModel : PageModel
    {
        private readonly Project334.Data.Project334Context _context;

        public EditModel(Project334.Data.Project334Context context)
        {
            _context = context;
        }

        [BindProperty]
        public DangerousCase DangerousCase { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DangerousCase = await _context.DangerousCases.FirstOrDefaultAsync(m => m.ID == id);

            if (DangerousCase == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DangerousCase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DangerousCaseExists(DangerousCase.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DangerousCaseExists(int id)
        {
            return _context.DangerousCases.Any(e => e.ID == id);
        }
    }
}
