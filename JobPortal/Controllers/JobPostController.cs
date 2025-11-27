using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortal.Models;

namespace JobPortal.Controllers
{
    public class JobPostController : Controller
    {
        jobportalEntities objdb = new jobportalEntities();
        // GET: JobPost
        public ActionResult JobPost_Pageload()
        {
            JobPost objCls = new JobPost();
            objCls.MyQual = getQualificationData();
            objCls.MySkill = getSkillData();
            return View(objCls);
        }
        public List<checkBoxListChecker1> getQualificationData()
        {
            List<checkBoxListChecker1> sts = new List<checkBoxListChecker1>
            {
                new checkBoxListChecker1{Value="SSLC",Text="SSLC",isChecked=true},
                new checkBoxListChecker1{Value="PLUS TWO",Text="PLUS TWO",isChecked=true},
                new checkBoxListChecker1{Value="DIPLOMA",Text="DIPLOMA",isChecked=false},
                new checkBoxListChecker1{Value="BTECH",Text="BTECH",isChecked=false},
                new checkBoxListChecker1{Value="MTECH",Text="MTECH",isChecked=false}
            };
            return sts;
        }
        public List<checkBoxListChecker1> getSkillData()
        {
            List<checkBoxListChecker1> skl = new List<checkBoxListChecker1>
            {
                new checkBoxListChecker1{Value="C#",Text="C#",isChecked=true},
                new checkBoxListChecker1{Value="ASP.NET",Text="ASP.NET",isChecked=false},
                new checkBoxListChecker1{Value="MVC",Text="MVC",isChecked=false},
                new checkBoxListChecker1{Value="CORE MVC",Text="CORE MVC",isChecked=false},
                new checkBoxListChecker1{Value="Python",Text="Python",isChecked=false},
                new checkBoxListChecker1{Value="JAVA",Text="JAVA",isChecked=false},
            };
            return skl;
        }
        public ActionResult JobPost_Click(JobPost objCls,FormCollection form)
        {
            if (ModelState.IsValid)
            {
                var qul = string.Join("/", objCls.selectedQual);
                objCls.Qual = qul;
                objCls.MyQual = getQualificationData();

                var skl = string.Join(",", objCls.selectedSkill);
                objCls.Skill = skl;
                objCls.MySkill = getSkillData();
                return View("JobPost_Pageload", objCls);
                
            }
            else
            {
                objCls.MyQual = getQualificationData();
                objCls.MySkill = getSkillData();
                return View("JobPost_Pageload", objCls);
            }            
        }
    }
}