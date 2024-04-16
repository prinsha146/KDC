using KDC.DL.DapperObjects;
using KDC.DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KDC.Web.Controllers
{
    public class JobProfessionController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            if (Session["UserId"] != null)
            {
                base.OnActionExecuting(filterContext);

            }
            else
                filterContext.Result = new RedirectResult("~/Login/Index");
            //ilterContext.Result = new ViewResult { ViewName = "Index" };
        }
        JobProfessionRepo db = new JobProfessionRepo();

        public ActionResult Index()
        {
            var result = db.GetJobProfessionList();
            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            MS_JobProfession jobProfession = new MS_JobProfession();
            try
            {
                jobProfession.JobProfessionName = collection["JobProfessionName"];
                jobProfession.Active = Convert.ToBoolean(collection["Active"]);


                db.AddJobProfession(jobProfession);
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Error = "Error Occured";
                return View(jobProfession);
            }
        }

        public ActionResult Details(int id)
        {
            var result = db.GetJobProfessionById(id);
            return View(result);
        }

        public ActionResult Edit(int id)
        {
            var result = db.GetJobProfessionById(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            MS_JobProfession jobProfession = new MS_JobProfession();
            try
            {
                jobProfession.JobProfessionId = id;
                jobProfession.JobProfessionName = collection["JobProfessionName"];
                jobProfession.Active = Convert.ToBoolean(collection["Active"]);

                db.EditJobProfession(jobProfession);
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Error = "Error Occured";
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            db.RemoveJobProfession(id);
            return RedirectToAction("Index");
        }
    }
}
