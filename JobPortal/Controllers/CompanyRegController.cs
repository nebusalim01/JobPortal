using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortal.Models;

namespace JobPortal.Controllers
{
    public class CompanyRegController : Controller
    {
        jobportalEntities objdb = new jobportalEntities();
        // GET: CompanyReg
        public ActionResult CompanyReg_Pageload()
        {
            return View();
        }
        public ActionResult CompanyReg_Click(CompanyReg objCls)
        {
            if (ModelState.IsValid)
            {
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
                    objdb.sp_insertCompanyTable(regid, objCls.Name, objCls.Description, objCls.Address, objCls.Phone);
                    objdb.sp_insertLoginTable(regid, objCls.Email, objCls.Password, "Comapny");
                    objCls.Msg = "Inserted Successfully";
                    return View("CompanyReg_Pageload", objCls);
                }
                else
                {
                    objCls.Msg = "Admin already Exist";
                    return View("CompanyReg_Pageload", objCls);
                }
            }
            else
            {
                return View("CompanyReg_Pageload", objCls);
            }
        }
    }
}