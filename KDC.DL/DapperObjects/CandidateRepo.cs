using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using KDC.DL.Models;
using KDC.DL.ViewModel;

namespace KDC.DL.DapperObjects
{
    public class CandidateRepo
    {
        public List<CandidateVM> GetCandidatesList()
        {
            string query = "Select TOP 100 c.*, d.DistrictName, v.CountryName Country, j.JobProfessionName Job, " +
                " c.RQNoManpower, c.DateOfIssueByKDC_AD, c.CandidateDetailsEnteredDate from CD_Candidate c " +
                " left join MS_District d on d.DistrictId = c.Address" +
                " left join MS_VisaStampingCountry v on v.CountryId = c.VisaStampingCountryID" +
                " left join MS_JobProfession j on j.JobProfessionId = c.JobProfessionId" +
                " order by CandidateID desc";
                
                

            using (var db = DBHelper.GetDbConnection())
            {
                return db.Query<CandidateVM>(query).ToList();
            }
        }
        public int AddCandidateThumb(CandidateThumbVM model)
        {
            string sql = "insert into CD_Candidate " +
                "(CandidateName, PassportNo, Gender, FingerPrint, FingerPrintRemarks,PhotoCamera,CandidateDetailsEnteredDate) " +
                "values " +
                "(@CandidateName, @PassportNo, @Gender, @FingerPrint, @FingerPrintRemarks,@PhotoCamera,@CandidateDetailsEnteredDate) select SCOPE_IDENTITY()";

            using (var db = DBHelper.GetDbConnection())
            {
                db.Dispose();
                return db.Query<int>(sql, model).SingleOrDefault();
                
            }
        }
        public List<CandidateRepo> GetCandidateList(string fromdate="",string todate="")
        {
            string sql = "select CandidateName, PassportNo, Gender, FingerPrint, FingerPrintRemarks,PhotoCamera,CandidateDetailsEnteredDate from CD_Candidate where 1=1 ";
            if (string.IsNullOrEmpty(fromdate))
            {
				sql += " and CandidateDetailsEnteredDate>='" + DateTime.Today.ToString("yyyy-MM-dd") + "'";
			}
            else
            {
				sql += " and CandidateDetailsEnteredDate>='" + fromdate + "'";
            }
            if (string.IsNullOrEmpty(todate))
            {
				sql += " and CandidateDetailsEnteredDate<='" + DateTime.Today.ToString("yyyy-MM-dd") + "'";
			}
            else
            {
				sql += " and CandidateDetailsEnteredDate<='" + todate + "'";
			}

            using (var db = DBHelper.GetDbConnection())
            {
                db.Dispose();
                return db.Query<CandidateRepo>(sql).ToList();

            }
        }

        public void AddCandidate(CD_Candidate candidate)
        {
            string query = "Insert into CD_Candidate (MedicalCenterId, Married, Religion, GccCode, GccHMC, LabCode, VisaNo, VisaDate, RQNoManPower, GamcaNo, DateOfIssueByKDC_AD," +
                "DateOfIssueByKDC_BS, CandidateName, Address, ContactNo, Gender, DOB_AD, DOB_BS, Height_in_cm, Weight_in_kg," +
                "Nationality, JobProfessionId, PassportNo, PassportDateAD, PassportDateBS, PassportPlaceOfIssue, RecruitingAgencyID," +
                "VisaStampingCountryID, InvoiceNo, Allergy, Others, FingerPrint, FingerPrintRemarks, PhotoScanned, PhotoCamera," +
                "Barcode, CandidateDetailsEnteredBy, CandidateDetailsEnteredDate, LabNoIdThisYear, RightEye, LeftEye, RightEar, LeftEar" +
                ", BloodPressure, Heart, Lungs, Chest, Abdomen, Hernia, Veins, Extermities, Deformities, Skin, Clinical, Cns, Pshychiatry,Status, RVNoToday) " +
                "values" +
                "(@MedicalCenterId, @Married, @Religion, @GccCode, @GccHMC, @LabCode, @VisaNo, @VisaDate, @RQNoManPower, @GamcaNo, @DateOfIssueByKDC_AD," +
                "@DateOfIssueByKDC_BS, Upper(@CandidateName), @Address, @ContactNo, @Gender, @DOB_AD, @DOB_BS, @Height_in_cm, @Weight_in_kg," +
                "@Nationality, @JobProfessionId, @PassportNo, @PassportDateAD, @PassportDateBS, @PassportPlaceOfIssue, @RecruitingAgencyID," +
                "@VisaStampingCountryID, @InvoiceNo, @Allergy, @Others, @FingerPrint, @FingerPrintRemarks, @PhotoScanned, @PhotoCamera," +
                "@Barcode, @CandidateDetailsEnteredBy, @CandidateDetailsEnteredDate, @LabNoIdThisYear, @RightEye, @LeftEye, @RightEar, @LeftEar" +
                ", @BloodPressure, @Heart, @Lungs, @Chest, @Abdomen, @Hernia, @Veins, @Extermities, @Deformities, @Skin, @Clinical, @Cns, @Pshychiatry,'Fit', @RVNoToday) ";
            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(query, candidate);
                db.Dispose();
            }
        }

