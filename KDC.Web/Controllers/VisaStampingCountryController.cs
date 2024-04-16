using KDC.DL.DapperObjects;
using KDC.DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KDC.Web.Controllers
{
    public class VisaStampingCountryController : Controller
    {
        VisaStampingCountryRepo db = new VisaStampingCountryRepo();

        public ActionResult Index()
        {
            var result = db.GetVisaStampingCountries();
            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            MS_VisaStampingCountry country = new MS_VisaStampingCountry();
            try
            {
                country.CountryName = collection["CountryName"];
                country.CountryCode = Convert.ToInt32(collection["CountryCode"]);

                db.AddVisaStampingCountry(country);
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Error = "Error Occured";
                return View(country);
            }
        }

        public ActionResult Edit(int id)
        {
            var result = db.GetVisaStampingCountryById(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            MS_VisaStampingCountry country = new MS_VisaStampingCountry();
            try
            {
                country.CountryId = id;
                country.CountryName = collection["CountryName"];
                country.CountryCode = Convert.ToInt32(collection["CountryCode"]);
                db.EditVisaStampingCountry(country);
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
