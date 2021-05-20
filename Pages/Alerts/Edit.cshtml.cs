using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project334.Data;
using Project334.Models;

namespace Project334.Pages.Alerts
{
    public class EditModel : PageModel
    {
        private readonly Project334.Data.Project334Context _context;

        public EditModel(Project334.Data.Project334Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Alert Alert { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Alert = await _context.Alerts
                .Include(a => a.DangerousCase).FirstOrDefaultAsync(m => m.AlertID == id);

            if (Alert == null)
            {
                return NotFound();
            }
           ViewData["DangerousCaseID"] = new SelectList(_context.DangerousCases, "ID", "Email");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Alert).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlertExists(Alert.AlertID))
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

        private bool AlertExists(int id)
        {
            return _context.Alerts.Any(e => e.AlertID == id);
        }
    }
}
