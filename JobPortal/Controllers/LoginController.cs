using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortal.Models;

namespace JobPortal.Controllers
{
    public class LoginController : Controller
    {
        jobportalEntities objdb = new jobportalEntities();
        // GET: Login
        public ActionResult Login_Pageload()
        {
            return View();
        }
        public ActionResult Login_Click(LoginClass objCls)
        {
            int cid = Convert.ToInt32(objdb.sp_countRegid(objCls.Email, objCls.Password).FirstOrDefault());
            if (cid == 1)
            {
                Session["id"] = Convert.ToInt32(objdb.sp_selRegid(objCls.Email, objCls.Password).FirstOrDefault());
                string logType = Convert.ToString(objdb.sp_selLoginType(objCls.Email, objCls.Password).FirstOrDefault());
                if (logType == "Company")
                {
                    return RedirectToAction("CompanyProfile_Pageload", "CompanyProfile");
                }
                else if (logType == "User")
                {
                    return RedirectToAction("UserProfile_Pageload", "UserProfile");
                }
                else
                {
                    objCls.Msg = "Something Went Wrong";
                    return View("Login_Pageload", objCls);
                }
            }
            else
            {
                objCls.Msg = "Invalid";
                return View("Login_Pageload", objCls);
            }
        }
    }
}