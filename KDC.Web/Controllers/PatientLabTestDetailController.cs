using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KDC.DL.DapperObjects;
using KDC.DL.Models;
using KDC.DL.ViewModel;

namespace KDC.Web.Controllers
{
    public class PatientLabTestDetailController : Controller
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

        PatientLabTestDetailRepo db = new PatientLabTestDetailRepo();
        PatientBillingRepo repo = new PatientBillingRepo();

        // GET: PatientLabTestDetail
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int id)
        {
            ViewBag.Personal = db.GetPatientDetail(id);
            var detail = db.GetPatientTestDetail(id);
			ViewBag.GroupList = db.GetDistinctGroup(id);
			ViewBag.ServiceList = db.GetDistinctService(id);
			ViewBag.LabDetail = detail;
            return View(detail);
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection, string[] item, string[] Service) 
        {
            BL_PatientLabTestDetail labDetail = new BL_PatientLabTestDetail();
            int rowcount = item.Count();
            int i = 1;

            for (i = 1; i <= rowcount; i++)
            {
                int PatientLabTestId = Convert.ToInt32(item[i - 1]);
                string ServiceDetailId = Convert.ToString(Service[i - 1]);

				if (collection["Remarks_" + item[i -1]] != "" && collection["Remarks_" + item[i - 1]] != null)
				{
					labDetail.Result = collection["Result_" + item[i - 1]] + " - " + collection["Remarks_" + item[i - 1]];
				}
				else
				{
					labDetail.Result = collection["Result_" + item[i - 1]];
				}
				var rem = collection["Remarks_" + item[i - 1]];

				var gender = db.GetGender(PatientLabTestId);
                var sex = "";
                if (gender == "M")
                    sex = "Male";

                if (gender == "F")
                    sex = "Female";

                var result = db.CheckNormal(labDetail.Result, PatientLabTestId, sex, ServiceDetailId);

                if (result == "Yes")
                    labDetail.IsNormal = true;

                if (result == "No")
                    labDetail.IsNormal = false;

                labDetail.EnteredDate = DateTime.Now;
                labDetail.EnteredBy = Convert.ToInt32(Session["UserId"]);
                labDetail.IsResultAdded = "Added";

                db.EditLabTestDetail(labDetail, PatientLabTestId);
                
            }
            return RedirectToAction("Index", "PatientBilling");
        }

        public ActionResult Details(int id) // id = PatientId
        {
            var gender = repo.GetGenderByPatientId(id);
            var sex = "";
            if (gender == "M")
                sex = "Male";
            if (gender == "F")
                sex = "Female";

            var detail = db.GetServiceLabDetail(id, sex);
			ViewBag.GroupList = db.GetDistinctGroup(id);
			ViewBag.ServiceList = db.GetDistinctService(id);
            ViewBag.Detail = db.GetPatientDetail(id);
			var date = db.GetDate(id);
			ViewBag.InvoiceDateBS = MonthName(date);
            return View(detail);
        }

		[HttpPost]
		public ActionResult Details(FormCollection collection)
		{
			int LabCode = 0;
			int patientId = 0;
			if (collection["LabCode"] != "" && collection["LabCode"] != null)
			{
				LabCode = Convert.ToInt32(collection["LabCode"]);
				patientId = repo.GetPatientId(LabCode);
			}
		
			var gender = repo.GetGenderByPatientId(patientId);
			var sex = "";
			if (gender == "M")
				sex = "Male";
			if (gender == "F")
				sex = "Female";
			var detail = db.GetServiceLabDetail(patientId, sex);
			ViewBag.GroupList = db.GetDistinctGroup(patientId);
			ViewBag.ServiceList = db.GetDistinctService(patientId);
			ViewBag.Detail = db.GetPatientDetail(patientId);
			var date = db.GetDate(patientId);
			ViewBag.InvoiceDateBS = MonthName(date);
			return View(detail);
		}

		public string MonthName(string month)
		{
			string[] LabDate = month.Split('-');
			var LabDateAD = "";
			if (LabDate[1] == "01")
			{
				LabDateAD = "Baishakh " + LabDate[2] + ", " + LabDate[0];
			}
			if (LabDate[1] == "02")
			{
				LabDateAD = "Jestha" + LabDate[2] + ", " + LabDate[0];
			}
			if (LabDate[1] == "03")
			{
				LabDateAD = "Asar" + LabDate[2] + ", " + LabDate[0];
			}
			if (LabDate[1] == "04")
			{
				LabDateAD = "Shrawan" + LabDate[2] + ", " + LabDate[0];
			}
			if (LabDate[1] == "05")
			{
				LabDateAD = "Bhadra" + LabDate[2] + ", " + LabDate[0];
			}
			if (LabDate[1] == "06")
			{
				LabDateAD = "Asoj" + LabDate[2] + ", " + LabDate[0];
			}
			if (LabDate[1] == "07")
			{
				LabDateAD = "Kartik" + LabDate[2] + ", " + LabDate[0];
			}
			if (LabDate[1] == "08")
			{
				LabDateAD = "Mangsir" + LabDate[2] + ", " + LabDate[0];
			}
			if (LabDate[2] == "09")
			{
				LabDateAD = "Poush" + LabDate[3] + ", " + LabDate[0];
			}
			if (LabDate[1] == "10")
			{
				LabDateAD = "Magh" + LabDate[2] + ", " + LabDate[0];
			}
			if (LabDate[1] == "11")
			{
				LabDateAD = "Falgun" + LabDate[2] + ", " + LabDate[0];
			}
			if (LabDate[1] == "12")
			{
				LabDateAD = "Chaitra" + LabDate[2] + ", " + LabDate[0];
			}

			return LabDateAD;
		}

    }
}