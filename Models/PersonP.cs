using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project334.Models
{
    public abstract class PersonP
    {
        public abstract int ID { get; set; }

        [Display(Name = "Mobile number")]
        [Required(ErrorMessage = "The Mobile number is required")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Mobile number is ten digits")]
        [DataType(DataType.PhoneNumber)]
        public abstract string MobilePhone { get; set; }

        [Required(ErrorMessage = "The Last Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last Name cannot be longer than 50 characters")]
        [RegularExpression("^[a-zA-Z]+(?:s+[a-zA-Z]+)*$", ErrorMessage = "Last Name is not valid")]
        [Display(Name = "Last Name")]
        public abstract string LastName { get; set; }

        [Required(ErrorMessage = "The First Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First Name cannot be longer than 50 characters")]
        [RegularExpression("^[a-zA-Z]+(?:s+[a-zA-Z]+)*$", ErrorMessage = "First Name is not valid")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public abstract string FirstMidName { get; set; }

        [Required(ErrorMessage = "The Email address is required")]
        [Display(Name = "Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")] //[EmailAddress(ErrorMessage = "Invalid Email Address")]
        [DataType(DataType.EmailAddress)]
        //[EmailAddress(ErrorMessage = "Invalid Email")]
        public abstract string Email { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }
    }
}