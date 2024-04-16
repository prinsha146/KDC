using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KDC.DL.Models;
using KDC.DL.DapperObjects;

namespace KDC.Web.Controllers
{
    public class FitListController : Controller
    {
        private FitListRepo db = new FitListRepo();
        // GET: FitList
        public ActionResult Index()
        {
            var allcandidate = db.GetAllCandidate();
            return View(allcandidate);
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            var FromDate = "";
            var ToDate = "";
            if (collection["FromDate"] != null && collection["FromDate"] != "")
            {
                DateTime from = Convert.ToDateTime(collection["FromDate"]);
                FromDate = from.ToString("yyyy-MM-dd");
            }
            if (collection["ToDate"] != null && collection["ToDate"] != "")
            {
                DateTime to = Convert.ToDateTime(collection["ToDate"]);
                ToDate = to.ToString("yyyy-MM-dd");
            }
            var list = db.GetAllCandidateByDate(FromDate, ToDate);
            return View(list);
        }

        public ActionResult UnFitCandidate()
        {
            var list = db.GetUnfitCandidateList();
            ViewBag.Failed = list.Count();
			ViewBag.Date = DateTime.Today.ToString("yyyy/MM/dd");
            return View(list);
        }

        [HttpPost]
        public ActionResult UnFitCandidate(FormCollection collection)
        {
            var FromDate = "";
            var ToDate = "";
            if (collection["FromDate"] != null && collection["FromDate"] != "")
            {
                DateTime from = Convert.ToDateTime(collection["FromDate"]);
                FromDate = from.ToString("yyyy-MM-dd");
            }
            if (collection["ToDate"] != null && collection["ToDate"] != "")
            {
                DateTime to = Convert.ToDateTime(collection["ToDate"]);
                ToDate = to.ToString("yyyy-MM-dd");
            }
            var list = db.GetUnfitCandidateListByDate(FromDate, ToDate);
			ViewBag.Failed = list.Count();
			ViewBag.Date = FromDate;
            return View(list);
        }

        public ActionResult GetFitStatus(int id)
        {
            var candidate = db.GetCandidateFitStatus(id);
            return View(candidate);
        }

    }
}