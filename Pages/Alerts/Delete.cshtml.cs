using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project334.Data;
using Project334.Models;

namespace Project334.Pages.Alerts
{
    public class DeleteModel : PageModel
    {
        private readonly Project334.Data.Project334Context _context;

        public DeleteModel(Project334.Data.Project334Context context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Alert = await _context.Alerts.FindAsync(id);

            if (Alert != null)
            {
                _context.Alerts.Remove(Alert);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
