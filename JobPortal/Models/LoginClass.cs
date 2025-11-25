using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class LoginClass
    {
        [Required(ErrorMessage ="Enter the Email")]
        [EmailAddress(ErrorMessage ="Enter a valid Email")]
        public string Email { set; get; }
        [Required(ErrorMessage ="Enter the Password")]
        public string Password { set; get; }
        public string LType { set; get; }
        public string Msg { set; get; }
    }
}