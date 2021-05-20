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
        /*public enum City
        {
            Sydney,Brisbane,Melbourne,Perth,Adelaide,GoldCoast,Newcastle
        }*/
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
            var city = new[] { "Sydney", "Brisbane", "Melbourne", "Perth", "Adelaide", "GoldCoast", "Newcastle", "Canberra" };
            var state = new[] { "NSW", "ACT", "QLD", "VIC", "WA", "SA" };
            var country = new[] { "Australia" };

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

            modelBuilder.Entity<Alert>().ToTable("Alert");
            modelBuilder.Entity<AddressDate>().ToTable("AddressDate");
            modelBuilder.Entity<MedicalInstitution>().ToTable("MedicalInstitution");
            modelBuilder.Entity<BookAppointment>().ToTable("BookAppointment");
            modelBuilder.Entity<Appointment>().ToTable("Appointment");
            modelBuilder.Entity<Patient>().ToTable("Patient");
            modelBuilder.Entity<Vaccine>().ToTable("Vaccine");
            //modelBuilder.Entity<Business>().ToTable("Business");
            modelBuilder
                .Entity<Business>().ToTable("Business")
                .HasData(business.GenerateBetween(1000, 1000));
            modelBuilder.Entity<VisitorCheckIn>().ToTable("VisitorCheckIn");
            modelBuilder.Entity<VisitorCheckOut>().ToTable("VisitorCheckOut");
            modelBuilder.Entity<Address>().ToTable("Address");
            modelBuilder.Entity<BusinessActivity>().ToTable("BusinessActivity");
            modelBuilder.Entity<DangerousCase>().ToTable("DangerousCase");
            modelBuilder.Entity<PersonP>().ToTable("Person");   
        }
    }
}
