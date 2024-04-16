using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KDC.DL.DapperObjects;
using KDC.DL.Models;

namespace KDC.Web.Controllers
{
    public class PatientBillingController : Controller
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

        PatientBillingRepo db = new PatientBillingRepo();
        PatientLabTestBillingRepo billrepo = new PatientLabTestBillingRepo();
        GetDropDown ddl = new GetDropDown();
        ams_kdcdb repo = new ams_kdcdb();

        // GET: PatientBilling
        public ActionResult Index()
        {
            var detail = db.GetPatientList();
            return View(detail);
        }

        public ActionResult Details(int id)
        {
            ViewBag.Patient = db.GetPatientBill(id);
            var detail = db.GetPatientBillDetailById(id);
            return View(detail);
        }

		public ActionResult PatientBillPrint(int id)
		{
			ViewBag.Patient = db.GetPatientBill(id);
			var detail = db.GetPatientBillDetailById(id);
			return View(detail);
		}

		[HttpPost]
		public ActionResult PatientBillPrint(FormCollection collection)
		{
			int LabCode = 0;
			int Invoice = 0;

			if (collection["LabCode"] != "" && collection["LabCode"] != null)
			{
				LabCode = Convert.ToInt32(collection["LabCode"]);
			}
			if (collection["Invoice"] != "" && collection["Invoice"] != null)
			{
				Invoice = Convert.ToInt32(collection["Invoice"]);
			}

			var patientBill = db.SearchPatient(LabCode, Invoice);
			int id = db.GetPatientId(LabCode);
			ViewBag.Patient = db.GetPatientBill(id);
			return View(patientBill);
		}

        public ActionResult Create()
        {
            ViewBag.ServiceId = repo.SV_Service.OrderBy(m => m.ServiceName).ToList();
            ViewBag.Address = new SelectList(ddl.GetDistrictDDL(), "Id", "Name");
            ViewBag.ReferrerId = new SelectList(repo.MS_Referer.OrderBy(s => s.RefererName), "RefererId", "RefererName");
            ViewBag.LabCode = db.GetLastLabCode() + 1;
			int invoice = db.GetInvoiceNo();
			if (invoice == 0)
			{
				ViewBag.Invoice = 1;
			}
			else
			{
				ViewBag.Invoice = invoice + 1;
			}
			return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection, string[] hditemindex)
        {
            BL_Patient patient = new BL_Patient();
            BL_PatientLabTestBill labTest = new BL_PatientLabTestBill();
            BL_PatientLabTestDetail testDetail = new BL_PatientLabTestDetail();

            try
            {
                patient.PatientName = collection["PatientName"];
                patient.Gender = collection["Gender"];
                if (collection["Age"] != null || collection["Age"] != "")
                {
                    patient.Age = Convert.ToInt32(collection["Age"]);
                }

                patient.Address = collection["Address"];
                patient.PhoneMobile = collection["PhoneMobile"];
                patient.ManualNo = collection["ManualNo"];
				patient.InvoiceNo = collection["Invoice"];


                if (collection["InvoiceDateAD"] != null || collection["InvoiceDate"] != "")
                {
                    patient.InvoiceDateAD = Convert.ToDateTime(collection["InvoiceDateAD"]);
                }

                patient.InvoiceDateBS = collection["InvoiceDateBS"];
                if (collection["ReferrerId"] != null || collection["ReferrerId"] != "")
                {
                    patient.ReferrerId = Convert.ToInt32(collection["ReferrerId"]);
                }

                patient.EnteredBy = Convert.ToInt32(Session["UserId"]);
                patient.EnteredDate = DateTime.Now;
                patient.LabCode = Convert.ToInt32(collection["LabCode"]);
                if (collection["TotalAmount"] != null && collection["TotalAmount"] != "")
                {
                    patient.TotalAmount = Convert.ToDecimal(collection["TotalAmount"]);
                }
                if (collection["Discount"] != null && collection["Discount"] != "")
                    patient.Discount = Convert.ToInt32(collection["Discount"]);

                if (collection["Net"] != null && collection["Net"] != "")
                    patient.Net = Convert.ToDecimal(collection["Net"]);

                if (collection["Tender"] != null && collection["Tender"] != "")
                    patient.Tender = Convert.ToDecimal(collection["Tender"]);

                if (collection["Change"] != null && collection["Change"] != "")
                    patient.Change = Convert.ToDecimal(collection["Change"]);

                patient.IsDeleted = false;

                db.AddPatientBill(patient);

                int rowcount = hditemindex.Count();
                var i = 1;
                var j = 1;
                List<String> service = new List<String>();

					foreach (var item in hditemindex)
                    {
                        labTest.ServiceId = collection["ItemName-" + item];
                        labTest.Unit = Convert.ToInt32(collection["ItemUnit-" + item]);
                        labTest.UnitPrice = Convert.ToDecimal(collection["ItemRate-" + item]);
                        labTest.Amount = Convert.ToDecimal(collection["ItemAmount-" + item]);
                        labTest.GroupId = db.GetGroupByService(labTest.ServiceId);
                        labTest.PatientId = db.GetPatientId((int)patient.LabCode);
                        labTest.EnteredBy = Convert.ToInt32(Session["UserId"]);
                        labTest.EnteredDate = DateTime.Now;
                        labTest.IsDeleted = false;
						//labTest.Remarks = collection["ItemRemarks-" + item];
                        //service[i] = labTest.ServiceId;
                        service.Add(labTest.ServiceId);
                        db.AddPatientLabTestBill(labTest);
                    }
                

                for (i = 1; i <= service.Count; i++)
                {
                    List<String> serviceDetail = new List<string>();
                    var gender = db.GetGenderByPatientId((int)labTest.PatientId);

                    var sex = "";
                    if (gender == "M")
                        sex = "Male";
                    if (gender == "F")
                        sex = "Female";

                    serviceDetail = db.GetServiceLabDetailByService(service.ElementAt(i-1), sex);
                    for (j = 1; j <= serviceDetail.Count; j++)
                    {
                        testDetail.PatientId = labTest.PatientId;
                        //testDetail.ServiceId = service[i-1];
                        testDetail.ServiceId = service.ElementAt(i - 1);
                        //testDetail.GroupId = db.GetGroupByService(service[i-1]);
                        testDetail.GroupId = db.GetGroupByService(testDetail.ServiceId);
                        testDetail.ServiceLabDetailId = serviceDetail.ElementAt(j-1);
                        testDetail.IsNormal = true;
                        testDetail.IsDeleted = false;
                        testDetail.EnteredBy = Convert.ToInt32(Session["UserId"]);
                        testDetail.EnteredDate = DateTime.Now;
                        testDetail.IsResultAdded = "Default";

                        db.AddPatientLabTestDetail(testDetail);
                    }
                }

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ViewBag.ServiceId = repo.SV_Service.OrderBy(m => m.ServiceName).ToList();
                ViewBag.Address = new SelectList(ddl.GetDistrictDDL(), "Id", "Name");
                ViewBag.ReferrerId = new SelectList(repo.MS_Referer.OrderBy(s => s.RefererName), "RefererId", "RefererName");
                return View();
            }
        }

