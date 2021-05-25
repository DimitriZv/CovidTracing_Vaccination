using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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
            //States
        public int DangCaseCount { get; set; }
        public int DangCaseCountNSW { get; set; }
        public int DangCaseCountACT { get; set; }
        public int DangCaseCountWA { get; set; }
        public int DangCaseCountQLD { get; set; }
        public int DangCaseCountSA { get; set; }
        public int DangCaseCountVIC { get; set; }
        public int DangCaseCountTAS { get; set; }
        public int DangCaseCountNT { get; set; }

            //Cities
        public int MelDangCaseCount { get; set; }
        public int SydDangCaseCount { get; set; }
        public int BriDangCaseCount { get; set; }
        public int PerthDangCaseCount { get; set; }
        public int AdelaidDangCaseCount { get; set; }
        public int GoaldCoastDangCaseCount { get; set; }
        public int NewcastDangCaseCount { get; set; }
        public int CanberraDangCaseCount { get; set; }
        public int SunshineCoastCaseCount { get; set; }
        public int CentralCoastDangCaseCount { get; set; }
        public int WolongDangCaseCount { get; set; }
        public int GelongDangCaseCount { get; set; }
        public int HobartDangCaseCount { get; set; }
        public int TownsvilleDangCaseCount { get; set; }
        public int CairnsDangCaseCount { get; set; }
        public int ToowoombaDangCaseCount { get; set; }
        public int DarwinDangCaseCount { get; set; }
        public int BallaratDangCaseCount { get; set; }
        
            //Vaccines
        public int VaccinesDone { get; set; }
        public int VaccinesDoneNSW { get; set; }
        public int VaccinesDoneVIC { get; set; }
        public int VaccinesDoneACT { get; set; }
        public int VaccinesDoneWA { get; set; }
        public int VaccinesDoneQLD { get; set; }
        public int VaccinesDoneSA { get; set; }
        public int VaccinesDoneTAS { get; set; }
        public int VaccinesDoneNT { get; set; }


        public int TotalHospitals { get; set; }
        public int TotalBussinesses{ get; set; }
        public int TotalCheckIn { get; set; }
        public int TotalCheckOut { get; set; }
        public int TotalDangAddresses { get; set; }

        public IList<MedicalInstitution> MedicalInstitutions { get; set; }
        public MedicalInstitution MedicalInstitution { get; set; }
        public Patient Patient { get; set; }
        public IList<Appointment> Appointments { get; set; }

        public void OnGet()
        {
            IQueryable<DangerousCase> dangerousCaseIQ = from s in _context.DangerousCases
                                                        select s;
            IQueryable<Vaccine> vaccineQ = from s in _context.Vaccines
                                           select s;
            IQueryable<MedicalInstitution> medicalInstitutionQ = from s in _context.MedicalInstitutions
                                                                 select s;
            IQueryable<Business> businessQ = from s in _context.Businesses
                                                                 select s;
            IQueryable<VisitorCheckIn> visitorCheckInQ = from s in _context.VisitorsCheckIn
                                                   select s;
            IQueryable<VisitorCheckOut> visitorCheckOutQ = from s in _context.VisitorsCheckOut
                                                           select s;
            IQueryable<AddressDate> dangAddressQ = from s in _context.AddressDates
                                                   select s;
            IQueryable<Appointment> appointmentQ = from s in _context.Appointments
                                                   select s;
            IQueryable<Patient> patientsQ = from s in _context.Patients
                                            select s;

            DangCaseCountNSW = dangerousCaseIQ.Count(s => s.State.ToUpper().Contains("NSW"));
            DangCaseCountVIC = dangerousCaseIQ.Count(s => s.State.ToUpper().Contains("VIC"));
            DangCaseCountSA = dangerousCaseIQ.Count(s => s.State.ToUpper().Contains("SA"));
            DangCaseCountACT = dangerousCaseIQ.Count(s => s.State.ToUpper().Contains("ACT"));
            DangCaseCountQLD = dangerousCaseIQ.Count(s => s.State.ToUpper().Contains("QLD"));
            DangCaseCountWA = dangerousCaseIQ.Count(s => s.State.ToUpper().Contains("WA"));
            DangCaseCountTAS = dangerousCaseIQ.Count(s => s.State.ToUpper().Contains("TAS"));
            DangCaseCountNT = dangerousCaseIQ.Count(s => s.State.ToUpper().Contains("NT"));
            DangCaseCount = dangerousCaseIQ.Count();

            MelDangCaseCount = dangerousCaseIQ.Count(s => s.City.ToUpper().Contains("Melbourne"));
            SydDangCaseCount = dangerousCaseIQ.Count(s => s.City.ToUpper().Contains("Sydney"));
            BriDangCaseCount = dangerousCaseIQ.Count(s => s.City.ToUpper().Contains("Brisbane"));
            PerthDangCaseCount = dangerousCaseIQ.Count(s => s.City.ToUpper().Contains("Perth"));
            AdelaidDangCaseCount = dangerousCaseIQ.Count(s => s.City.ToUpper().Contains("Adelaide"));
            GoaldCoastDangCaseCount = dangerousCaseIQ.Count(s => s.City.ToUpper().Contains("Gold Coast"));
            NewcastDangCaseCount = dangerousCaseIQ.Count(s => s.City.ToUpper().Contains("Newcastle"));
            CanberraDangCaseCount = dangerousCaseIQ.Count(s => s.City.ToUpper().Contains("Canberra"));
            SunshineCoastCaseCount = dangerousCaseIQ.Count(s => s.City.ToUpper().Contains("Sunshine Coast"));
            CentralCoastDangCaseCount = dangerousCaseIQ.Count(s => s.City.ToUpper().Contains("Central Coast"));
            WolongDangCaseCount = dangerousCaseIQ.Count(s => s.City.ToUpper().Contains("Wollongong"));
            GelongDangCaseCount = dangerousCaseIQ.Count(s => s.City.ToUpper().Contains("Gelong"));
            HobartDangCaseCount = dangerousCaseIQ.Count(s => s.City.ToUpper().Contains("Hobart"));
            TownsvilleDangCaseCount = dangerousCaseIQ.Count(s => s.City.ToUpper().Contains("Townsville"));
            CairnsDangCaseCount = dangerousCaseIQ.Count(s => s.City.ToUpper().Contains("Cairns"));
            ToowoombaDangCaseCount = dangerousCaseIQ.Count(s => s.City.ToUpper().Contains("Toowoomba"));
            DarwinDangCaseCount = dangerousCaseIQ.Count(s => s.City.ToUpper().Contains("Darwin"));
            BallaratDangCaseCount = dangerousCaseIQ.Count(s => s.City.ToUpper().Contains("Ballarat"));

            VaccinesDone = vaccineQ.Count();
            VaccinesDoneNSW = CountVaccines(medicalInstitutionQ, appointmentQ, "NSW");
            VaccinesDoneQLD = CountVaccines(medicalInstitutionQ, appointmentQ, "QLD");

            /*VaccinesDoneVIC
            VaccinesDoneACT 
            VaccinesDoneWA 
            VaccinesDoneSA 
            VaccinesDoneTAS 
            VaccinesDoneNT */




            TotalHospitals = medicalInstitutionQ.Count();
            TotalBussinesses = businessQ.Count();
            TotalCheckIn = visitorCheckInQ.Count();
            TotalCheckOut = visitorCheckOutQ.Count();
            TotalDangAddresses = dangAddressQ.Count();
        }

        public int CountVaccines(IQueryable<MedicalInstitution> MedicalInstitutions, IQueryable<Appointment> Appointments, string state)
        {
            int countCases = 0;
            foreach (var item in MedicalInstitutions)
            {
                if (item.State.ToUpper().Contains(state))
                {
                    foreach (var item1 in Appointments)
                    {
                        if (item.ID == item1.MedicalInstitutionID)
                        {
                            countCases++;
                        }
                    }
                }
            }
            return countCases;
        }
    }
}