        public void EditCandidate(CD_Candidate candidate)
        {
            string query = "Update CD_Candidate set " +
                "MedicalCenterId = @MedicalCenterId, Married = @Married, Religion = @Religion, GccCode = @GccCode, GccHMC = @GccHMC, VisaNo = @VisaNo, VisaDate = @VisaDate, RQNoManPower = @RQNoManPower, GamcaNo = @GamcaNo, DateOfIssueByKDC_AD = @DateOfIssueByKDC_AD, " +
                "DateOfIssueByKDC_BS = @DateOfIssueByKDC_BS, CandidateName = @CandidateName, Address = @Address, ContactNo = @ContactNo, Gender = @Gender, DOB_AD = @DOB_AD, DOB_BS = @DOB_BS, Height_in_cm = @Height_in_cm, Weight_in_kg = @Weight_in_kg, " +
                "Nationality = @Nationality, JobProfessionId = @JobProfessionId, PassportNo = @PassportNo, PassportDateAD = @PassportDateAD, PassportDateBS = @PassportDateBS, PassportPlaceOfIssue = @PassportPlaceOfIssue, RecruitingAgencyID = @RecruitingAgencyID, " +
                "VisaStampingCountryID = @VisaStampingCountryID, InvoiceNo = @InvoiceNo, Allergy = @Allergy, Others = @Others, FingerPrint = @FingerPrint, FingerPrintRemarks = @FingerPrintRemarks, PhotoScanned = @PhotoScanned, PhotoCamera = @PhotoCamera, " +
                "Barcode = @Barcode, LastUpdatedBy = @LastUpdatedBy, LastUpdatedDate = @LastUpdatedDate, LabNoIdThisYear = @LabNoIdThisYear, RightEye = @RightEye, LeftEye = @LeftEye, RightEar = @RightEar, LeftEar = @LeftEar, " +
                "BloodPressure = @BloodPressure, Heart = @Heart, Lungs = @Lungs, Chest = @Chest, Abdomen = @Abdomen, Hernia = @Hernia, Veins = @Veins, Extermities = @Extermities, Deformities = @Deformities, Skin = @Skin, Clinical = @Clinical, Cns = @Cns, Pshychiatry = @Pshychiatry " +
                "where CandidateID = @CandidateID";

            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(query, candidate);
                db.Dispose();
            }
        }

        public int GetLastLabNo()
        {
            string query = "Select LabCode from CD_Candidate where CandidateID = (Select max(CandidateID) from CD_Candidate)";

            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<int>(query).SingleOrDefault();
                return result;
            }
        }

        public void LabEntry(CD_Candidate cD_Candidate)
        {
            string query = "Update CD_Candidate set " +
                "Hb = @Hb, TC_in_cumm = @TC_in_cumm, HIV_1_2 = @HIV_1_2, " +
                "DC_N = @DC_N, DC_L = @DC_L, DC_M = @DC_M, DC_E = @DC_E, DC_B = @DC_B, " +
                "Sugar = @Sugar, Albumin = @Albumin, HBsAG = @HBsAG, SGOT_Per = @SGOT_Per, Anti_HCV = @Anti_HCV, " +
                "Creat_Block = @Creat_Block, TPHA = @TPHA, SGPT_Per = @SGPT_Per, Alk_Pho_Per = @Alk_Pho_Per, " +
                "TPro_Per = @TPro_Per, Urea_Per = @Urea_Per, ESR_Per = @ESR_Per, @VDRL = @VDRL, " +
                "Bill_T_Per = @Bill_T_Per, GGT_Per = @GGT_Per, MP = @MP, MF = @MF, Bil_D_Per = @Bil_D_Per, " +
                "BloodGroup_RH = @BloodGroup_RH, Stool_RE = @Stool_RE, Other = @Other, LabTestEnteredBy = @LabTestEnteredBy, " +
                "LabTestEnteredDate = @LabTestEnteredDate, Urine_Re_Me = @Urine_Re_Me, Micros_Exam = @Micros_Exam, Albumin_Per = @Albumin_Per, " +
                "Usugar = @Usugar, Ualbumin = @Ualbumin, Helminthes = @Helminthes, " +
                "Giardia = @Giardia, Salmonella = @Salmonella, Malaria = @Malaria, Haemo = @Haemo, Microf = @Microf, " +
                "FBS = @FBS, LFT = @LFT," +
                "Creatinine = @Creatinine, Pregnancy = @Pregnancy, Remarks = @Remarks " +
                "where CandidateID = @CandidateID";

            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(query, cD_Candidate);
                db.Dispose();
            }
        }

        public List<CandidateVM> GetLabRecordById(int id= 0, int year= 0, int country = 0,string fromdate = "", string todate="", string status="")
        {
            string query = "Select c.CandidateID, c.CandidateName, c.LabCode, c.VisaNo, c.VisaStampingCountryID, c.LabTestEnteredBy, " +
                " c.GccHMC, c.RQNoManpower, c.DateOfIssueByKDC_AD, c.CandidateDetailsEnteredDate, c.Status, c.UnfitRemarks, " +
                " v.CountryName Country, j.JobProfessionName Job, c.PassportNo from CD_Candidate c " +
                " left join MS_JobProfession j on j.JobProfessionId = c.JobProfessionId " +
                " left join MS_VisaStampingCountry v on c.VisaStampingCountryID = v.CountryId " +
                " where 1=1 ";

            if (id != 0 )
            {
                query += " and c.LabCode = " + id + "";
            }
            else
            {
                query += "";
            }

            if (year != 0)
            {
                query += " and c.LabNoIdThisYear = " + year + "";
            }
            else
            {
                query += "";
            }

            if (country != 0)
            {
                query += " and c.VisaStampingCountryID = " + country + "";
            }

            if (string.IsNullOrEmpty(fromdate))
            {
                //query += " and c.CandidateDetailsEnteredDate >='" + DateTime.Today.ToString("yyyy-MM-dd") + "'";
                query += "";
            }
            else
            {
                query += " and c.CandidateDetailsEnteredDate >='" + fromdate + "'";
            }
            if (string.IsNullOrEmpty(todate))
            {
                //query += " and c.CandidateDetailsEnteredDate <='" + DateTime.Today.ToString("yyyy-MM-dd") + "'";
                query += "";
            }
            else
            {
                query += " and c.CandidateDetailsEnteredDate <='" + todate + "'";
            }

			if (status == "All")
			{
				query += "";
			}
			if (status == "New")
			{
				query += " and c.CandidateDetailsEnteredDate = '" + DateTime.Today.ToString("yyyy-MM-dd") + "'";
			}
			if (status == "Pending")
			{
				query += " and c.Status = 'Pending'";
			}
			if (status == "Fit")
			{
				query += " and c.Status = 'Fit'";
			}
			if (status == "Unfit")
			{
				query += " and c.Status = 'Unfit'";
			}

            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<CandidateVM>(query).ToList();
                return result;
            }
        }

        public void ChangeStatus(CD_Candidate candidate, int id)
        {
            //string query = "Update CD_Candidate set Status = "+ @Status, UnfitRemarks = @UnfitRemarks where CandidateID = " + id+ "";
            string query = "Update CD_Candidate set Status = '" + candidate.Status + "', UnfitRemarks = '" + candidate.UnfitRemarks + "' where CandidateID = " + id;
            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(query);
                db.Close();
            }
        }

        public CD_Candidate GetCandidateById(int id)
        {
            string query = "Select * from CD_Candidate where CandidateId = " + id + "";
            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<CD_Candidate>(query).SingleOrDefault();
                return result;
            }
        }

        public int CheckTodayRV()
        {
            string query = "Select max(RVNoToday) from CD_Candidate where CandidateDetailsEnteredDate = '" + DateTime.Today.ToString("yyyy-MM-dd") + "'";
            using (var db = DBHelper.GetDbConnection())
            {
                if (query == null || query == "")
                {
                    return 0;
                }
                else
                {
                    return db.Query<int>(query).SingleOrDefault();
                }
            }
        }

        public void GenerateRVNoToday(string date="")
        {
            using (var db = DBHelper.GetDbConnection())
            {
                string query = "exec GenerateRVNoToday";
                if (string.IsNullOrEmpty(date))
                {
                    var a = DateTime.Today.ToString("yyyy-MM-dd");
                    query += " '" + a + "'";
                }
                else
                {
                    query += " '" + date + "'";
                }

                db.Execute(query);
                db.Close();
            }
        }
    }
}
