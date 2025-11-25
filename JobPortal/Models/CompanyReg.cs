using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class CompanyReg
    {
        [Required(ErrorMessage ="Enter the Company Name")]
        public string Name { set; get; }
        [Required(ErrorMessage ="Enter Description")]
        public string Description { set; get; }
        [Required(ErrorMessage ="Enter Address")]
        public string Address { set; get; }
        [Required(ErrorMessage = "Enter the Number")]
        [RegularExpression(@"^[6789]\d{9}$", ErrorMessage = "Enter a Valid Phone number")]
        public string Phone { set; get; }
        [EmailAddress(ErrorMessage = "Enter a valid Email Address")]
        [Required(ErrorMessage = "Enter Email Address")]
        public string Email { set; get; }
        [Required(ErrorMessage = "Enter the Password")]
        public string Password { set; get; }
        [Required(ErrorMessage = "Re-Enter the Password")]
        [Compare("Password", ErrorMessage = "re-enter correct Password")]
        public string ConPassword { set; get; }
        public string Msg { set; get; }
    }
}