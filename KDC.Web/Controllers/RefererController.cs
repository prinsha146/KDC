using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KDC.DL.DapperObjects;
using KDC.DL.Models;

namespace KDC.Web.Controllers
{
    public class RefererController : Controller
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
        RefererRepo db = new RefererRepo();

        public ActionResult Index()
        {
            var result = db.GetRefererList();
            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            MS_Referer referer = new MS_Referer();
            try
            {
                referer.RefererName = collection["RefererName"];

                db.AddReferer(referer);
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Error = "Error Occured";
                return View(referer);
            }
        }

        public ActionResult Details(int id)
        {
            var result = db.GetRefererById(id);
            return View(result);
        }

        public ActionResult Edit(int id)
        {
            var result = db.GetRefererById(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            MS_Referer referer= new MS_Referer();
            try
            {
                referer.RefererId = id;
                referer.RefererName = collection["RefererName"];

                db.EditReferer(referer);
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
            db.RemoveReferer(id);
            return RedirectToAction("Index");
        }
    }
}
