using KDC.DL.DapperObjects;
using KDC.DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KDC.Web.Controllers
{
    public class DistrictController : Controller
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
        DistrictRepo db = new DistrictRepo();

        public ActionResult Index()
        {
            var result = db.GetDistrictList();
            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            MS_District district = new MS_District();
            try
            {
                district.DistrictName = collection["DistrictName"];
                

                db.AddDistrict(district);
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Error = "Error Occured";
                return View(district);
            }
        }

        public ActionResult Details(int id)
        {
            var result = db.GetDistrictById(id);
            return View(result);
        }

        public ActionResult Edit(int id)
        {
            var result = db.GetDistrictById(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            MS_District district= new MS_District();
            try
            {
                district.DistrictId = id;
                district.DistrictName = collection["DistrictName"];

                db.EditDistrict(district);
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
            db.RemoveDistrict(id);
            return RedirectToAction("Index");
        }
    }
}
