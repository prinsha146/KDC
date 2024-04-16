using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KDC.DL.Models;
using KDC.DL.DapperObjects;
using System.IO;

namespace KDC.Web.Controllers
{
    public class CandidateController : Controller
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
        CandidateRepo repo = new CandidateRepo();
        GetDropDown ddl = new GetDropDown();
		VisaStampingCountryRepo dbc = new VisaStampingCountryRepo();
        // GET: Candidate
        public ActionResult Index()
        {
            var detail = repo.GetCandidatesList();
			ViewBag.Country = new SelectList(ddl.GetStampingCountryListDDl(), "Id", "Name");
            ViewBag.Year = new SelectList(ddl.GetYearList().OrderByDescending(s => s.Name), "Id", "Name", 1);
           // ViewBag.Country = new SelectList(db.MS_VisaStampingCountry.OrderBy(s => s.CountryName), "CountryId", "CountryName");
            return View(detail);
            //return View(db.CD_Candidate.ToList());
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            int LabId = 0, Year = 0, Country = 0;
            var fromDate = "";
            var toDate = "";
			var status = "";
            if (collection["LabCode"] != null && collection["LabCode"] != "")
            {
                LabId = Convert.ToInt32(collection["LabCode"]);
            }
            if (collection["Year"] != null && collection["Year"] != "")
            {
                Year = Convert.ToInt32(collection["Year"]);
            }
            if (collection["FromDate"] != null && collection["FromDate"] != "")
            {
                DateTime from = Convert.ToDateTime(collection["FromDate"]);
                fromDate = from.ToString("yyyy/MM/dd");
            }
            if (collection["ToDate"] != null && collection["ToDate"] != "")
            {
                DateTime to = Convert.ToDateTime(collection["ToDate"]);
                toDate = to.ToString("yyyy/MM/dd");
            }
            if (collection["Country"] != null && collection["Country"] != "")
            {
                Country = Convert.ToInt32(collection["Country"]);
            }
				status = collection["Status"];
			
			ViewBag.Country = new SelectList(ddl.GetStampingCountryListDDl(), "Id", "Name");
			ViewBag.Year = new SelectList(ddl.GetYearList().OrderByDescending(s => s.Name), "Id", "Name", 1);
            ViewBag.Country = new SelectList(db.MS_VisaStampingCountry.OrderBy(s => s.CountryName), "CountryId", "CountryName");
            var detail = repo.GetLabRecordById(LabId, Year, Country, fromDate, toDate, status);
            return View(detail);
        }

