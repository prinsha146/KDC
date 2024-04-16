using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KDC.DL.Models;
using KDC.DL.ViewModel;
using KDC.DL.DapperObjects;

namespace KDC.Web.Controllers
{
    public class PatientLabTestBillingController : Controller
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

        PatientLabTestBillingRepo repo = new PatientLabTestBillingRepo();
        PatientBillingRepo db = new PatientBillingRepo();

        // GET: PatientLabTestBilling
        public ActionResult Index(int id)
        {
            var list = repo.GetLabTestList(id);
            return View(list);
        }

        public ActionResult Details(int serviceId, int patientId)
        {
            var detail = repo.GetLabTestDetailById(serviceId, patientId);
            return View(detail);
        }

        public ActionResult Edit(int id)
        {
            var labTest = repo.GetLabTestById(id);
            return View(labTest);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            BL_PatientLabTestBill labTest = new BL_PatientLabTestBill();
            labTest.ServiceId = collection["ServiceId"];
            labTest.GroupId = db.GetGroupByService(labTest.ServiceId);
            labTest.Unit = Convert.ToInt32(collection["Unit"]);
            labTest.UnitPrice = Convert.ToDecimal(collection["UnitPrice"]);
            labTest.Amount = Convert.ToDecimal(collection["Amount"]);
            labTest.IsDeleted = false;
            labTest.EnteredBy = Convert.ToInt32(Session["UserId"]);
            labTest.EnteredDate = Convert.ToDateTime(collection["EnteredDate"]);

            repo.EditPatientLabTest(labTest);
            return RedirectToAction("Index");

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.RemoveLabTest(id);
            return RedirectToAction("Index");
        }
    }
}