using KDC.DL.Models;
using KDC.DL.DapperObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KDC.Web.Controllers
{
    public class VaccinationTypeController : Controller
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
        VaccinationTypeRepo db = new VaccinationTypeRepo();

        public ActionResult Index()
        {
            var result = db.GetVaccinationTypeList();
            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            MS_VaccinationType vaccinationType = new MS_VaccinationType();
            try
            {
                vaccinationType.VaccinationTypeName = collection["VaccinationTypeName"];

                db.AddVaccinationType(vaccinationType);
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Error = "Error Occured";
                return View(vaccinationType);
            }
        }

        public ActionResult Edit(int id)
        {
            var result = db.GetVaccinationTypeById(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            MS_VaccinationType vaccinationType = new MS_VaccinationType();
            try
            {
                vaccinationType.VaccinationTypeId= id;
                vaccinationType.VaccinationTypeName = collection["VaccinationTypeName"];
                db.EditVaccinationType(vaccinationType);
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
            db.RemoveVaccinationType(id);
            return RedirectToAction("Index");
        }
    }
}
