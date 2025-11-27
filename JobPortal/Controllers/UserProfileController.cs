using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortal.Models;

namespace JobPortal.Controllers
{    
    public class UserProfileController : Controller
    {
        jobportalEntities objdb = new jobportalEntities();
        // GET: UserProfile
        public ActionResult UserProfile_Pageload()
        {
            var data = objdb.sp_selectAllJob().ToList();
            ViewBag.jobDetails = data;
            return View();
        }
    }
}