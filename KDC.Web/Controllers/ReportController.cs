using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KDC.DL.DapperObjects;
using KDC.DL.Models;

namespace KDC.Web.Controllers
{
    public class ReportController : Controller
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

        ReportRepo db = new ReportRepo();
        GetDropDown ddl = new GetDropDown();
        private ams_kdcdb dbb = new ams_kdcdb();

        // GET: /Report/
        public ActionResult Index(int id)
        {
            ViewBag.Year = new SelectList(ddl.GetYearList().OrderByDescending(s => s.Name), "Id", "Name", 1);
            var result = db.GetLaboratoryReport(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            int LabId = Convert.ToInt32(collection["LabNo"]);
            int Year = Convert.ToInt32(collection["Year"]);
            ViewBag.Year = new SelectList(ddl.GetYearList().OrderByDescending(s => s.Name), "Id", "Name", 1);
            var result = db.GetLabReportByLabCode(LabId, Year);
            return View(result);
        }

        public ActionResult Xray(int id)
        {
            var result = db.GetLaboratoryReport(id);
            ViewBag.Year = new SelectList(ddl.GetYearList().OrderByDescending(s => s.Name), "Id", "Name", 1);
			
            return View(result);
        }

        //[HttpPost]
        //public ActionResult Xray (int val, FormCollection collection, )
        //{
        //    if (val == 1)
        //    {
        //        return RedirectToAction("Xray");
        //    }
        //    else
        //    {
        //        return RedirectToAction("XrayList");
        //    }
        //}

        [HttpPost]
        public ActionResult Xray(FormCollection collection)
        {
            int LabId = Convert.ToInt32(collection["LabNo"]);
            int Year = Convert.ToInt32(collection["Year"]);
            ViewBag.Year = new SelectList(ddl.GetYearList().OrderByDescending(s => s.Name), "Id", "Name", 1);
			var result = db.GetLabReportByLabCode(LabId, Year);
            //return RedirectToAction("Xray", "Report", result);
            return View(result);
        }

        [HttpPost]
        public ActionResult SearchLabRange(FormCollection collection)
        {
            int LabCode = Convert.ToInt32(collection["From"]);
            int Lab = Convert.ToInt32(collection["To"]);
            var result = db.GetLabReportByLabRange(LabCode, Lab);
            return View(result);
            //return RedirectToAction("XrayList", "Report", result);
        }


        public ActionResult Vaccination(int id)
        {
            var result = db.GetLabReport(id);
            ViewBag.Year = new SelectList(ddl.GetYearList().OrderByDescending(s => s.Name), "Id", "Name", 1);
            //ViewBag.Doctor = new SelectList(dbb.MS_Doctor.OrderBy(s => s.DoctorName), "DoctorId", "DoctorName");
			ViewBag.Doctor = db.GetActiveDoctor();
			return View(result);
        }

        [HttpPost]
        public ActionResult Vaccination(FormCollection collection)
        {
            int LabId = Convert.ToInt32(collection["LabNo"]);
            int Year = Convert.ToInt32(collection["Year"]);
            ViewBag.Year = new SelectList(ddl.GetYearList().OrderByDescending(s => s.Name), "Id", "Name",1);
            //ViewBag.Doctor = new SelectList(dbb.MS_Doctor.OrderBy(s => s.DoctorName), "DoctorId", "DoctorName");
			ViewBag.Doctor = db.GetActiveDoctor();
			var result = db.GetLabReportByLabCode(LabId, Year);
            return View(result);
        }

		[HttpPost]
		public ActionResult MultipleVaccinationReport(FormCollection collection)
		{
			int LabCode = Convert.ToInt32(collection["From"]);
			int Lab = Convert.ToInt32(collection["To"]);
			var result = db.GetMultipleVaccination(LabCode, Lab);
			ViewBag.Doctor = db.GetActiveDoctor();
			return View(result);
		}

        public string DoctorInfo(int id)
        {
            var detail = db.GetDoctorInfo(id);
            return detail;
        }

        public ActionResult LaboratoryReport(int id)
        {
            var result = db.GetLaboratoryReport(id);
            ViewBag.Year = new SelectList(ddl.GetYearList().OrderByDescending(s => s.Name), "Id", "Name", 1);
            return View(result);
        }

        [HttpPost]
        public ActionResult LaboratoryReport(FormCollection collection)
        {
            int LabId = Convert.ToInt32(collection["LabNo"]);
            int Year = Convert.ToInt32(collection["Year"]);
            ViewBag.Year = new SelectList(ddl.GetYearList().OrderByDescending(s => s.Name), "Id", "Name" ,1);
            var result = db.GetLabReportByLabCode(LabId, Year);
            return View(result);
        }

		[HttpPost]
		public ActionResult SearchLabReport(FormCollection collection)
		{
			int LabCode = Convert.ToInt32(collection["From"]);
			int Lab = Convert.ToInt32(collection["To"]);
			var result = db.GetLabReportByLabRange(LabCode, Lab);
			return View(result);
			//return RedirectToAction("XrayList", "Report", result);
		}

		public ActionResult GCCDailyReport(string date="")
		{
			if(string.IsNullOrEmpty(date))
			{
				date = DateTime.Today.ToString("yyyy-MM-dd");
			}
			var result = db.GetMedicalStatusReport(date);
			return View(result);
		}


	}
}