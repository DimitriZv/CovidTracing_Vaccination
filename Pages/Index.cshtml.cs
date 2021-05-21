using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project334.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project334.ViewModels;

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
        public IList<Patient> Patients { get; set; }
        public IList<MedicalInstitution> MedicalInstitutions { get; set; }
        public IList<Vaccine> Vaccines { get; set; }
        public IList<VisitorCheckIn> VisitorsCheckIn { get; set; }
        public IList<VisitorCheckOut> VisitorsCheckOut { get; set; }
        public IList<BusinessActivity> BusinessActivities { get; set; }

        public int DangCaseCount { get; set; }
        public int DangCaseCountNSW { get; set; }
        public int DangCaseCountACT { get; set; }
        public int DangCaseCountWA { get; set; }
        public int DangCaseCountQLD { get; set; }
        public int DangCaseCountSA { get; set; }
        public int DangCaseCountVIC { get; set; }

        public async Task OnGetAsync(string searchString, string category)
        {
            CurrentFilter = searchString;
            CurrentFilterCase = category;

            IQueryable<Business> businessIQ = from s in _context.Businesses
                                              select s;

            IQueryable<DangerousCase> dangerousCaseIQ = from s in _context.DangerousCases
                                                   select s;

            IQueryable<Patient> patientIQ = from s in _context.Patients
                                            select s;

            IQueryable<MedicalInstitution> medicalInstitutionsIQ = from s in _context.MedicalInstitutions
                                                                  select s;

            IQueryable<Vaccine> VaccinesQ = from s in _context.Vaccines
                                            select s;

            IQueryable<VisitorCheckIn> visitorCheckInQ = from s in _context.VisitorsCheckIn
                                                         select s;
            IQueryable<VisitorCheckOut> visitorCheckOutQ = from s in _context.VisitorsCheckOut
                                                           select s;
            IQueryable<AddressDate> addressDatesQ = from s in _context.AddressDates
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
            else if (!String.IsNullOrEmpty(searchString) && category == "Patient")
            {
                patientIQ = patientIQ.Where(s => s.LastName.ToUpper().Contains(searchString.ToUpper()));
                Patients = await patientIQ.Distinct().AsNoTracking().ToListAsync();
            }
            else if (!String.IsNullOrEmpty(searchString) && category == "Medical")
            {
                medicalInstitutionsIQ = medicalInstitutionsIQ.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()));
                MedicalInstitutions = await medicalInstitutionsIQ.AsNoTracking().ToListAsync();
            }
            else if (!String.IsNullOrEmpty(searchString) && category == "Vaccine")
            {
                VaccinesQ = VaccinesQ.Where(s => s.Number.ToUpper().Contains(searchString.ToUpper()));
                Vaccines = await VaccinesQ.AsNoTracking().ToListAsync();
            }
            else if (!String.IsNullOrEmpty(searchString) && category == "Visitor")
            {
                visitorCheckInQ = visitorCheckInQ.Where(s => s.LastName.ToUpper().Contains(searchString.ToUpper()));
                VisitorsCheckIn = await visitorCheckInQ.AsNoTracking().ToListAsync();

                visitorCheckOutQ = visitorCheckOutQ.Where(s => s.LastName.ToUpper().Contains(searchString.ToUpper()));
                VisitorsCheckOut = await visitorCheckOutQ.AsNoTracking().ToListAsync();
            }

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
