using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project334.Models;
using Project334.ViewModels;

namespace Project334.Pages
{
    public class StatisticsModel : PageModel
    {
        private readonly Project334.Data.Project334Context _context;

        public StatisticsModel(Project334.Data.Project334Context context)
        {
            _context = context;
        }

        public int DangCaseCount { get; set; }
        public int DangCaseCountNSW { get; set; }
        public int DangCaseCountACT { get; set; }
        public int DangCaseCountWA { get; set; }
        public int DangCaseCountQLD { get; set; }
        public int DangCaseCountSA { get; set; }
        public int DangCaseCountVIC { get; set; }

        public void OnGet()
        {
            IQueryable<DangerousCase> dangerousCaseIQ = from s in _context.DangerousCases
                                                        select s;

            DangCaseCountNSW = dangerousCaseIQ.Count(s => s.State.ToUpper().Contains("NSW"));
            DangCaseCountVIC = dangerousCaseIQ.Count(s => s.State.ToUpper().Contains("VIC"));
            DangCaseCountSA = dangerousCaseIQ.Count(s => s.State.ToUpper().Contains("SA"));
            DangCaseCountACT = dangerousCaseIQ.Count(s => s.State.ToUpper().Contains("ACT"));
            DangCaseCountQLD = dangerousCaseIQ.Count(s => s.State.ToUpper().Contains("QLD"));
            DangCaseCountWA = dangerousCaseIQ.Count(s => s.State.ToUpper().Contains("WA"));
            DangCaseCount = dangerousCaseIQ.Count();
        }
    }
}
