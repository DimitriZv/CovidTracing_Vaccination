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

namespace Project334.Pages.BusinessActivities
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly Project334.Data.Project334Context _context;

        public DeleteModel(Project334.Data.Project334Context context)
        {
            _context = context;
        }

        [BindProperty]
        public BusinessActivity BusinessActivity { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BusinessActivity = await _context.BusinessActivities.FirstOrDefaultAsync(m => m.BusinessActivityID == id);

            if (BusinessActivity == null)
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

            BusinessActivity = await _context.BusinessActivities.FindAsync(id);

            if (BusinessActivity != null)
            {
                _context.BusinessActivities.Remove(BusinessActivity);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
