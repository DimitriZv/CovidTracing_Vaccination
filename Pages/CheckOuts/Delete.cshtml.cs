using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project334.Data;
using Project334.Models;

namespace Project334.Pages.CheckOuts
{
    public class DeleteModel : PageModel
    {
        private readonly Project334.Data.Project334Context _context;

        public DeleteModel(Project334.Data.Project334Context context)
        {
            _context = context;
        }

        [BindProperty]
        public VisitorCheckOut VisitorCheckOut { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VisitorCheckOut = await _context.VisitorsCheckOut.FirstOrDefaultAsync(m => m.ID == id);

            if (VisitorCheckOut == null)
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

            VisitorCheckOut = await _context.VisitorsCheckOut.FindAsync(id);

            if (VisitorCheckOut != null)
            {
                _context.VisitorsCheckOut.Remove(VisitorCheckOut);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
