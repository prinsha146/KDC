using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KDC.DL.Models;

namespace KDC.Web.Controllers
{
    public class RecruitingAgencyController : Controller
    {
        private ams_kdcdb db = new ams_kdcdb();

        // GET: RecruitingAgency
        public ActionResult Index()
        {
            return View(db.MS_RecruitingAgency.ToList());
        }

        // GET: RecruitingAgency/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MS_RecruitingAgency mS_RecruitingAgency = db.MS_RecruitingAgency.Find(id);
            if (mS_RecruitingAgency == null)
            {
                return HttpNotFound();
            }
            return View(mS_RecruitingAgency);
        }

        // GET: RecruitingAgency/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecruitingAgency/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecruitingAgencyId,RecruitingAgencyName,CODE,NAFEA,DirectorName,Address,Phone,Fax,IsActive,IsDeleted")] MS_RecruitingAgency mS_RecruitingAgency)
        {
            if (ModelState.IsValid)
            {
                db.MS_RecruitingAgency.Add(mS_RecruitingAgency);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mS_RecruitingAgency);
        }

        // GET: RecruitingAgency/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MS_RecruitingAgency mS_RecruitingAgency = db.MS_RecruitingAgency.Find(id);
            if (mS_RecruitingAgency == null)
            {
                return HttpNotFound();
            }
            return View(mS_RecruitingAgency);
        }

        // POST: RecruitingAgency/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecruitingAgencyId,RecruitingAgencyName,CODE,NAFEA,DirectorName,Address,Phone,Fax,IsActive,IsDeleted")] MS_RecruitingAgency mS_RecruitingAgency)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mS_RecruitingAgency).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mS_RecruitingAgency);
        }

        // GET: RecruitingAgency/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MS_RecruitingAgency mS_RecruitingAgency = db.MS_RecruitingAgency.Find(id);
            if (mS_RecruitingAgency == null)
            {
                return HttpNotFound();
            }
            return View(mS_RecruitingAgency);
        }

        // POST: RecruitingAgency/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MS_RecruitingAgency mS_RecruitingAgency = db.MS_RecruitingAgency.Find(id);
            db.MS_RecruitingAgency.Remove(mS_RecruitingAgency);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
