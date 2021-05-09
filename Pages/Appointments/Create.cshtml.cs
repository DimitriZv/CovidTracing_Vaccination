using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project334.Data;
using Project334.Models;

namespace Project334.Pages.Appointments
{
    public class CreateModel : PageModel
    {
        private readonly Project334.Data.Project334Context _context;

        public CreateModel(Project334.Data.Project334Context context)
        {
            _context = context;
        }
        
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Appointment Appointment { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if(Appointment.BookAppointment.Patient.HadVirus == true || Appointment.BookAppointment.EligibilityToVaccine == false)
            {
                if (Appointment.BookAppointment.Patient.HadVirus == true) {
                    ModelState.AddModelError("Appointment.BookAppointment.Patient.HadVirus", "Not eligible to vaccination, because of the previous infection");
                    return Page();
                }
                else if(Appointment.BookAppointment.EligibilityToVaccine == false)
                {
                    ModelState.AddModelError("Appointment.BookAppointment.EligibilityToVaccine", "Not eligible to vaccination, based on the link provided");
                    return Page();
                }  
            }

            if (Appointment.EligibilityToVaccine == false)
            {
                ModelState.AddModelError("Appointment.EligibilityToVaccine", "Not eligible to vaccination by medical staff decision");
                return Page();
            }
            
            _context.Appointments.Add(Appointment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
