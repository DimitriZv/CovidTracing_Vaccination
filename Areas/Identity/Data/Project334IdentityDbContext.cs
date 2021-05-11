using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project334.Data;

namespace Project334.Areas.Identity.Data
{
    public class Project334IdentityDbContext : IdentityDbContext<Project334Users>
    {
        public Project334IdentityDbContext(DbContextOptions<Project334IdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
