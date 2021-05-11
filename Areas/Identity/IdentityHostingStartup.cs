using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project334.Areas.Identity.Data;
using Project334.Data;

[assembly: HostingStartup(typeof(Project334.Areas.Identity.IdentityHostingStartup))]
namespace Project334.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Project334IdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Project334IdentityDbContextConnection")));

                services.AddDefaultIdentity<Project334Users>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<Project334IdentityDbContext>();
            });
        }
    }
}