using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortal.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace JobPortal.Controllers
{    
    public class UserProfileController : Controller
    {
        jobportalEntities objdb = new jobportalEntities();
        // GET: UserProfile
        public ActionResult UserProfile_Pageload()
        {
            var model = new JobSearch();
            var data = objdb.sp_selectJobs().ToList();

            foreach (var d in data)
            {
                var job = new jobList
                {
                    Job_id = d.Job_Id,
                    Company_id=d.Company_Id,
                    Company_name=d.Company_Name,
                    Job_Title = d.Job_Title,
                    Job_description = d.Job_Description,
                    Job_Experience = d.Job_Experience.ToString(),
                    Job_Skills = d.Job_Skills,
                    Job_Salary=d.Job_Salary.ToString(),
                    Job_enddate = d.End_Date,
                    Job_Location = d.Job_Location,
                    jobtype_name = d.Job_Type
                };

                model.selectjob.Add(job);
            }

            return View(model);

        }
        public ActionResult SearchJob_Click(JobSearch objcls)
        {
            string qry = "";

            if (!string.IsNullOrWhiteSpace(objcls.insertse.Job_Experience))
            {
                qry += " and Job_Experience like '%" + objcls.insertse.Job_Experience + "%'";
            }

            if (!string.IsNullOrWhiteSpace(objcls.insertse.Job_Skills))
            {
                qry += " and Job_Skills like '%" + objcls.insertse.Job_Skills + "%'";
            }

            if (!string.IsNullOrWhiteSpace(objcls.insertse.Job_Location))
            {
                qry += " and Job_Location like '%" + objcls.insertse.Job_Location + "%'";
            }
            if (!string.IsNullOrWhiteSpace(objcls.insertse.Job_Title))
            {
                qry += "and Job_Title like '%" + objcls.insertse.Job_Title + "%'";
            }

            return View("UserProfile_Pageload", getdata(objcls, qry));
        }
        private JobSearch getdata(JobSearch clsobj, string qry)
        {
            using (var con = new SqlConnection(
                ConfigurationManager.ConnectionStrings["importdataconnection"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_JobSearch", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qry", qry);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                var joblist = new JobSearch();

                while (dr.Read())
                {
                    var jobcls = new jobList();

                    jobcls.Job_id = Convert.ToInt32(dr["Job_Id"].ToString());
                    jobcls.Company_id = Convert.ToInt32(dr["Company_Id"]);
                    jobcls.Company_name = dr["Company_Name"].ToString();
                    jobcls.Job_Title = dr["Job_Title"].ToString();
                    jobcls.Job_description = dr["Job_Description"].ToString();
                    jobcls.jobtype_name = dr["Job_Type"].ToString();
                    jobcls.Job_Experience = dr["Job_Experience"].ToString();
                    jobcls.Job_Skills = dr["Job_Skills"].ToString();
                    jobcls.Job_Salary = dr["Job_Salary"].ToString();
                    jobcls.Job_enddate = Convert.ToDateTime(dr["End_Date"].ToString());
                    jobcls.Job_Location = dr["Job_Location"].ToString();

                    joblist.selectjob.Add(jobcls);
                }

                con.Close();
                return joblist;
            }
        }
    }
}