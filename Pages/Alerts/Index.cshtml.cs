using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project334.Data;
using Project334.Models;

namespace Project334.Pages.Alerts
{
    public class IndexModel : PageModel
    {
        private readonly Project334.Data.Project334Context _context;
        
        public IndexModel(Project334.Data.Project334Context context)
        {
            _context = context;
        }
        
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public IList<Alert> Alert { get;set; }

        public async Task OnGetAsync(string sortOrder)
        {
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            IQueryable<Alert> alertsIQ = from s in _context.Alerts
                                         select s;
            IQueryable<VisitorCheckIn> visitorCheckInQ = from s in _context.VisitorsCheckIn
                                                         select s;
            IQueryable<VisitorCheckOut> visitorCheckOutQ = from s in _context.VisitorsCheckOut
                                                           select s;

            switch (sortOrder)
            {
                case "Date":
                    alertsIQ = alertsIQ.OrderBy(s => s.DangerousCase.ConfirmDate);
                    break;
                case "date_desc":
                    alertsIQ = alertsIQ.OrderByDescending(s => s.DangerousCase.ConfirmDate);
                    break;
                default:
                    alertsIQ = alertsIQ.OrderBy(s => s.DangerousCase.ConfirmDate);
                    break;
            }

            Alert = await alertsIQ.Include(a => a.DangerousCase)
                                    .ThenInclude(s => s.VisitedPlaces)
                                    .AsNoTracking()
                                    .ToListAsync();

            /*Alert = await _context.Alerts
                .Include(a => a.DangerousCase)
                    .ThenInclude(s => s.VisitedPlaces)
                .AsNoTracking()
                .ToListAsync();*/
        }
    }
}
