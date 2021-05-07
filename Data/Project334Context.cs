using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public DbSet<Person> Persons { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>().ToTable("Appointment");
            modelBuilder.Entity<Patient>().ToTable("Patient");
            modelBuilder.Entity<Vaccine>().ToTable("Vaccine");
            modelBuilder.Entity<Business>().ToTable("Business");
            modelBuilder.Entity<VisitorCheckIn>().ToTable("VisitorCheckIn");
            modelBuilder.Entity<VisitorCheckOut>().ToTable("VisitorCheckOut");
            modelBuilder.Entity<Address>().ToTable("Address");
            modelBuilder.Entity<BusinessActivity>().ToTable("BusinessActivity");
            modelBuilder.Entity<DangerousCase>().ToTable("DangerousCase");
            modelBuilder.Entity<Person>().ToTable("Person");
        }
    }
}
