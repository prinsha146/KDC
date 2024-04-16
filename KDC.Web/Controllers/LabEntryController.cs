using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KDC.DL.Models;
using KDC.DL.DapperObjects;
using System.Net;

namespace KDC.Web.Controllers
{
    public class LabEntryController : Controller
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

        private ams_kdcdb db = new ams_kdcdb();
        private LabEntryRepo repo = new LabEntryRepo();
        private CandidateRepo repRepo = new CandidateRepo();
        private GetDropDown ddl = new GetDropDown();

        // GET: LabEntry
        public ActionResult Index()
        {
            var detail = repo.GetLabEntryList();
            ViewBag.Year = new SelectList(ddl.GetYearList().OrderByDescending(s => s.Name), "Id", "Name", 1);
            return View(detail);
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            int LabId = Convert.ToInt32(collection["LabCode"]);
            int Year = Convert.ToInt32(collection["Year"]);
            ViewBag.Year = new SelectList(ddl.GetYearList().OrderByDescending(s => s.Name), "Id", "Name", 1);
            var detail = repo.GetLabRecordByLabId(LabId, Year);
            return View(detail);
        }

        // GET: LabEntry/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.JobProfessionID = new SelectList(db.MS_JobProfession.OrderBy(s => s.JobProfessionName), "JobProfessionId", "JobProfessionName");
            ViewBag.PassportPlaceOfIssue = new SelectList(db.MS_District.OrderBy(s => s.DistrictName), "DistrictId", "DistrictName");
            ViewBag.VisaStampingCountryID = new SelectList(db.MS_VisaStampingCountry.OrderBy(s => s.CountryName), "CountryId", "CountryName");
            ViewBag.Address = new SelectList(db.MS_District.OrderBy(s => s.DistrictName), "DistrictId", "DistrictName");
            ViewBag.BloodGroup_RH = new SelectList(db.MS_BloodGroupRH.OrderBy(s => s.BloodGroupName), "BloodGroupId", "BloodGroupName");
            ViewBag.RecruitingAgencyID = new SelectList(db.MS_RecruitingAgency.OrderBy(s => s.RecruitingAgencyName), "RecruitingAgencyId", "RecruitingAgencyName");
            ViewBag.UserId = new SelectList(db.SC_User.OrderBy(s => s.FullName), "UserId", "Fullname");
            var detail = repo.GetLabRecordById(id);
            ViewBag.Details = detail;
            return View(detail);
        }

        public ActionResult Create(int? id) //id = CandidateId
        {
            if (Convert.ToString(Session["UserType"]) == "Admin" || Convert.ToString(Session["UserType"]) == "Lab")
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                ViewBag.JobProfessionID = new SelectList(db.MS_JobProfession.OrderBy(s => s.JobProfessionName), "JobProfessionId", "JobProfessionName");
                ViewBag.PassportPlaceOfIssue = new SelectList(db.MS_District.OrderBy(s => s.DistrictName), "DistrictId", "DistrictName");
                ViewBag.VisaStampingCountryID = new SelectList(db.MS_VisaStampingCountry.OrderBy(s => s.CountryName), "CountryId", "CountryName");
                ViewBag.Address = new SelectList(db.MS_District.OrderBy(s => s.DistrictName), "DistrictId", "DistrictName");
                ViewBag.BloodGroup_RH = new SelectList(db.MS_BloodGroupRH.OrderBy(s => s.BloodGroupName), "BloodGroupId", "BloodGroupName");
                ViewBag.RecruitingAgencyID = new SelectList(db.MS_RecruitingAgency.OrderBy(s => s.RecruitingAgencyName), "RecruitingAgencyId", "RecruitingAgencyName");
                ViewBag.UserId = new SelectList(db.SC_User.OrderBy(s => s.FullName), "UserId", "Fullname");
                CD_Candidate cD_Candidate = db.CD_Candidate.Find(id);
                ViewBag.Detail = cD_Candidate;
                
                return View(cD_Candidate);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection, int id)
        {
            if (Convert.ToString(Session["UserType"]) == "Admin" || Convert.ToString(Session["UserType"]) == "Lab")
            {
                CD_Candidate cD_Candidate = db.CD_Candidate.Find(id);
                ViewBag.Details = cD_Candidate;
                try
                {
                    cD_Candidate.UHb = collection["UHb"];
                    cD_Candidate.BDC_N = collection["BDC_N"];
                    cD_Candidate.BDC_L = collection["BDC_L"];
                    cD_Candidate.BDC_E = collection["BDC_E"];
                    cD_Candidate.BDC_M = collection["BDC_M"];
                    cD_Candidate.BDC_B = collection["BDC_B"];
                    cD_Candidate.Platelets = collection["Platelets"];
                    cD_Candidate.UTC_in_cumm = collection["UTC_in_cumm"];
                    cD_Candidate.BSugar = collection["BSugar"];
                    cD_Candidate.BAlbumin = collection["BAlbumin"];
                    cD_Candidate.UHBsAg = collection["UHBsAg"];
                    cD_Candidate.SGOT_Per = collection["SGOT_Per"];
                    cD_Candidate.UAnti_HCV = collection["UAnti_HCV"];
                    cD_Candidate.Creat_Block = collection["Creat_Block"];
                    cD_Candidate.UTPHA = collection["UTPHA"];
                    cD_Candidate.SGPT_Per = collection["SGPT_Per"];
                    cD_Candidate.Alk_Pho_Per = collection["Alk_Pho_Per"];
                    cD_Candidate.TPro_Per = collection["TPro_Per"];
                    cD_Candidate.Urea_Per = collection["Urea_Per"];
                    cD_Candidate.ESR_Per = collection["ESR_Per"];
                    cD_Candidate.UVDRL = collection["UVDRL"];
                    cD_Candidate.Bill_T_Per = collection["Bill_T_Per"];
                    cD_Candidate.GGT_Per = collection["GGT_Per"];
                    cD_Candidate.UMP = collection["UMP"];
                    cD_Candidate.UMF = collection["UMF"];
                    cD_Candidate.Bil_D_Per = collection["Bil_D_Per"];
                    cD_Candidate.Albumin_Per = collection["Albumin_Per"];
                    if (collection["BloodGroup_RH"] != "")
                    {
                        cD_Candidate.BloodGroup_RH = Convert.ToInt32(collection["BloodGroup_RH"]);
                    }
                    cD_Candidate.Stool_RE = collection["Stool_RE"];
                    cD_Candidate.Other = collection["Other"];
                    cD_Candidate.Urine_Re_Me = collection["Urine_Re_Me"];
                    cD_Candidate.Micros_Exam = collection["Micros_Exam"];
                    if (collection["LabTestEnteredBy"] != "")
                    {
                        cD_Candidate.LabTestEnteredBy = Convert.ToInt32(Session["UserId"]);
                    }

                    cD_Candidate.LabTestEnteredDate = DateTime.Now;
                    if (collection["VaccinationDataEnteredBy"] != "")
                    {
                        cD_Candidate.VaccinationDataEnteredBy = Convert.ToInt32(Session["UserId"]);
                    }
                    cD_Candidate.DateOfVaccination = DateTime.Today;
                    cD_Candidate.VaccinationBatchId = repo.GetMaxVaccinationBatch();
                    cD_Candidate.Usugar = collection["Usugar"];
                    cD_Candidate.Ualbumin = collection["Ualbumin"];
                    cD_Candidate.Helminthes = collection["Helminthes"];
                    cD_Candidate.Giardia = collection["Giardia"];
                    cD_Candidate.Salmonella = collection["Salmonella"];
                    cD_Candidate.Malaria = collection["Malaria"];
                    cD_Candidate.Haemo = collection["Haemo"];
                    cD_Candidate.Microf = collection["Microf"];
                    //cD_Candidate.BloodGroup_RH = Convert.ToInt32(collection["BloodGroup_RH"]);
                    cD_Candidate.FBS = collection["FBS"];
                    //cD_Candidate.HBsAg = collection["HBsAg"];
                    cD_Candidate.LFT = collection["LFT"];
                    //cD_Candidate.Anti_HCV = collection["Anti_HCV"];
                    cD_Candidate.Creatinine = collection["Creatinine"];
                    //cD_Candidate.VDRL = collection["VDRL"];
                    cD_Candidate.UHIV_1_2 = collection["UHIV_1_2"];
                        if (collection["Pregnancy"] != "")
                        {
                            cD_Candidate.Pregnancy = Convert.ToBoolean(collection["Pregnancy"]);
                        }
                    
                    cD_Candidate.Remarks = collection["Remarks"];
                    //if (collection["FitStatus"] != "")
                    //{
                    //    cD_Candidate.FitStatus = Convert.ToBoolean(collection["FitStatus"]);
                    //}
                    //cD_Candidate.UnfitRemarks = collection["UnFitRemarks"];

                    repo.LabEntry(cD_Candidate);
                    return RedirectToAction("Index");

                }
                catch (Exception e)
                {
                    ViewBag.JobProfessionID = new SelectList(db.MS_JobProfession.OrderBy(s => s.JobProfessionName), "JobProfessionId", "JobProfessionName");
                    ViewBag.PassportPlaceOfIssue = new SelectList(db.MS_District.OrderBy(s => s.DistrictName), "DistrictId", "DistrictName");
                    ViewBag.VisaStampingCountryID = new SelectList(db.MS_VisaStampingCountry.OrderBy(s => s.CountryName), "CountryId", "CountryName");
                    ViewBag.Address = new SelectList(db.MS_District.OrderBy(s => s.DistrictName), "DistrictId", "DistrictName");
                    ViewBag.BloodGroup_RH = new SelectList(db.MS_BloodGroupRH.OrderBy(s => s.BloodGroupName), "BloodGroupId", "BloodGroupName");
                    ViewBag.RecruitingAgencyID = new SelectList(db.MS_RecruitingAgency.OrderBy(s => s.RecruitingAgencyName), "RecruitingAgencyId", "RecruitingAgencyName");
                    return View();
                }
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        public ActionResult Edit(int? id)  //id = LabCode
        {
            if (Convert.ToString(Session["UserType"]) == "Admin" || Convert.ToString(Session["UserType"]) == "Lab")
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                if (id != null)
                {
                    ViewBag.JobProfessionID = new SelectList(db.MS_JobProfession.OrderBy(s => s.JobProfessionName), "JobProfessionId", "JobProfessionName");
                    ViewBag.PassportPlaceOfIssue = new SelectList(db.MS_District.OrderBy(s => s.DistrictName), "DistrictId", "DistrictName");
                    ViewBag.VisaStampingCountryID = new SelectList(db.MS_VisaStampingCountry.OrderBy(s => s.CountryName), "CountryId", "CountryName");
                    ViewBag.Address = new SelectList(db.MS_District.OrderBy(s => s.DistrictName), "DistrictId", "DistrictName");
                    ViewBag.BloodGroup_RH = new SelectList(db.MS_BloodGroupRH.OrderBy(s => s.BloodGroupName), "BloodGroupId", "BloodGroupName");
                    ViewBag.RecruitingAgencyID = new SelectList(db.MS_RecruitingAgency.OrderBy(s => s.RecruitingAgencyName), "RecruitingAgencyId", "RecruitingAgencyName");
                    ViewBag.UserId = new SelectList(db.SC_User.OrderBy(s => s.FullName), "UserId", "Fullname");
                    //CD_Candidate cD_Candidate = db.CD_Candidate.Find(id);
                    var labRecord = repo.GetLabRecordById((int)id);
                    ViewBag.Detail = labRecord;
                    return View(labRecord);
                }
                return View();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        public ActionResult Edit(FormCollection collection, int id)
        {
            if (Convert.ToString(Session["UserType"]) == "Admin" || Convert.ToString(Session["UserType"]) == "Lab")
            {
                CD_Candidate cD_Candidate = new CD_Candidate();
                //ViewBag.Details = cD_Candidate;
                try
                {

                    cD_Candidate.UHb = collection["UHb"];
                    cD_Candidate.BDC_N = collection["BDC_N"];
                    cD_Candidate.BDC_L = collection["BDC_L"];
                    cD_Candidate.BDC_E = collection["BDC_E"];
                    cD_Candidate.BDC_M = collection["BDC_M"];
                    cD_Candidate.BDC_B = collection["BDC_B"];
                    cD_Candidate.Platelets = collection["Platelets"];
                    cD_Candidate.UTC_in_cumm = collection["UTC_in_cumm"];
                    cD_Candidate.BSugar = collection["BSugar"];
                    cD_Candidate.BAlbumin = collection["BAlbumin"];
                    cD_Candidate.UHBsAg = collection["UHBsAg"];
                    cD_Candidate.SGOT_Per = collection["SGOT_Per"];
                    cD_Candidate.UAnti_HCV = collection["UAnti_HCV"];
                    //cD_Candidate.Creatinine = collection["Creatinine"];
                    cD_Candidate.UTPHA = collection["UTPHA"];
                    cD_Candidate.SGPT_Per = collection["SGPT_Per"];
                    cD_Candidate.Alk_Pho_Per = collection["Alk_Pho_Per"];
                    cD_Candidate.TPro_Per = collection["TPro_Per"];
                    cD_Candidate.Urea_Per = collection["Urea_Per"];
                    cD_Candidate.ESR_Per = collection["ESR_Per"];
                    cD_Candidate.UVDRL = collection["UVDRL"];
                    cD_Candidate.Bill_T_Per = collection["Bill_T_Per"];
                    cD_Candidate.GGT_Per = collection["GGT_Per"];
                    cD_Candidate.UMP = collection["UMP"];
                    cD_Candidate.UMF = collection["UMF"];
                    cD_Candidate.Bil_D_Per = collection["Bil_D_Per"];
                    cD_Candidate.Albumin_Per = collection["Albumin_Per"];
                    if (collection["BloodGroup_RH"] != "")
                    {
                        cD_Candidate.BloodGroup_RH = Convert.ToInt32(collection["BloodGroup_RH"]);
                    }
                    cD_Candidate.Stool_RE = collection["Stool_RE"];
                    cD_Candidate.Other = collection["Other"];
                    cD_Candidate.Urine_Re_Me = collection["Urine_Re_Me"];
                    cD_Candidate.Micros_Exam = collection["Micros_Exam"];
                    if (collection["LabTestEnteredBy"] != "")
                    {
                        cD_Candidate.LabTestEnteredBy = Convert.ToInt32(Session["UserId"]);
                    }

                    cD_Candidate.LabTestEnteredDate = DateTime.Now;
                    if (collection["VaccinationDataEnteredBy"] != "")
                    {
                        cD_Candidate.VaccinationDataEnteredBy = Convert.ToInt32(Session["UserId"]);
                    }
                    cD_Candidate.DateOfVaccination = DateTime.Today;
                    cD_Candidate.VaccinationBatchId = repo.GetMaxVaccinationBatch();
                    cD_Candidate.Usugar = collection["Usugar"];
                    cD_Candidate.Ualbumin = collection["Ualbumin"];
                    cD_Candidate.Helminthes = collection["Helminthes"];
                    cD_Candidate.Giardia = collection["Giardia"];
                    cD_Candidate.Salmonella = collection["Salmonella"];
                    cD_Candidate.Malaria = collection["Malaria"];
                    cD_Candidate.Haemo = collection["Haemo"];
                    cD_Candidate.Microf = collection["Microf"];
                    //cD_Candidate.BloodGroup_RH = Convert.ToInt32(collection["BloodGroup_RH"]);
                    cD_Candidate.FBS = collection["FBS"];
                    //cD_Candidate.HBsAg = collection["HBsAg"];
                    cD_Candidate.LFT = collection["LFT"];
                    //cD_Candidate.Anti_HCV = collection["Anti_HCV"];
                    cD_Candidate.Creatinine = collection["Creatinine"];
                    //cD_Candidate.VDRL = collection["VDRL"];
                    cD_Candidate.UHIV_1_2 = collection["UHIV_1_2"];
                    if (collection["Pregnancy"] != "")
                    {
                        cD_Candidate.Pregnancy = Convert.ToBoolean(collection["Pregnancy"]);
                    }
                    cD_Candidate.Remarks = collection["Remarks"];
                    cD_Candidate.CandidateID = id;
                    
                    repo.LabEntry(cD_Candidate);
                    return RedirectToAction("Index");

                }
                catch (Exception e)
                {
                    ViewBag.JobProfessionID = new SelectList(db.MS_JobProfession.OrderBy(s => s.JobProfessionName), "JobProfessionId", "JobProfessionName");
                    ViewBag.PassportPlaceOfIssue = new SelectList(db.MS_District.OrderBy(s => s.DistrictName), "DistrictId", "DistrictName");
                    ViewBag.VisaStampingCountryID = new SelectList(db.MS_VisaStampingCountry.OrderBy(s => s.CountryName), "CountryId", "CountryName");
                    ViewBag.Address = new SelectList(db.MS_District.OrderBy(s => s.DistrictName), "DistrictId", "DistrictName");
                    ViewBag.BloodGroup_RH = new SelectList(db.MS_BloodGroupRH.OrderBy(s => s.BloodGroupName), "BloodGroupId", "BloodGroupName");
                    ViewBag.RecruitingAgencyID = new SelectList(db.MS_RecruitingAgency.OrderBy(s => s.RecruitingAgencyName), "RecruitingAgencyId", "RecruitingAgencyName");
                    return View();
                }
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // GET: LabEntry/Delete/5
        public ActionResult Delete(int id)
        {
            if (Convert.ToString(Session["UserType"]) == "Admin" || Convert.ToString(Session["UserType"]) == "Lab")
            {
                var detail = repo.GetLabRecordById(id);
                return View(detail);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // POST: LabEntry/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (Convert.ToString(Session["UserType"]) == "Admin" || Convert.ToString(Session["UserType"]) == "Lab")
            {
                try
                {
                    // TODO: Add delete logic here
                    CD_Candidate cD_Candidate = db.CD_Candidate.Find(id);
                    db.CD_Candidate.Remove(cD_Candidate);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // GET: LabEntry/Create
        //public ActionResult Create(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ViewBag.BloodGroup_RH = new SelectList(db.MS_BloodGroupRH.OrderBy(s => s.BloodGroupName), "BloodGroupId", "BloodGroupName");
        //    ViewBag.UserId = new SelectList(db.SC_User.OrderBy(s => s.FullName), "UserId", "Fullname");
        //    var candidate = db.CD_Candidate.Find(id);
        //    ViewBag.Detail = candidate;
        //    return View();
        //}

        //// POST: LabEntry/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    CD_Candidate cD_Candidate = new CD_Candidate();
        //    try
        //    {
        //        // TODO: Add insert logic here
        //        cD_Candidate.Hb = collection["Hb"];
        //        cD_Candidate.DC_N = collection["DC_N"];
        //        cD_Candidate.DC_L = collection["DC_L"];
        //        cD_Candidate.DC_E = collection["DC_E"];
        //        cD_Candidate.DC_M = collection["DC_M"];
        //        cD_Candidate.DC_B = collection["DC_B"];
        //        cD_Candidate.TC_in_cumm = collection["TC_in_cumm"];
        //        cD_Candidate.Sugar = collection["Sugar"];
        //        cD_Candidate.Albumin = collection["Albumin"];
        //        cD_Candidate.HBsAg = collection["HBsAG"];
        //        cD_Candidate.SGOT_Per = collection["SGOT_Per"];
        //        cD_Candidate.Anti_HCV = collection["Anti_HCV"];
        //        cD_Candidate.Creat_Block = collection["Creat_Block"];
        //        cD_Candidate.TPHA = collection["TPHA"];
        //        cD_Candidate.SGPT_Per = collection["SGPT_Per"];
        //        cD_Candidate.Alk_Pho_Per = collection["Alk_Pho_Per"];
        //        cD_Candidate.TPro_Per = collection["TPro_Per"];
        //        cD_Candidate.Urea_Per = collection["Urea_Per"];
        //        cD_Candidate.ESR_Per = collection["ESR_Per"];
        //        cD_Candidate.VDRL = collection["VDRL"];
        //        cD_Candidate.Bill_T_Per = collection["Bill_T_Per"];
        //        cD_Candidate.GGT_Per = collection["GGT_Per"];
        //        cD_Candidate.MP = collection["MP"];
        //        cD_Candidate.MF = collection["MF"];
        //        cD_Candidate.Bil_D_Per = collection["Bil_D_Per"];
        //        cD_Candidate.Albumin_Per = collection["Albumin_Per"];
        //        cD_Candidate.BloodGroup_RH = Convert.ToInt32(collection["BloodGroup_RH"]);
        //        cD_Candidate.Stool_RE = collection["Stool_RE"];
        //        cD_Candidate.Other = collection["Other"];
        //        cD_Candidate.Urine_Re_Me = collection["Urine_Re_Me"];
        //        cD_Candidate.Micros_Exam = collection["Micros_Exam"];
        //        cD_Candidate.LabTestEnteredBy = Convert.ToInt32(collection["LabTestEnteredBy"]);
        //        cD_Candidate.LabTestEnteredDate = Convert.ToDateTime(collection["LabTestEnteredDate"]);

        //        repo.AddLabEntry(cD_Candidate);
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: LabEntry/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: LabEntry/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}


    }
}
