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
using Project334.Data;
using Project334.Models;

namespace Project334.Pages.Businesses
{
    [Authorize(Roles = "Admin,Government,Bussiness")]
    public class IndexModel : PageModel
    {
        private readonly Project334.Data.Project334Context _context;

        public IndexModel(Project334.Data.Project334Context context)
        {
            _context = context;
        }

        public IList<Business> Business { get;set; }

        public async Task OnGetAsync()
        {
            var contacts = from c in _context.Businesses
                           select c;

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userName = User.FindFirstValue(ClaimTypes.Name); //should be an email

            if (User.IsInRole("Admin") || User.IsInRole("Government"))
            {
            
            } else if (User.IsInRole("Bussiness"))
            {
                contacts = contacts.Where(c => c.Email == userName);
            }
            
            Business = await contacts.ToListAsync();
            //Business = await _context.Businesses.ToListAsync();
        }
    }
}
