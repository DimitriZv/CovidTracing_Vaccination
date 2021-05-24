using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project334.Data;
using Project334.Models;

namespace Project334.Pages.Alerts
{
    [Authorize(Roles = "Admin,Government")]
    public class CreateModel : PageModel
    {
        private readonly Project334.Data.Project334Context _context;

        public CreateModel(Project334.Data.Project334Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DangerousCaseID"] = new SelectList(_context.DangerousCases, "ID", "Email");
            return Page();
        }

        [BindProperty]
        public Alert Alert { get; set; }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Alerts.Add(Alert);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
