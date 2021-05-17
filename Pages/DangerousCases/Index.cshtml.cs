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

namespace Project334.Pages.DangerousCases
{
    [Authorize(Roles = "Admin,Government")]
    public class IndexModel : PageModel
    {
        private readonly Project334.Data.Project334Context _context;

        public IndexModel(Project334.Data.Project334Context context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<DangerousCase> DangerousCases { get;set; }

        public async Task OnGetAsync(string sortOrder)
        {
            // using System;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            IQueryable<DangerousCase> dangerCaseIQ = from s in _context.DangerousCases
                                             select s;
            switch (sortOrder)
            {
                case "name_desc":
                    dangerCaseIQ = dangerCaseIQ.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    dangerCaseIQ = dangerCaseIQ.OrderBy(s => s.ConfirmDate);
                    break;
                case "date_desc":
                    dangerCaseIQ = dangerCaseIQ.OrderByDescending(s => s.ConfirmDate);
                    break;
                default:
                    dangerCaseIQ = dangerCaseIQ.OrderBy(s => s.LastName);
                    break;
            }

            DangerousCases = await dangerCaseIQ.AsNoTracking().ToListAsync();
        }
    }
}
