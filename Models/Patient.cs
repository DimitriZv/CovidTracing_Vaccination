using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project334.Models
{
    public class Patient : Person
    {
        public override int ID { get; set; }
        public override string MobilePhone { get; set; }
        public override string LastName { get; set; }
        public override string FirstMidName { get; set; }
        public override string Email { get; set; }

        [Required(ErrorMessage = "The HadVirus is required")]
        [Display(Name = "Had virus?")]
        public bool HadVirus { get; set; } = false;

        /*[Required(ErrorMessage = "The Eligibility to Vaccination is required")]
        [Display(Name = "Eligible To Vaccination?")]
        public bool EligibilityToVaccine { get; set; }*/

        public virtual ICollection<Vaccine> Vaccines { get; set; }
    }
}
