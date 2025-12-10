using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortal.Models;

namespace JobPortal.Controllers
{
    public class AddApplicationController : Controller
    {
        jobportalEntities objdb = new jobportalEntities();
        // GET: AddApplication
        public ActionResult Application_load(int cid,int jid)
        {

            TempData["cid"] = cid;
            Session["cid"] = cid;
            Session["jid"] = jid;
            TempData["jid"] = jid;
            var jobdetails = objdb.sp_SelectOneJob(Convert.ToInt32(TempData["cid"]), Convert.ToInt32(TempData["jid"])).ToList().FirstOrDefault();
            return View(new AddApplication
            {
                JobTitle = jobdetails.Job_Title,
                ComName=jobdetails.Company_Name,
                JobDes=jobdetails.Job_Description,
                Location=jobdetails.Job_Location,
                Salary=jobdetails.Job_Salary
            });                              
        }
        public ActionResult Application_Click(AddApplication objCls,HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                int appcount = Convert.ToInt32(objdb.sp_AppCount(Convert.ToInt32(Session["id"]), Convert.ToInt32(Session["jid"])).FirstOrDefault());
                if (appcount == 0)
                {
                    string fname = Path.GetFileName(file.FileName);
                    var p = Server.MapPath("~/resume");
                    string fullpath = Path.Combine(p, fname);
                    file.SaveAs(fullpath);
                    var fpath = Path.Combine("~\\resume", fname);
                    objCls.Resume = fname;

                    objCls.Date = DateTime.Now;
                    objdb.sp_InsertApplication(Convert.ToInt32(Session["id"]), Convert.ToInt32(Session["jid"]), objCls.Date, objCls.Resume, "Applied");
                    objCls.Msg = "Applied";
                    return View("Application_load", objCls);
                }
                else
                {                    
                    objCls.Msg = "Already Applied";
                    return View("Application_load",objCls);
                }
            }
            else
            {
                objCls.Msg = "Upload Resume";
                return View("Application_load", objCls);
            }            
        }
    }
}