using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project334.Data;
using Project334.Models;

namespace Project334.Pages.BusinessActivities
{
    public class CreateModelNew : PageModel
    {
        private readonly Project334.Data.Project334Context _context;

        public CreateModelNew(Project334.Data.Project334Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BusinessActivity BusinessActivity { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();

            }
            
            var courseToUpdate = await _context.BusinessActivities.FindAsync(BusinessActivity.BusinessID);

            if (courseToUpdate != null && courseToUpdate.WorkingDate == BusinessActivity.WorkingDate)
            {
                ModelState.AddModelError("BusinessActivity", "Cannot be the same date to the same bussiness");
                return Page();
            }

            _context.BusinessActivities.Add(BusinessActivity);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
