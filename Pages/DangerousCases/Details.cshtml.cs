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
    //[Authorize(Roles = "Admin,Government")]
    public class DetailsModel : PageModel
    {
        private readonly Project334.Data.Project334Context _context;

        public DetailsModel(Project334.Data.Project334Context context)
        {
            _context = context;
        }

        public DangerousCase dangerousCase { get; set; }
        public IList<VisitorCheckIn> visitorsCheckIn { get; set; }
        public IList<VisitorCheckOut> visitorsCheckOut { get; set; }

        /*public IList<AddressDate> AddressDates { get; set; }
        public IList<BusinessActivity> businessActivities { get; set; }*/

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IQueryable<VisitorCheckIn> visitorCheckInQ = from s in _context.VisitorsCheckIn
                                                         select s;
            IQueryable<VisitorCheckOut> visitorCheckOutQ = from s in _context.VisitorsCheckOut
                                                           select s;
            IQueryable<DangerousCase> dangerousCaseQ = from s in _context.DangerousCases
                                                           select s;

            /*IQueryable<BusinessActivity> businessActivitiesQ = from s in _context.BusinessActivities
                                                               select s;
            IQueryable<AddressDate> addressDateQ = from s in _context.AddressDates
                                                               select s;*/

            DangerousCase find = dangerousCaseQ.FirstOrDefault(s => s.ID == id);
            string lastNameDangCase = find.LastName;

            visitorCheckInQ = visitorCheckInQ.Where(s => s.LastName.ToUpper().Contains(lastNameDangCase.ToUpper()));
            visitorsCheckIn = await visitorCheckInQ.AsNoTracking().ToListAsync();

            visitorCheckOutQ = visitorCheckOutQ.Where(s => s.LastName.ToUpper().Contains(lastNameDangCase.ToUpper()));
            visitorsCheckOut = await visitorCheckOutQ.AsNoTracking().ToListAsync();

            dangerousCase = await _context.DangerousCases
                .Include(s => s.VisitedPlaces)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (dangerousCase == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
