using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project334.Models
{
    public class AddressDate : Address
    {
        /*public override int ID { get; set; }
        //public override int DangerousCaseID { get; set; }
        [Required(ErrorMessage = "The Street number is required")]
        [StringLength(5)]
        [Display(Name = "Street Number")]
        public override string StreetNumber { get; set; }
        [Required(ErrorMessage = "The Street name is required")]
        [StringLength(50)]
        [Display(Name = "Street Name")]
        public override string StreetName { get; set; }
        [Required(ErrorMessage = "The City address is required")]
        [StringLength(30)]
        public override string City { get; set; }
        [Required(ErrorMessage = "The State address is required")]
        [StringLength(30)]
        public override string State { get; set; }
        [Required(ErrorMessage = "Zip Code is required")]
        [RegularExpression("([0-9]+)", ErrorMessage = "4 numbers from 0 to 9")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Zip Code cannot be longer than 4 numbers")]
        [Display(Name = "Zip Code")]
        public override string ZipCode { get; set; }
        [StringLength(15)]
        public override string Country { get; set; } = "Australia";*/

        public override int ID { get; set; }
        public override string StreetNumber { get; set; }
        public override string StreetName { get; set; }
        public override string City { get; set; }
        public override string State { get; set; }
        public override int ZipCode { get; set; } //public override string ZipCode { get; set; }
        public override string Country { get; set; } = "Australia";

        public int DangerousCaseID { get; set; }

        [Required]
        [Display(Name = "Date Of Visit")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid Format")]
        public DateTime DateOfVisit { get; set; }
    }
}
