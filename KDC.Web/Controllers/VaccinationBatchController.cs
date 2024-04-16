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
//using KDC.Web.

namespace KDC.Web.Controllers
{
    public class VaccinationBatchController : Controller
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
        // GET: VaccinationBatch
        VaccinationBatchRepo db = new VaccinationBatchRepo();
        GetDropDown ddl = new GetDropDown();

        public ActionResult Index()
        {
            var result = db.GetVaccinationBatchList();
            return View(result);
        }

        // GET: VaccinationBatch/Details/5
        public ActionResult Details(int id)
        {
            var result = db.GetVaccinationBatchById(id);
            return View(result);
        }

        // GET: VaccinationBatch/Create
        public ActionResult Create()
        {
            ViewBag.VaccinationTypeId = new SelectList(ddl.GetVaccinationTypeDDL(), "Id", "Name");
            return View();
        }

        // POST: VaccinationBatch/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            MS_VaccinationBatch vaccinationBatch = new MS_VaccinationBatch();
            try
            {
                vaccinationBatch.Details = collection["Details"];
                vaccinationBatch.Manufacturer = collection["Manufacturer"];
                vaccinationBatch.BatchNo = collection["BatchNo"];
                vaccinationBatch.DateOfManufacture = Convert.ToDateTime(collection["DateOfManufacture"]);
                vaccinationBatch.DateOfExpiry = Convert.ToDateTime(collection["DateOfExpiry"]);
                vaccinationBatch.VaccinationTypeId = Convert.ToInt32(collection["VaccinationTypeId"]);
                vaccinationBatch.IsDeleted = false;

                db.Add(vaccinationBatch);
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Error = "Error Occured";
                return View(vaccinationBatch);
            }
        }

       
        // GET: VaccinationBatch/Edit/5
        public ActionResult Edit(int id)
        {
            
            var result = db.GetVaccinationBatchById(id);
            ViewBag.VaccinationTypeId = new SelectList(ddl.GetVaccinationTypeDDL(),"ID","Name", result.VaccinationTypeId);
            return View(result);
        }

        // POST: VaccinationBatch/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            MS_VaccinationBatch vaccinationBatch = new MS_VaccinationBatch();
            try
            {
                vaccinationBatch.Details = collection["Details"];
                vaccinationBatch.Manufacturer = collection["Manufacturer"];
                vaccinationBatch.BatchNo = collection["BatchNo"];
                vaccinationBatch.DateOfManufacture = Convert.ToDateTime(collection["DateOfManufacture"]);
                vaccinationBatch.DateOfExpiry = Convert.ToDateTime(collection["DateOfExpiry"]);
                vaccinationBatch.VaccinationTypeId = Convert.ToInt32(collection["VaccinationTypeId"]);
                vaccinationBatch.IsDeleted = false;
                vaccinationBatch.VaccinationBatchId = id;
                db.Edit(vaccinationBatch);
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Error = "Error Occured";
                return View();
            }
        }

        // GET: VaccinationBatch/Delete/5
        public ActionResult Delete(int id)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
