using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project334.Data;
using Microsoft.AspNetCore.Identity;
using Project334.Areas.Identity.Data;

namespace Project334
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

            // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            int MyMaxModelBindingCollectionSize = Convert.ToInt32(
                Configuration["MyMaxModelBindingCollectionSize"] ?? "100");

            
            services.Configure<CookiePolicyOptions>(options =>
            {//added for users
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
            });


            services.AddControllersWithViews();//added for users

            //services.AddRazorPages();

            services.AddDbContext<Project334Context>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("Project334Context")));
            /*services.AddDbContext<Project334Context>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("Project334Context")));
            services.AddDefaultIdentity<IdentityUser>(config =>
            {
                config.SignIn.RequireConfirmedEmail = true;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<Project334IdentityDbContext>();*/

            services.AddAuthorization(config =>
            {
                config.AddPolicy("RequireAdministratorRole",
                    policy => policy.RequireRole("Administrator"));
                config.AddPolicy("RequireMemberRole",
                    policy => policy.RequireRole("Member"));
            });
            
            /////


            services.AddDatabaseDeveloperPageExceptionFilter();

            //add for users
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;//was true
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;//was true
                options.Password.RequireUppercase = false;//was true
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;//was 1

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                
                options.User.RequireUniqueEmail = false;//was false
                //options.User.RequireUniqueEmail = true;//was false
                //options.SignIn.RequireConfirmedEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            }); //added for users


            services.AddRazorPages()
            //.AddNewtonsoftJson()
            .AddRazorPagesOptions(options => {
                options.Conventions.AuthorizePage("/Privacy", "RequireAdministratorRole");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider, UserManager<Project334Users> userManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                    //app.UseDatabaseErrorPage();//added for users
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            
            app.UseRouting();

            app.UseAuthentication();// added for users
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                /*endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");*/
                endpoints.MapRazorPages();
            });

            CreateDatabase(app);
            CreateRolesAsync(serviceProvider).Wait();
            CreateSuperUser(userManager).Wait();
        }
        private async Task CreateSuperUser(UserManager<Project334Users> userManager)
        {
            var userFind = await userManager.FindByEmailAsync("admin@ad.ad");
            if (userFind == null)
            {
                var user = new Project334Users
                {
                    UserName = "admin@ad.ad",
                    Email = "admin@ad.ad"
                };
                string govPassword = "Soarer471!";
                var createPowerUser = await userManager.CreateAsync(user, govPassword);
                if (createPowerUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin"); //here we tie the new user to the role
                }
            }
        }
        /*private async Task CreateSuperUser(UserManager<Project334Users> userManager)
        {
            var userFind = await userManager.FindByEmailAsync("gov@gov.au");
            if (userFind == null)
            {
                var user = new Project334Users
                {
                    UserName = "gov@gov.au",
                    Email = "gov@gov.au"
                };
                string govPassword = "Soarer471!";
                var createPowerUser = await userManager.CreateAsync(user, govPassword);
                if (createPowerUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Government"); //here we tie the new user to the role
                }
            }
        }*/

        private void CreateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<Project334IdentityDbContext>();
                context.Database.EnsureCreated();
            }
        }
        private async Task CreateRolesAsync(IServiceProvider serviceProvider)
        {
            //adding custom roles
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Admin","Government", "Bussiness", "Medical", "Patient", "Visitor" };
            IdentityResult roleResult;
            
            foreach (var roleName in roleNames)
            {
                //creating the roles and seeding them to the database
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }
    }
}