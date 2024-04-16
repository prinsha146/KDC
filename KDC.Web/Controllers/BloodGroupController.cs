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
    public class BloodGroupController : Controller
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
        private BloodGroupRepo db = new BloodGroupRepo();
        
        // GET: MS_BloodGroupRH
        public ActionResult Index()
        {
            try
            {
                var result = db.GetBloodGroupList();
                return View(result);
            }
            catch
            {
                return RedirectToRoute("Dashboard");
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BloodGroupId,BloodGroupName")] MS_BloodGroupRH bloodGroupRH)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.AddBloodGroup(bloodGroupRH);
                    return RedirectToAction("Index");
                }
                catch{
                    return View(bloodGroupRH);
                }
            }

            return View(bloodGroupRH);
        }

        public ActionResult Edit(int id)
        {
            var result = db.GetBloodGroupById(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BloodGroupId,BloodGroupName")] MS_BloodGroupRH bloodGroupRH)
        {
            if (ModelState.IsValid)
            {
                db.EditBloodGroup(bloodGroupRH);
                return RedirectToAction("Index");
            }
            return View(bloodGroupRH);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                db.DeleteBloodGroup(id);
            }
            catch
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}
