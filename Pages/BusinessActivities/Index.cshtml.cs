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
    [Authorize(Roles = "Admin,Government,Bussiness")]
    public class IndexModel : PageModel
    {
        private readonly Project334.Data.Project334Context _context;

        public IndexModel(Project334.Data.Project334Context context)
        {
            _context = context;
        }

        public IList<BusinessActivity> BusinessActivity { get;set; }

        public async Task OnGetAsync()
        {
            BusinessActivity = await _context.BusinessActivities.ToListAsync();
        }
    }
}
