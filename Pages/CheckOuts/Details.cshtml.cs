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
    public class DetailsModel : PageModel
    {
        private readonly Project334.Data.Project334Context _context;

        public DetailsModel(Project334.Data.Project334Context context)
        {
            _context = context;
        }

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
    }
}
