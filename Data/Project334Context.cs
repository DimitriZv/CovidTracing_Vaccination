using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Bogus.Extensions;
using Microsoft.EntityFrameworkCore;
using Project334.Models;

namespace Project334.Data
{
    public class Project334Context : DbContext
    {
        public Project334Context (DbContextOptions<Project334Context> options)
            : base(options)
        {
        }

        public DbSet<Business> Businesses { get; set; }
        public DbSet<VisitorCheckIn> VisitorsCheckIn { get; set; }
        public DbSet<VisitorCheckOut> VisitorsCheckOut { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<BusinessActivity> BusinessActivities { get; set; }
        public DbSet<DangerousCase> DangerousCases { get; set; }
        public DbSet<PersonP> Persons { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<BookAppointment> BookAppointments { get; set; }
        public DbSet<MedicalInstitution> MedicalInstitutions { get; set; }
        public DbSet<AddressDate> AddressDates { get; set; }
        public DbSet<Alert> Alerts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var city = new[] {"Ballarat","Darwin","Toowoomba","Cairns","Townsville","Hobart","Gelong","Wollongong","Central Coast","Sunshine Coast","Sydney","Brisbane","Melbourne","Perth","Adelaide","Gold Coast","Newcastle","Canberra"};
            var state = new[] {"NSW","ACT","QLD","VIC","WA","SA","NT","TAS"};
            var country = new[] { "Australia" };
            var comment = new[] { "any day" };
            var vaccinesName = new[] { "Pfizer-BioNTech", "Moderna", "Janssen", "Spitnk" };

            var ids = 1;
            var business = new Faker<Business>()
                .StrictMode(true)
                .RuleFor(m => m.ID, f => ids++)
                .RuleFor(m => m.StreetNumber, f => f.Address.BuildingNumber())
                .RuleFor(m => m.StreetName, f => f.Address.StreetName())
                .RuleFor(m => m.ZipCode, f => f.Random.Number(1000, 9999))
                .RuleFor(m => m.City, f => f.PickRandom(city))
                .RuleFor(m => m.State, f => f.PickRandom(state))
                .RuleFor(m => m.Name, f => f.Company.CompanyName())
                .RuleFor(m => m.Phone, f => f.Finance.Account(10))
                .RuleFor(m => m.ABN, f => f.Finance.Account(11))
                .RuleFor(m => m.Email, f => f.Internet.Email())
                .RuleFor(m => m.Country, f => f.PickRandom(country))
                .RuleFor(m => m.DailyActivities, f => null);

            var idBA = 1;
            var businessActivities = new Faker<BusinessActivity>()
                .StrictMode(true)
                .RuleFor(m => m.BusinessActivityID, f => idBA++)
                .RuleFor(m => m.BusinessID, f => f.Random.Number(1, 1000))
                .RuleFor(m => m.WorkingDate, f => f.Date.Between(DateTime.Parse("1/1/2021 12:00 AM"), DateTime.Parse("26/5/2020 12:01 AM")))
                .RuleFor(m => m.VisitorCheckIn, f => null)
                .RuleFor(m => m.VisitorCheckOut, f => null);

            var idVisIn = 1;
            var visitorsCheckIn = new Faker<VisitorCheckIn>()
                .StrictMode(true)
                .RuleFor(m => m.ID, f => idVisIn++)
                .RuleFor(m => m.BusinessActivityID, f => f.Random.Number(1, 3000))
                .RuleFor(m => m.MobilePhone, f => f.Finance.Account(10))
                .RuleFor(u => u.FirstMidName, (f, u) => f.Name.FirstName())
                .RuleFor(u => u.LastName, (f, u) => f.Name.LastName())
                .RuleFor(m => m.Email, f => f.Internet.Email())
                .RuleFor(m => m.CheckIn, f => f.Date.Between(DateTime.Parse("1/1/2020 12:00 AM"), DateTime.Parse("26/5/2021 12:00 AM")));

            var idVisOut = 10001;
            var visitorsCheckOut = new Faker<VisitorCheckOut>()
                .StrictMode(true)
                .RuleFor(m => m.ID, f => idVisOut++)
                .RuleFor(m => m.BusinessActivityID, f => f.Random.Number(1, 3000))
                .RuleFor(m => m.MobilePhone, f => f.Finance.Account(10))
                .RuleFor(u => u.FirstMidName, (f, u) => f.Name.FirstName())
                .RuleFor(u => u.LastName, (f, u) => f.Name.LastName())
                .RuleFor(m => m.Email, f => f.Internet.Email())
                .RuleFor(m => m.CheckOut, f => f.Date.Between(DateTime.Parse("1/1/2020 12:00 AM"), DateTime.Parse("26/5/2021 12:00 AM")));

            var idDanCas = 20001;
            var dangCases = new Faker<DangerousCase>()
                .StrictMode(true)
                .RuleFor(m => m.ID, f => idDanCas++)
                .RuleFor(m => m.MobilePhone, f => f.Finance.Account(10))
                .RuleFor(u => u.FirstMidName, (f, u) => f.Name.FirstName())
                .RuleFor(u => u.LastName, (f, u) => f.Name.LastName())
                .RuleFor(m => m.Email, f => f.Internet.Email())
                .RuleFor(m => m.City, f => f.PickRandom(city))
                .RuleFor(m => m.State, f => f.PickRandom(state))
                .RuleFor(m => m.DOB, f => f.Date.Between(DateTime.Parse("1/1/1960 12:00 AM"), DateTime.Parse("26/5/2021 12:00 AM")))
                .RuleFor(u => u.Sex, f => f.PickRandom(Sex.Male,Sex.Female))
                .RuleFor(m => m.ConfirmDate, f => f.Date.Between(DateTime.Parse("1/1/2020 12:00 AM"), DateTime.Parse("26/5/2021 12:00 AM")))
                .RuleFor(u => u.HasVaccine, f => f.PickRandom(true,false))
                .RuleFor(m => m.VisitedPlaces, f => null);

            var idMedical= 1001;
            var medical = new Faker<MedicalInstitution>()
                .StrictMode(true)
                .RuleFor(m => m.ID, f => idMedical++)
                .RuleFor(m => m.StreetNumber, f => f.Address.BuildingNumber())
                .RuleFor(m => m.StreetName, f => f.Address.StreetName())
                .RuleFor(m => m.City, f => f.PickRandom(city))
                .RuleFor(m => m.State, f => f.PickRandom(state))
                .RuleFor(m => m.ZipCode, f => f.Random.Number(1000, 9999))
                .RuleFor(m => m.Country, f => f.PickRandom(country))
                .RuleFor(m => m.Name, f => f.Company.CompanyName())
                .RuleFor(m => m.Phone, f => f.Finance.Account(10))
                .RuleFor(m => m.Email, f => f.Internet.Email())
                .RuleFor(m => m.Appointment, f => null);

            /*var patId = 21001;
            var patients = new Faker<Patient>()
                .StrictMode(true)
                .RuleFor(m => m.ID, f => patId++)
                .RuleFor(m => m.MobilePhone, f => f.Finance.Account(10))
                .RuleFor(u => u.FirstMidName, (f, u) => f.Name.FirstName())
                .RuleFor(u => u.LastName, (f, u) => f.Name.LastName())
                .RuleFor(m => m.Email, f => f.Internet.Email())
                .RuleFor(m => m.DOB, f => f.Date.Between(DateTime.Parse("1/1/1960 12:00 AM"), DateTime.Parse("26/5/2021 12:00 AM")))
                .RuleFor(u => u.HadVirus, f => f.PickRandom(true))
                .RuleFor(m => m.Comment, f => f.PickRandom(comment))
                .RuleFor(m => m.Vaccines, f => null);

            var idBookApp = 1;
            var bookApps = new Faker<BookAppointment>()
                .StrictMode(true)
                .RuleFor(m => m.BookAppointmentID, f => idBookApp++)
                .RuleFor(m => m.MedicalInstitutionID, f => f.Random.Number(1, 1000))
                //.RuleFor(m => m.Patient, () => patients)
                //.RuleFor(m => m.Patient, f => f.PickRandom(patients))
                .RuleFor(m => m.Patient, f => patients.Generate())
                .RuleFor(m => m.Medicare, f => f.Finance.Account(10))
                .RuleFor(u => u.EligibilityToVaccine, f => f.PickRandom(true));

            var idVaccine = 1;
            var vaccines = new Faker<Vaccine>()
                .StrictMode(true)
                .RuleFor(m => m.VaccineID, f => idVaccine++)
                .RuleFor(m => m.Name, f => f.PickRandom(vaccinesName))
                .RuleFor(m => m.Number, f => f.Finance.Account(11))
                .RuleFor(m => m.ProductionDate, f => f.Date.Between(DateTime.Parse("1/1/2021 12:00 AM"), DateTime.Parse("26/5/2021 12:00 AM")))
                .RuleFor(m => m.PatientID, f => f.Random.Number(1, 1000));

            /*var idApps = 1;
            var apps = new Faker<Appointment>()
                .StrictMode(true)
                .RuleFor(m => m.AppointmentID, f => idApps++)
                .RuleFor(m => m.MedicalInstitutionID, f => f.Random.Number(1, 1000))
                //.RuleFor(m => m.BookAppointment, f => f.PickRandom(bookApps))
                //.RuleFor(m => m.BookAppointmentID, f => f.Random.Number(1, 1000))
                .RuleFor(x => x.BookAppointment, () => bookApps)
                //.RuleFor(x => x.BookAppointmentID, (f, o) => o.BookAppointment.BookAppointmentID)
                .RuleFor(x => x.BookAppointmentID, f => idApps)

                .RuleFor(m => m.Vaccine, f => f.PickRandom(vaccines))
                .RuleFor(m => m.AppointmentDate, f => f.Date.Between(DateTime.Parse("1/1/2021 12:00 AM"), DateTime.Parse("26/5/2021 12:00 AM")))
                .RuleFor(m => m.EligibilityToVaccine, f => f.PickRandom(true));*/


            modelBuilder.Entity<PersonP>().ToTable("Person");
            modelBuilder.Entity<Address>().ToTable("Address");
            modelBuilder.Entity<Alert>().ToTable("Alert");
            modelBuilder.Entity<AddressDate>().ToTable("AddressDate");

            modelBuilder.Entity<MedicalInstitution>().ToTable("MedicalInstitution")
                .HasData(medical.GenerateBetween(1000, 1000));

            modelBuilder.Entity<BookAppointment>().ToTable("BookAppointment");
                //.HasData(bookApps.GenerateBetween(1000, 1000));

            modelBuilder.Entity<Appointment>().ToTable("Appointment");
            //.HasData(apps.GenerateBetween(1000, 1000));

            modelBuilder.Entity<Patient>().ToTable("Patient");
                //.HasData(patients.GenerateBetween(1000, 1000));

            modelBuilder.Entity<Vaccine>().ToTable("Vaccine");
                //.HasData(vaccines.GenerateBetween(1000, 1000));

            modelBuilder.Entity<Business>().ToTable("Business")
                .HasData(business.GenerateBetween(1000, 1000));
            
            modelBuilder.Entity<BusinessActivity>().ToTable("BusinessActivity")
                .HasData(businessActivities.GenerateBetween(3000, 3000));

            modelBuilder.Entity<VisitorCheckIn>().ToTable("VisitorCheckIn")
                .HasData(visitorsCheckIn.GenerateBetween(10000, 10000));

            modelBuilder.Entity<VisitorCheckOut>().ToTable("VisitorCheckOut")
               .HasData(visitorsCheckOut.GenerateBetween(10000, 10000));

            modelBuilder.Entity<DangerousCase>().ToTable("DangerousCase")
                .HasData(dangCases.GenerateBetween(1000, 1000));
        }
    }
}
