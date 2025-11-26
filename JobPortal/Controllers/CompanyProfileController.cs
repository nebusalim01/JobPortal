using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobPortal.Controllers
{
    public class CompanyProfileController : Controller
    {
        // GET: CompanyProfile
        public ActionResult CompanyProfile_Pageload()
        {
            return View();
        }
    }
}