using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project334.Data;
using Project334.Models;

namespace Project334.Pages.MedicalInstitutions
{
    public class IndexModel : PageModel
    {
        private readonly Project334.Data.Project334Context _context;

        public IndexModel(Project334.Data.Project334Context context)
        {
            _context = context;
        }

        public IList<MedicalInstitution> MedicalInstitution { get;set; }

        public async Task OnGetAsync()
        {
            //MedicalInstitution = await _context.MedicalInstitutions.ToListAsync();
            MedicalInstitution = await _context.MedicalInstitutions
                .Include(s => s.MedicalAddress)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
