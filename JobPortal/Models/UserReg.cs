using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class genClass
    {
        public int genId { set; get; }
        public string genName { set; get; }
    }

    public class checkBoxListChecker
    {
        public string Value { set; get; }
        public string Text { set; get; }
        public bool isChecked { set; get; }
    }
    public class UserReg
    {
        public int genId { set; get; }
        public string genName { set; get; }
        public List<checkBoxListChecker> MyQual { set; get; }
        public string[] selectedQual { set; get; }
        public List<checkBoxListChecker> MySkill { set; get; }
        public string[] selectedSkill { set; get; }
        [Required(ErrorMessage = "Enter the Name")]
        public string Name { set; get; }
        [Required(ErrorMessage = "Enter the Age")]
        [Range(18, 50, ErrorMessage = "Enter the Age with in the limit")]
        public int Age { set; get; }
        [Required(ErrorMessage = "Enter the Address")]
        public string Address { set; get; }
        [Required(ErrorMessage = "Enter the Number")]
        [RegularExpression(@"^[6789]\d{9}$", ErrorMessage = "Enter a Valid Phone number")]
        public string Phone { set; get; }
        [Required(ErrorMessage ="Enter the Experience")]        
        [Range(0,50,ErrorMessage ="Enter in Years(0-50)")]
        public int Experience { set; get; }
        public string Email { set; get; }
        [Required(ErrorMessage = "Enter the Password")]
        public string Password { set; get; }
        [Required(ErrorMessage = "Re-Enter the Password")]
        [Compare("Password", ErrorMessage = "re-enter correct Password")]
        public string ConPassword { set; get; }
        public string Msg { set; get; }

    }
}