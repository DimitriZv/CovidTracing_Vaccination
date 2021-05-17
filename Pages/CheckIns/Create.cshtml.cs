using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project334.Data;
using Project334.Models;

namespace Project334.Pages.CheckIns
{
    public class CreateModel : PageModel
    {
        private readonly Project334.Data.Project334Context _context;

        public CreateModel(Project334.Data.Project334Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public VisitorCheckIn VisitorCheckIn { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.VisitorsCheckIn.Add(VisitorCheckIn);
            await _context.SaveChangesAsync();

            if (User.IsInRole("Admin") || User.IsInRole("Government") || User.IsInRole("Bussiness"))
            {
                return RedirectToPage("./Index");
            }
            else { return RedirectToPage("/Index"); }
        }
    }
}
