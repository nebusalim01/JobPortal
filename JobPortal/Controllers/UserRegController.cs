using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortal.Models;

namespace JobPortal.Controllers
{
    public class UserRegController : Controller
    {
        jobportalEntities objdb = new jobportalEntities();

        // GET: UserReg
        public ActionResult UserReg_Pageload()
        {
            List<genClass> genDrop = new List<genClass>
            {
                new genClass{genId=1,genName="Male"},
                new genClass{genId=2,genName="Female"}
            };
            ViewBag.gender = new SelectList(genDrop, "genId", "genName");
            UserReg objCls = new UserReg();
            objCls.MyQual = getQualificationData();
            objCls.MySkill = getSkillData();
            return View(objCls);
        }
        public List<checkBoxListChecker> getQualificationData()
        {
            List<checkBoxListChecker> sts = new List<checkBoxListChecker>
            {
                new checkBoxListChecker{Value="SSLC",Text="SSLC",isChecked=true},
                new checkBoxListChecker{Value="PLUS TWO",Text="PLUS TWO",isChecked=true},
                new checkBoxListChecker{Value="DIPLOMA",Text="DIPLOMA",isChecked=false},
                new checkBoxListChecker{Value="BTECH",Text="BTECH",isChecked=false},
                new checkBoxListChecker{Value="MTECH",Text="MTECH",isChecked=false}
            };
            return sts;
        }
        public List<checkBoxListChecker> getSkillData()
        {
            List<checkBoxListChecker> skl = new List<checkBoxListChecker>
            {
                new checkBoxListChecker{Value="C#",Text="C#",isChecked=true},
                new checkBoxListChecker{Value="ASP.NET",Text="ASP.NET",isChecked=false},
                new checkBoxListChecker{Value="MVC",Text="MVC",isChecked=false},
                new checkBoxListChecker{Value="CORE MVC",Text="CORE MVC",isChecked=false},
                new checkBoxListChecker{Value="Python",Text="Python",isChecked=false},
                new checkBoxListChecker{Value="JAVA",Text="JAVA",isChecked=false},
            };
            return skl;
        }
        public ActionResult UserReg_Click(UserReg objCls, FormCollection form)
        {
            if (ModelState.IsValid)
            {                
                List<genClass> genDrop = new List<genClass>
                {
                    new genClass{genId=1,genName="Male"},
                    new genClass{genId=2,genName="Female"}
                };
                ViewBag.gender = new SelectList(genDrop, "genId", "genName");
                int selectId = Convert.ToInt32(form["ddlGender"]);
                genClass selectedItem = genDrop.FirstOrDefault(c => c.genId == selectId);
                objCls.genId = selectedItem.genId;
                objCls.genName = selectedItem.genName;

                var qul = string.Join(",", objCls.selectedQual);
                objCls.Qual = qul;
                objCls.MyQual = getQualificationData();

                var skl = string.Join(",", objCls.selectedSkill);
                objCls.Skill = skl;
                objCls.MySkill = getSkillData();

                int maxRegid = Convert.ToInt32(objdb.sp_maxRegid().FirstOrDefault());
                int regid = 0;
                if (maxRegid == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = maxRegid + 1;
                }
                int cid = Convert.ToInt32(objdb.sp_countRegidMailCheck(objCls.Email).FirstOrDefault());
                if (cid == 0)
                {
                    objdb.sp_insertUserTable(regid, objCls.Name, objCls.Age, objCls.Address, objCls.Phone, objCls.genName, objCls.Qual, objCls.Skill, objCls.Experience, "Active");
                    objdb.sp_insertLoginTable(regid, objCls.Email, objCls.Password, "User");
                    objCls.Msg = "Inserted Successfully";
                    return View("UserReg_Pageload", objCls);
                }
                else
                {
                    objCls.Msg = "User already Exist";
                    return View("UserReg_Pageload", objCls);
                }
            }
            else
            {
                List<genClass> genDrop = new List<genClass>
                {
                    new genClass{genId=1,genName="Male"},
                    new genClass{genId=2,genName="Female"}
                };
                ViewBag.gender = new SelectList(genDrop, "genId", "genName");
                objCls.MyQual = getQualificationData();
                objCls.MySkill = getSkillData();
                return View("UserReg_Pageload", objCls);
            }
            
        }
    }
}