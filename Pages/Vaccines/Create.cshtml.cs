using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project334.Data;
using Project334.Models;

namespace Project334.Pages.Vaccines
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
        public Vaccine Vaccine { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Vaccines.Add(Vaccine);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
