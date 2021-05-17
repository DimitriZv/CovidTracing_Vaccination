using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project334.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project334.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Project334.Data.Project334Context _context;
        //private readonly ILogger<IndexModel> _logger;

        public IndexModel(Project334.Data.Project334Context context)
        {
            _context = context;
        }
        /*public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }*/

        public string CurrentFilter { get; set; }
        public string CurrentFilterCase { get; set; }
        public IList<Business> Business { get; set; }
        public IList<DangerousCase> DangerousCases { get; set; }

        public async Task OnGetAsync(string searchString, string category)
        {
            CurrentFilter = searchString;
            CurrentFilterCase = category;

            IQueryable<Business> businessIQ = from s in _context.Businesses
                                              select s;

            IQueryable<DangerousCase> dangerousCaseIQ = from s in _context.DangerousCases
                                                   select s;
            
            if (!String.IsNullOrEmpty(searchString) && category == "Business")
            {
                businessIQ = businessIQ.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper())); //|| s.ABN.Contains(searchString));
                Business = await businessIQ.AsNoTracking().ToListAsync();
            } 
            else if (!String.IsNullOrEmpty(searchString) && category == "DangerousCases" && (User.IsInRole("Admin") || User.IsInRole("Government")))
            {
                dangerousCaseIQ = dangerousCaseIQ.Where(s => s.LastName.ToUpper().Contains(searchString.ToUpper()));
                DangerousCases = await dangerousCaseIQ.AsNoTracking().ToListAsync();
            }

            
        }
    }
}
