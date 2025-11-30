using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class checkBoxListChecker1
    {
        public string Value { set; get; }
        public string Text { set; get; }
        public bool isChecked { set; get; }
    }
    public class JobPost
    {
        [Required(ErrorMessage ="Enter the Job Title")]
        public string JobTitle { set; get; }
        [Required(ErrorMessage = "Enter the Job Description")]
        public string JobDes { set; get; }
        [Required(ErrorMessage = "Enter the Job Location")]
        public string JobLoc { set; get; }

        [Required(ErrorMessage = "Enter the Experience in Years")]
        public int Experience { set; get; }

        public List<checkBoxListChecker1> MySkill { set; get; }
        public string[] selectedSkill { set; get; }
        public string Skill { set; get; }

        public List<checkBoxListChecker1> MyQual { set; get; }
        public string[] selectedQual { set; get; }
        public string Qual { set; get; }
        [Required(ErrorMessage ="Enter Passout Year")]
        [RegularExpression(@"^(19|20)\d{2}$",ErrorMessage ="Enter a Valid Year")]
        public int PassOutYear { set; get; }
        [Required(ErrorMessage = "Enter Start Date")]
        public DateTime StartDate { set; get; }
        [Required(ErrorMessage = "Enter End Date")]
        public DateTime EndDate { set; get; }
        [Required(ErrorMessage ="Enter Job Type")]
        public string JobType { set; get; }
        [Required(ErrorMessage = "Enter the Salary")]
        
        public string Salary { set; get; }
        public string Msg { set; get; }
    }
}