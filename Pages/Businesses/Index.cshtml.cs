using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project334.Areas.Identity.Data;
using Microsoft.Extensions.Configuration;
using Project334.Data;
using Project334.Models;

namespace Project334.Pages.Businesses
{
    [Authorize(Roles = "Admin,Government,Bussiness")]
    public class IndexModel : PageModel
    {
        private readonly Project334.Data.Project334Context _context;
        private readonly IConfiguration Configuration;

        public IndexModel(Project334.Data.Project334Context context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        //public IList<Business> Business { get;set; }

        public PaginatedList<Business> Business { get; set; }
        public int pageSizeView { get; set; }

        public string NameSort { get; set; }
        public string CitySort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            CitySort = sortOrder == "City" ? "city_desc" : "City";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            IQueryable<Business> contacts = from s in _context.Businesses
                                              select s;


            if (!String.IsNullOrEmpty(searchString))
            {
                contacts = contacts.Where(s => s.Name.Contains(searchString)
                                       || s.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    contacts = contacts.OrderByDescending(s => s.Name);
                    break;
                case "City":
                    contacts = contacts.OrderBy(s => s.City);
                    break;
                case "city_desc":
                    contacts = contacts.OrderByDescending(s => s.City);
                    break;
                default:
                    contacts = contacts.OrderBy(s => s.Name);
                    break;
            }


            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userName = User.FindFirstValue(ClaimTypes.Name); //should be an email

            if (User.IsInRole("Admin") || User.IsInRole("Government"))
            {
            
            } else if (User.IsInRole("Bussiness"))
            {
                contacts = contacts.Where(c => c.Email == userName);
            }

            var pageSize = Configuration.GetValue("PageSize", 50);
            pageSizeView = pageSize;
            Business = await PaginatedList<Business>.CreateAsync(
                contacts.AsNoTracking(), pageIndex ?? 1, pageSize);
            
            //Business = await contacts.ToListAsync();
            //Business = await _context.Businesses.ToListAsync();
        }
    }
}
