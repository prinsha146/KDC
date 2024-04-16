using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KDC.DL.Models;
using KDC.DL.DapperObjects;

namespace KDC.Web.Controllers
{
    public class DoctorController : Controller
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
		DoctorRepo db = new DoctorRepo();
        // GET: Doctor
        public ActionResult Index()
        {
			var list = db.GetDoctorList();
            return View(list);
        }

		public ActionResult Details(int id)
		{
			if (id == 0)
			{
				return HttpNotFound();
			}
			var detail = db.GetDoctorById(id);
			return View(detail);
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(FormCollection collection)
		{
			MS_Doctor doctor = new MS_Doctor();
			try
			{
				doctor.DoctorName = collection["DoctorName"];
				doctor.Degree = collection["Degree"];
				doctor.Specialization = collection["Specialization"];
				doctor.IsActive = Convert.ToBoolean(collection["IsActive"]);
				doctor.IsDeleted = false;

				db.AddDoctor(doctor);
				return RedirectToAction("Index");
			}
			catch(Exception e)
			{
				return View();
			}
		}

		public ActionResult Edit(int id)
		{
			if (id == 0)
			{
				return HttpNotFound();
			}
			var doctor = db.GetDoctorById(id);
			return View(doctor);
		}

		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			MS_Doctor doctor = new MS_Doctor();

			try
			{
				doctor.DoctorId = id;
				doctor.DoctorName = collection["DoctorName"];
				doctor.Degree = collection["Degree"];
				doctor.Specialization = collection["Specialization"];
				doctor.IsActive = Convert.ToBoolean(collection["IsActive"]);
				doctor.IsDeleted = false;

				db.EditDoctor(doctor);
				return RedirectToAction("Index");
			}
			catch(Exception e)
			{
				return View();
			}
		}

		public ActionResult Delete(int id)
		{
			db.RemoveDoctor(id);
			return RedirectToAction("Index");
		}
    }
}