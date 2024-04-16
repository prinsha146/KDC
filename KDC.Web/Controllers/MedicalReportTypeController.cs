using KDC.DL.DapperObjects;
using KDC.DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KDC.Web.Controllers
{
    public class MedicalReportTypeController : Controller
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
        MedicalReportTypeRepo db = new MedicalReportTypeRepo();

        public ActionResult Index()
        {
            var result = db.GetMedicalReportTypeList();
            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            MS_MedicalReportType reportType = new MS_MedicalReportType();
            try
            {
                reportType.ReportTypeName = collection["ReportTypeName"];


                db.AddMedicalReportType(reportType);
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Error = "Error Occured";
                return View(reportType);
            }
        }

        public ActionResult Edit(int id)
        {
            var result = db.GetMedicalReportTypeById(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            MS_MedicalReportType reportType = new MS_MedicalReportType();
            try
            {
                reportType.ReportTypeId = id;
                reportType.ReportTypeName= collection["ReportTypeName"];
                

                db.EditMedicalReportType(reportType);
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
            db.RemoveMedicalReportType(id);
            return RedirectToAction("Index");
        }
    }
}
