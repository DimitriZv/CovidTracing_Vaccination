using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project334.Data;
using Project334.Models;

namespace Project334.Pages.Businesses
{
    public class DetailsModel : PageModel
    {
        private readonly Project334.Data.Project334Context _context;

        public DetailsModel(Project334.Data.Project334Context context)
        {
            _context = context;
        }

        public Business Business { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Business = await _context.Businesses.FirstOrDefaultAsync(m => m.ID == id);
            Business = await _context.Businesses
                .Include(s => s.CompanyAddress)
                .Include(e => e.DailyActivities)
                //.ThenInclude(d => d.VisitorCheckIn)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.BusinessID == id);

            if (Business == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
