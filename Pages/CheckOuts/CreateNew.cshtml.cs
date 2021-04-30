using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project334.Data;
using Project334.Models;

namespace Project334.Pages.CheckOuts
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
        public VisitorCheckOut VisitorCheckOut { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.VisitorsCheckOut.Add(VisitorCheckOut);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
