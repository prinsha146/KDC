using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KDC.DL.Models;
using KDC.DL.ViewModel;
using KDC.DL.DapperObjects;
using System.IO;
using System.Net;

namespace KDC.Web.Controllers
{
    public class OPDPatientController : Controller
    {
		OPDPatientRepo db = new OPDPatientRepo();
		GetDropDown ddl = new GetDropDown();
        // GET: OPDPatient
        public ActionResult Index()
        {
            ViewBag.PatientName = new SelectList(db.GetOPDPatient());
            var list = db.GetOPDPatientList();
            return View(list);
        }

		[HttpPost]
		public ActionResult Index(FormCollection collection)
		{
			int PatientCode = 0;
			var PatientName = "";
			if (collection["PatientCode"] != "")
			{
				PatientCode = Convert.ToInt32(collection["PatientCode"]);
			}
			if (collection["PatientName"] != "" && collection["PatientName"] != null) 
			{
				PatientName = collection["PatientName"];
			}
            ViewBag.PatientName = new SelectList(db.GetOPDPatient());
            var result = db.SearchOPDPatient(PatientCode, PatientName);
			return View(result);
		}

		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			var detail = db.GetOPDPatientById((int)id);
			return View(detail);

		}

		public ActionResult Create()
		{
			//ViewBag.Address = new SelectList(ddl.GetDistrictDDL(), "ID", "Name");
			return View();
		}

		[HttpPost]
		public ActionResult Create(FormCollection collection)
		{
			OPD_Patient patient = new OPD_Patient();
			try 
			{
				if (ModelState.IsValid)
				{
					patient.PatientName = collection["PatientName"];
					patient.PatientCode = collection["PatientCode"];
                    if (collection["Age"] != "" && collection["Age"] != null)
                    {
                        patient.Age = Convert.ToInt32(collection["Age"]);
                    }
                    patient.Address = collection["Address"];
					patient.Gender = collection["Gender"];
					patient.Phone = collection["Phone"];
					patient.EnteredBy = Convert.ToInt32(Session["UserId"]);
					patient.EnteredDate = DateTime.Now;

					db.AddOPDPatient(patient);
				}

				return RedirectToAction("Index");
			}
			catch
			{
				//ViewBag.Address = new SelectList(ddl.GetDistrictDDL(), "ID", "Name");
				return View();
			}
		}

		public ActionResult Edit (int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			var patient = db.GetOPDPatient((int)id);
			//ViewBag.Address = new SelectList(ddl.GetDistrictDDL(), "ID", "Name");
			return View(patient);
		}

		[HttpPost]
		public ActionResult Edit(FormCollection collection, int id)
		{
            OPD_Patient patient = db.GetOPDPatient(id);
			try
			{
				if (ModelState.IsValid)
				{
					patient.PatientName = collection["PatientName"];
					patient.PatientCode = collection["PatientCode"];
                    if (collection["Age"] != "" && collection["Age"] != null)
                    {
                        patient.Age = Convert.ToInt32(collection["Age"]);
                    }
                    if (collection["Address"] != "" && collection["Age"] != null)
                    {
                        patient.Address = collection["Address"];
                    }
                    patient.Gender = collection["Gender"];
					patient.Phone = collection["Phone"];
					patient.EnteredBy = Convert.ToInt32(Session["UserId"]);
					patient.EnteredDate = DateTime.Now;

					db.EditOPDPatient(patient);
				}

				return RedirectToAction("Index");
			}
			catch
			{
				//ViewBag.Address = new SelectList(ddl.GetDistrictDDL(), "ID", "Name");
				return View(patient);
			}
		}

		public ActionResult Delete(int id)
		{
			db.RemoveOPDPatient(id);
			return RedirectToAction("Index");
		}
    }
}