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

namespace Project334.Pages.Vaccines
{
    [Authorize(Roles = "Admin,Medical,Government")]
    public class IndexModel : PageModel
    {
        private readonly Project334.Data.Project334Context _context;

        public IndexModel(Project334.Data.Project334Context context)
        {
            _context = context;
        }

        public IList<Vaccine> Vaccine { get;set; }

        public async Task OnGetAsync()
        {
            Vaccine = await _context.Vaccines
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
