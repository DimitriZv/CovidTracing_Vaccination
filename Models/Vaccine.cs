using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project334.Models
{
    public class Vaccine
    {
        [Key]
        public int VaccineID { get; set; }

        public int PatientID { get; set; }

        [Required(ErrorMessage = "The Vaccine name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Vaccine Name cannot be longer than 30 characters")]
        [RegularExpression("^[a-zA-Z]+(?:s+[a-zA-Z]+)*$", ErrorMessage = "Vaccine Name is not valid")]
        [Display(Name = "Vaccine Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Vaccine Number is required")]
        [StringLength(11, ErrorMessage = "Vaccine Number cannot be longer than 12 characters")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Vaccine Number is not valid")]     // upper cases   ^[A-Z][a-zA-Z0-9]*$
        [Display(Name = "Vaccine Number")]
        public string Number { get; set; }

        [Required(ErrorMessage = "The Production Date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Production Date")]
        public DateTime ProductionDate { get; set; }
    }
}