        public float RateAmount(double id)
        {
            float rate = db.GetRateAmount(id);
            return rate;
        }

        public ActionResult Edit(int id)
        {
            var billing = db.GetPatientBillById(id);
            ViewBag.ServiceId = repo.SV_Service.OrderBy(m => m.ServiceName).ToList();
            ViewBag.Address = new SelectList(ddl.GetDistrictDDL(), "Id", "Name");
            ViewBag.ReferrerId = new SelectList(repo.MS_Referer.OrderBy(s => s.RefererName), "RefererId", "RefererName");
            ViewBag.LabCode = db.GetLabCodeById(id);
            return View(billing);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection collection, int id)
        {
            BL_Patient patient = new BL_Patient();
            //BL_PatientLabTestBill labTest = new BL_PatientLabTestBill();
            try
            {
				patient.PatientId = id;
                patient.PatientName = collection["PatientName"];
                patient.Gender = collection["Gender"];
                if (collection["Age"] != null || collection["Age"] != "")
                {
                    patient.Age = Convert.ToInt32(collection["Age"]);
                }

                patient.Address = collection["Address"];
                patient.PhoneMobile = collection["PhoneMobile"];
                patient.ManualNo = collection["ManualNo"];
                patient.InvoiceNo = collection["InvoiceNo"];
                if (collection["InvoiceDateAD"] != null || collection["InvoiceDate"] != "")
                {
                    patient.InvoiceDateAD = Convert.ToDateTime(collection["InvoiceDateAD"]);
                }

                patient.InvoiceDateBS = collection["InvoiceDateBS"];
                if (collection["ReferrerId"] != null || collection["ReferrerId"] != "")
                {
                    patient.ReferrerId = Convert.ToInt32(collection["ReferrerId"]);
                }

                patient.EnteredBy = Convert.ToInt32(Session["UserId"]);
                patient.EnteredDate = DateTime.Now;
                //patient.LabCode = Convert.ToInt32(collection["LabCode"]);
                patient.IsDeleted = false;

                db.EditPatientBill(patient);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.ServiceId = repo.SV_Service.OrderBy(m => m.ServiceName).ToList();
                ViewBag.Address = new SelectList(ddl.GetDistrictDDL(), "Id", "Name");
                ViewBag.ReferrerId = new SelectList(repo.MS_Referer.OrderBy(s => s.RefererName), "RefererId", "RefererName");
                return View();
            }
        }

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    db.RemovePatientBl(id);
        //    billrepo.RemovePatientLabTest(id);
        //    return RedirectToAction("Index");
        //}

		public ActionResult Delete(int id)
		{
			try
			{
				db.RemovePatientBl(id);
				billrepo.RemovePatientLabTest(id);
			}
			catch
			{
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index");
		}

		public ActionResult BillReport()
		{
			var bill = db.GetAllPatientBillToday();
			return View(bill);
		}

		[HttpPost]
		public ActionResult BillReport(FormCollection collection)
		{
			var from = "";
			var to = "";
			if (collection["From"] != "" && collection["From"] != null)
			{
				DateTime From = Convert.ToDateTime(collection["From"]);
				from = From.ToString("yyyy/MM/dd");
			}
			
			if (collection["To"] != "" && collection["To"] != null)
			{
				DateTime To = Convert.ToDateTime(collection["To"]);
				to = To.ToString("yyyy/MM/dd");
			}
			ViewBag.BillTotal = db.GetGroupWiseBill(from,to);
			var bill = db.GetAllPatientBill(from, to);
			return View(bill);
		}
	}
}