        // GET: Candidate/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CD_Candidate cD_Candidate = db.CD_Candidate.Find(id);
            if (cD_Candidate == null)
            {
                return HttpNotFound();
            }
            ViewBag.JobProfessionID = new SelectList(db.MS_JobProfession.OrderBy(s => s.JobProfessionName), "JobProfessionId", "JobProfessionName");
            ViewBag.PassportPlaceOfIssue = new SelectList(db.MS_District.OrderBy(s => s.DistrictName), "DistrictId", "DistrictName");
            ViewBag.VisaStampingCountryID = new SelectList(db.MS_VisaStampingCountry.OrderBy(s => s.CountryName), "CountryId", "CountryName");
            ViewBag.Address = new SelectList(db.MS_District.OrderBy(s => s.DistrictName), "DistrictId", "DistrictName");
            ViewBag.BloodGroup_RH = new SelectList(db.MS_BloodGroupRH.OrderBy(s => s.BloodGroupName), "BloodGroupId", "BloodGroupName");
            ViewBag.RecruitingAgencyID = new SelectList(db.MS_RecruitingAgency.OrderBy(s => s.RecruitingAgencyName), "RecruitingAgencyId", "RecruitingAgencyName");
            return View(cD_Candidate);
        }

        // GET: Candidate/Create
        public ActionResult Create()
        {
            if (Convert.ToString(Session["UserType"]) == "Admin" || Convert.ToString(Session["UserType"]) == "Reception")
            {
                ViewBag.JobProfessionID = new SelectList(db.MS_JobProfession.OrderBy(s => s.JobProfessionName), "JobProfessionId", "JobProfessionName");
                ViewBag.PassportPlaceOfIssue = new SelectList(db.MS_District.OrderBy(s => s.DistrictName), "DistrictId", "DistrictName");
                ViewBag.VisaStampingCountryID = new SelectList(db.MS_VisaStampingCountry.OrderBy(s => s.CountryName), "CountryId", "CountryName");
                ViewBag.Address = new SelectList(db.MS_District.OrderBy(s => s.DistrictName), "DistrictId", "DistrictName");
                ViewBag.BloodGroup_RH = new SelectList(db.MS_BloodGroupRH.OrderBy(s => s.BloodGroupName), "BloodGroupId", "BloodGroupName");
                ViewBag.RecruitingAgencyID = new SelectList(db.MS_RecruitingAgency.OrderBy(s => s.RecruitingAgencyName), "RecruitingAgencyId", "RecruitingAgencyName");

                int labCode = repo.GetLastLabNo() + 1;
                ViewBag.LabCode = labCode;
                return View();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // POST: Candidate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GccCode,Married,Religion,GccHMC,VisaNo,VisaDate,RQNoManpower,GamcaNo,DateOfIssueByKDC_AD,DateOfIssueByKDC_BS,CandidateName,Address,ContactNo,Gender,DOB_AD,DOB_BS,Height_in_cm,Weight_in_kg,Nationality,JobProfessionID,PassportNo,PassportDateAD,PassportDateBS,PassportPlaceOfIssue,RecruitingAgencyID,VisaStampingCountryID,InvoiceNo,Allergy,Others,FingerPrint,FingerPrintRemarks,PhotoScanned,PhotoCamera,Barcode,CandidateDetailsEnteredBy,CandidateDetailsEnteredDate,LabNoIdThisYear,RightEye,LeftEye,RightEar,LeftEar,BloodPressure,Heart,Lungs,Chest,Abdomen,Hernia,Veins,Extermities,Deformities,Skin,Clinical,Cns,Pshychiatry,Hb,TC_in_cumm,HIV_1_2,HBsAg,Anti_HCV,TPHA,VDRL,MP,MF,Urine_Re_Me,Sugar,Albumin,Stool_RE,DC_N,DC_L,DC_E,DC_M,DC_B,Platelets,Sugar_Block,Bill_T_Per,Albumin_Per,Bil_D_Per,TPro_Per,Alk_Pho_Per,Creat_Block,SGPT_Per,Urea_Per,ESR_Per,GGT_Per,SGOT_Per,BloodGroup_RH,Other,Pregnancy,LabTestEnteredBy,LabTestEnteredDate,DateOfVaccination,VaccinationDataEnteredBy")] CD_Candidate cD_Candidate, FormCollection collection, HttpPostedFileBase PhotoScanned)
        {
            if (Convert.ToString(Session["UserType"]) == "Admin" || Convert.ToString(Session["UserType"]) == "Reception")
            {
                CD_Candidate candidate = new CD_Candidate();
                try
                {
                    candidate.CandidateName = collection["CandidateName"];
                    candidate.MedicalCenterID = 1;
                    if (collection["Married"] != "")
                    {
                        candidate.Married = Convert.ToBoolean(collection["Married"]);
                    }
                    candidate.Religion = collection["Religion"];
                    candidate.GccCode = collection["GccCode"];
                    candidate.GccHMC = collection["GccHMC"];
                    candidate.VisaNo = collection["VisaNo"];
                    candidate.LabCode = Convert.ToInt32(collection["LabCode"]);
                    candidate.VisaDate = collection["VisaDate"];
                    candidate.RQNoManpower = collection["RQNoManpower"];
                    candidate.GamcaNo = candidate.GccHMC;
                    if (collection["DateOfIssueByKDC_AD"] != "")
                    {
                        candidate.DateOfIssueByKDC_AD = Convert.ToDateTime(collection["DateOfIssueByKDC_AD"]);
                    }
                    candidate.DateOfIssueByKDC_BS = collection["DateOfIssueByKDC_BS"];
                    if (collection["Address"] != "")
                    {
                        candidate.Address = Convert.ToInt32(collection["Address"]);
                        //candidate.Address = collection["Address"];
                    }
                    candidate.ContactNo = collection["ContactNo"];
                    candidate.Gender = collection["Gender"];
                    if (collection["DOB_AD"] != "")
                    {
                        candidate.DOB_AD = Convert.ToDateTime(collection["DOB_AD"]);
                    }
                    candidate.DOB_BS = collection["DOB_BS"];
                    if (collection["Height_in_cm"] != "")
                    {
                        candidate.Height_in_cm = Convert.ToDecimal(collection["Height_in_cm"]);
                    }
                    if (collection["Weight_in_kg"] != "")
                    {
                        candidate.Weight_in_kg = Convert.ToDecimal(collection["Weight_in_kg"]);
                    }
                    candidate.Nationality = collection["Nationality"];
                    if (collection["JobProfessionID"] != "")
                    {
                        candidate.JobProfessionID = Convert.ToInt32(collection["JobProfessionID"]);
                    }
                    candidate.PassportNo = collection["PassportNo"];
                    if (collection["PassportDateAD"] != "")
                    {
                        candidate.PassportDateAD = Convert.ToDateTime(collection["PassportDateAD"]);
                    }
                    candidate.PassportDateBS = collection["PassportDateBS"];
                    if (collection["PassportPlaceOfIssue"] != "")
                    {
                        candidate.PassportPlaceOfIssue = Convert.ToInt32(collection["PassportPlaceOfIssue"]);
                    }
                    if (collection["RecruitingAgencyID"] != "")
                    {
                        candidate.RecruitingAgencyID = Convert.ToInt32(collection["RecruitingAgencyID"]);
                    }
                    if (collection["VisaStampingCountryID"] != "")
                    {
                        candidate.VisaStampingCountryID = Convert.ToInt32(collection["VisaStampingCountryID"]);
                    }
                    candidate.InvoiceNo = collection["InvoiceNo"];
                    if (collection["Allergy"] != "")
                    {
                        candidate.Allergy = Convert.ToBoolean(collection["Allergy"]);
                    }
                    candidate.Others = collection["Others"];
                    //candidate.FingerPrint = collection["FingerPrint"];
                    //candidate.FingerPrintRemarks = collection["FingerPrintRemarks"];
                    //candidate.PhotoCamera = collection["PhotoCamera"];
                    if (PhotoScanned != null)
                    {

                        string[] fileext = PhotoScanned.FileName.Split('.');
                        string fileName = PhotoScanned.FileName;  // + "." + fileext[fileext.Count() - 1];
                        string path = "~/images/scanned";
                        /* if (!System.IO.Directory.Exists(Server.MapPath(path)))
                         {
                             System.IO.Directory.CreateDirectory(Server.MapPath(path));
                         } */
                        string filePath = Path.Combine(Server.MapPath(path), Path.GetFileName(fileName));
                        PhotoScanned.SaveAs(filePath);
                        candidate.PhotoScanned = fileName;
                    }

                    //candidate.PhotoScanned = collection["PhotoScanned"];
                    candidate.Barcode = collection["Barcode"];

                    candidate.RightEye = collection["RightEye"];
                    candidate.RightEar = collection["RightEar"];
                    candidate.LeftEye = collection["LeftEye"];
                    candidate.LeftEar = collection["LeftEar"];
                    candidate.BloodPressure = collection["BloodPressure"];
                    candidate.Heart = collection["Heart"];
                    candidate.Lungs = collection["Lungs"];
                    candidate.Chest = collection["Chest"];
                    candidate.Abdomen = collection["Abdomen"];
                    candidate.Hernia = collection["Hernia"];
                    candidate.Veins = collection["Veins"];
                    candidate.Extermities = collection["Extermities"];
                    candidate.Deformities = collection["Deformities"];
                    candidate.Skin = collection["Skin"];
                    candidate.Clinical = collection["Clinical"];
                    candidate.Cns = collection["Cns"];
                    candidate.Pshychiatry = collection["Pshychiatry"];
                    //candidate.RVNoToday = repo.CheckTodayRV() + 1;

                    candidate.CandidateDetailsEnteredBy = Convert.ToInt32(Session["UserId"]);
                    candidate.CandidateDetailsEnteredDate = DateTime.Now;
                    candidate.LabNoIdThisYear = DateTime.Now.Year;

                    repo.AddCandidate(candidate);
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
                    return View(cD_Candidate);
                }
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }


        // GET: Candidate/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (Convert.ToString(Session["UserType"]) == "Admin" || Convert.ToString(Session["UserType"]) == "Reception")
            {
                CD_Candidate cD_Candidate = db.CD_Candidate.Find(id);
                if (cD_Candidate == null)
                {
                    return HttpNotFound();
                }
                //if (cD_Candidate.LabTestEnteredBy >0)
                //{
                //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                //}
                ViewBag.JobProfessionID = new SelectList(db.MS_JobProfession.OrderBy(s => s.JobProfessionName), "JobProfessionId", "JobProfessionName");
                ViewBag.PassportPlaceOfIssue = new SelectList(db.MS_District.OrderBy(s => s.DistrictName), "DistrictId", "DistrictName");
                ViewBag.VisaStampingCountryID = new SelectList(db.MS_VisaStampingCountry.OrderBy(s => s.CountryName), "CountryId", "CountryName");
                ViewBag.Address = new SelectList(db.MS_District.OrderBy(s => s.DistrictName), "DistrictId", "DistrictName");
                ViewBag.BloodGroup_RH = new SelectList(db.MS_BloodGroupRH.OrderBy(s => s.BloodGroupName), "BloodGroupId", "BloodGroupName");
                ViewBag.RecruitingAgencyID = new SelectList(db.MS_RecruitingAgency.OrderBy(s => s.RecruitingAgencyName), "RecruitingAgencyId", "RecruitingAgencyName");
                ViewBag.LabCode = cD_Candidate.LabCode;
                return View(cD_Candidate);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // POST: Candidate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection collection, int id, HttpPostedFileBase PhotoScanned)
        {
            if (Convert.ToString(Session["UserType"]) == "Admin" || Convert.ToString(Session["UserType"]) == "Reception")
            {
                CD_Candidate candidate = db.CD_Candidate.Find(id);
                try
                {
                    candidate.CandidateID = id;
                    candidate.CandidateName = collection["CandidateName"];
                    if (collection["Married"] == "true")
                    {
                        candidate.Married = true;
                    }else
                    {
                        candidate.Married = false;
                    }
                    candidate.Religion = collection["Religion"];
                    candidate.MedicalCenterID = 1;
                    candidate.GccCode = collection["GccCode"];
                    candidate.GccHMC = collection["GccHMC"];
                    candidate.VisaNo = collection["VisaNo"];
                    //candidate.LabCode = repo.GetLastLabNo() + 1;
                    candidate.VisaDate = collection["VisaDate"];
                    candidate.RQNoManpower = collection["RQNoManpower"];
                    candidate.GamcaNo = candidate.GccHMC;
                    if (collection["DateOfIssueByKDC_AD"] != "")
                    {
                        candidate.DateOfIssueByKDC_AD = DateTime.ParseExact(collection["DateOfIssueByKDC_AD"],"yyyy-MM-dd",null);
                    }
                    candidate.DateOfIssueByKDC_BS = collection["DateOfIssueByKDC_BS"];
                    if (collection["Address"] != "")
                    {
                        candidate.Address = Convert.ToInt32(collection["Address"]);
                        //candidate.Address = collection["Address"];
                    }
                    candidate.ContactNo = collection["ContactNo"];
                    candidate.Gender = collection["Gender"];
                    if (collection["DOB_AD"] != "")
                    {
                        candidate.DOB_AD = DateTime.ParseExact(collection["DOB_AD"],"yyyy-MM-dd",null);
                    }
                    candidate.DOB_BS = collection["DOB_BS"];
                    if (collection["Height_in_cm"] != "")
                    {
                        candidate.Height_in_cm = Convert.ToDecimal(collection["Height_in_cm"]);
                    }
                    if (collection["Weight_in_kg"] != "")
                    {
                        candidate.Weight_in_kg = Convert.ToDecimal(collection["Weight_in_kg"]);
                    }
                    candidate.Nationality = collection["Nationality"];
                    if (collection["JobProfessionID"] != "")
                    {
                        candidate.JobProfessionID = Convert.ToInt32(collection["JobProfessionID"]);
                    }
                    candidate.PassportNo = collection["PassportNo"];
                    if (collection["PassportDateAD"] != "")
                    {
                        candidate.PassportDateAD = Convert.ToDateTime(collection["PassportDateAD"]);
                    }
                    candidate.PassportDateBS = collection["PassportDateBS"];
                    if (collection["PassportPlaceOfIssue"] != "")
                    {
                        candidate.PassportPlaceOfIssue = Convert.ToInt32(collection["PassportPlaceOfIssue"]);
                    }
                    if (collection["RecruitingAgencyID"] != "")
                    {
                        candidate.RecruitingAgencyID = Convert.ToInt32(collection["RecruitingAgencyID"]);
                    }
                    if (collection["VisaStampingCountryID"] != "")
                    {
                        candidate.VisaStampingCountryID = Convert.ToInt32(collection["VisaStampingCountryID"]);
                    }
                    candidate.InvoiceNo = collection["InvoiceNo"];
                    if (collection["Allergy"] != "")
                    {
                        candidate.Allergy = Convert.ToBoolean(collection["Allergy"]);
                    }
                    candidate.Others = collection["Others"];
                    //candidate.FingerPrint = collection["FingerPrint"];
                    //candidate.FingerPrintRemarks = collection["FingerPrintRemarks"];
                    //candidate.PhotoCamera = collection["PhotoCamera"];
                    candidate.PhotoScanned = collection["OldPhoto"];
                    if (PhotoScanned != null)
                    {

                        string[] fileext = PhotoScanned.FileName.Split('.');                       
                        string fileName = PhotoScanned.FileName;
                        string path = "~/images/scanned";
                        /* if (!System.IO.Directory.Exists(Server.MapPath(path)))
                         {
                             System.IO.Directory.CreateDirectory(Server.MapPath(path));
                         } */
                        string filePath = Path.Combine(Server.MapPath(path), Path.GetFileName(fileName));
                        PhotoScanned.SaveAs(filePath);
                        candidate.PhotoScanned = fileName;
                    }
                    candidate.Barcode = collection["Barcode"];

                    candidate.RightEye = collection["RightEye"];
                    candidate.RightEar = collection["RightEar"];
                    candidate.LeftEye = collection["LeftEye"];
                    candidate.LeftEar = collection["LeftEar"];
                    candidate.BloodPressure = collection["BloodPressure"];
                    candidate.Heart = collection["Heart"];
                    candidate.Lungs = collection["Lungs"];
                    candidate.Chest = collection["Chest"];
                    candidate.Abdomen = collection["Abdomen"];
                    candidate.Hernia = collection["Hernia"];
                    candidate.Veins = collection["Veins"];
                    candidate.Extermities = collection["Extermities"];
                    candidate.Deformities = collection["Deformities"];
                    candidate.Skin = collection["Skin"];
                    candidate.Clinical = collection["Clinical"];
                    candidate.Cns = collection["Cns"];
                    candidate.Pshychiatry = collection["Pshychiatry"];
                    //candidate.CandidateDetailsEnteredBy = 1;
                    //candidate.CandidateDetailsEnteredBy = Convert.ToInt32(Session["UserId"]);
                    candidate.LastUpdatedBy = Convert.ToInt32(Session["UserId"]);
                    candidate.LastUpdatedDate = DateTime.Now;
                    //candidate.LabNoIdThisYear = DateTime.Now.Year;

                    repo.EditCandidate(candidate);
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
                    return RedirectToAction("Edit", new { id = id });
                }
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // GET: Candidate/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Convert.ToString(Session["UserType"]) == "Admin" || Convert.ToString(Session["UserType"]) == "Reception")
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                CD_Candidate cD_Candidate = db.CD_Candidate.Find(id);
                if (cD_Candidate == null)
                {
                    return HttpNotFound();
                }
                ViewBag.JobProfessionID = new SelectList(db.MS_JobProfession.OrderBy(s => s.JobProfessionName), "JobProfessionId", "JobProfessionName");
                ViewBag.PassportPlaceOfIssue = new SelectList(db.MS_District.OrderBy(s => s.DistrictName), "DistrictId", "DistrictName");
                ViewBag.VisaStampingCountryID = new SelectList(db.MS_VisaStampingCountry.OrderBy(s => s.CountryName), "CountryId", "CountryName");
                ViewBag.Address = new SelectList(db.MS_District.OrderBy(s => s.DistrictName), "DistrictId", "DistrictName");
                ViewBag.BloodGroup_RH = new SelectList(db.MS_BloodGroupRH.OrderBy(s => s.BloodGroupName), "BloodGroupId", "BloodGroupName");
                ViewBag.RecruitingAgencyID = new SelectList(db.MS_RecruitingAgency.OrderBy(s => s.RecruitingAgencyName), "RecruitingAgencyId", "RecruitingAgencyName");
                return View(cD_Candidate);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        public ActionResult ChangeStatus(int id)
        {
            var detail = repo.GetCandidateById(id);
            return View(detail);
        }

        [HttpPost]
        public ActionResult ChangeStatus(FormCollection collection, int id)
        {
            CD_Candidate candidate = repo.GetCandidateById(id);
            //candidate.FitStatus = Convert.ToBoolean(collection["FitStatus"]);
            if (collection["Status"] == "Fit")
            {
                candidate.Status = "Fit";
            }
            else if (collection["Status"] == "Unfit")
                {
                candidate.Status = "Unfit";
            }
            else
            {
                candidate.Status = "Pending";
            }
            candidate.UnfitRemarks = collection["UnfitRemarks"];
            repo.ChangeStatus(candidate, id);
            return RedirectToAction("Index");
        }

        public ActionResult GenerateRVNo(string date = "")
        {
			return View();
            //repo.GenerateRVNoToday(date);
            //return RedirectToAction("Index");
        }

		[HttpPost]
		public ActionResult GenerateRVNo(FormCollection collection)
		{
			var date = "";
			if (collection["Date"] != null && collection["Date"] != "")
			{
				DateTime Date = Convert.ToDateTime(collection["Date"]);
				date = Date.ToString("yyyy-MM-dd");
			}
			
			repo.GenerateRVNoToday(date);
			return RedirectToAction("Index");
		}

        // POST: Candidate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Convert.ToString(Session["UserType"]) == "Admin" || Convert.ToString(Session["UserType"]) == "Reception")
            {
                CD_Candidate cD_Candidate = db.CD_Candidate.Find(id);
                db.CD_Candidate.Remove(cD_Candidate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        public string UploadImage(HttpPostedFileBase file)
        {
            file.SaveAs(Server.MapPath("~/images/camera" + file.FileName));
            return "OK";
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
