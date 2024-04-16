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
    public class OrganizationSetupController : Controller
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
        private OrganizationSetupRepo db = new OrganizationSetupRepo();

        public ActionResult Index()
        {
            var result = db.GetOrganizationSetupList();
            return View(result);
        }

        public ActionResult Details(int id)
        {
            MS_OrganizationSetup organizationSetup = db.GetOrganizationSetupById(id);
            if (organizationSetup == null)
            {
                return HttpNotFound();
            }
            return View(organizationSetup);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrganizationId,OrganizationName,Address,Contact,Email,Website,Fax,PAN,GccCodeNo,IsActive,IsDeleted")] MS_OrganizationSetup organizationSetup)
        {
            if (ModelState.IsValid)
            {
                db.AddOrganizationSetup(organizationSetup);
                return RedirectToAction("Index");
            }

            return View(organizationSetup);
        }

        public ActionResult Edit(int id)
        {
            MS_OrganizationSetup organizationSetup = db.GetOrganizationSetupById(id);
            if (organizationSetup == null)
            {
                return HttpNotFound();
            }
            return View(organizationSetup);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrganizationId,OrganizationName,Address,Contact,Email,Website,Fax,PAN,GccCodeNo,IsActive,IsDeleted")] MS_OrganizationSetup organizationSetup)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.EditOrganizationSetup(organizationSetup);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(organizationSetup);
                }
            }

            return View(organizationSetup);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                db.DeleteOrganizationSetup(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
