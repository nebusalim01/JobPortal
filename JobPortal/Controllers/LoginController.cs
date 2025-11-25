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

            }
            return View("Login_Pageload", objCls);
        }
    }
}