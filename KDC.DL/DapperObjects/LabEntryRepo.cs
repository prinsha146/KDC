using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KDC.DL.Models;
using KDC.DL.ViewModel;
using Dapper;

namespace KDC.DL.DapperObjects
{
    public class LabEntryRepo
    {

        public void LabEntry(CD_Candidate cD_Candidate)
        {
            string query = "UPDATE CD_Candidate SET " +
                " UHb = '"+ cD_Candidate.UHb+ "', UTC_in_cumm = '" + cD_Candidate.UTC_in_cumm+ "', UHIV_1_2 = '" + cD_Candidate.UHIV_1_2+"', " +
				"BDC_N = '" + cD_Candidate.BDC_N+ "', BDC_L = '" + cD_Candidate.BDC_L+ "', BDC_M = '" + cD_Candidate.BDC_M+ "', BDC_E = '" + cD_Candidate.BDC_E+ "', BDC_B = '" + cD_Candidate.BDC_B+ "', Platelets = '" + cD_Candidate.Platelets+"', " +
				"BSugar = '" + cD_Candidate.BSugar+ "', BAlbumin = '" + cD_Candidate.BAlbumin+ "', UHBsAG = '" + cD_Candidate.UHBsAg+ "', SGOT_Per = '" + cD_Candidate.SGOT_Per+ "', UAnti_HCV = '" + cD_Candidate.UAnti_HCV+"', " +
				"Creat_Block = '" + cD_Candidate.Creat_Block+ "', UTPHA = '" + cD_Candidate.UTPHA+ "', SGPT_Per = '" + cD_Candidate.SGPT_Per+ "', Alk_Pho_Per = '" + cD_Candidate.Alk_Pho_Per+"', " +
				"TPro_Per = '" + cD_Candidate.TPro_Per+ "', Urea_Per = '" + cD_Candidate.Urea_Per+ "', ESR_Per = '" + cD_Candidate.ESR_Per+ "', UVDRL = '" + cD_Candidate.UVDRL+"', " +
				"Bill_T_Per = '" + cD_Candidate.Bill_T_Per+ "', GGT_Per = '" + cD_Candidate.GGT_Per+ "', UMP = '" + cD_Candidate.UMP+ "', UMF = '" + cD_Candidate.UMF+ "', Bil_D_Per = '" + cD_Candidate.Bil_D_Per+"', " +
				"BloodGroup_RH = '" + cD_Candidate.BloodGroup_RH+ "', Stool_RE = '" + cD_Candidate.Stool_RE+ "', Other = '" + cD_Candidate.Other+ "', LabTestEnteredBy = '" + cD_Candidate.LabTestEnteredBy+"', " +
				"VaccinationBatchId = '" + cD_Candidate.VaccinationBatchId+ "', VaccinationDataEnteredBy = '" + cD_Candidate.VaccinationDataEnteredBy+ "', DateOfVaccination = '" + cD_Candidate.DateOfVaccination+"', " +
				"LabTestEnteredDate = '" + cD_Candidate.LabTestEnteredDate+ "', Urine_Re_Me = '" + cD_Candidate.Urine_Re_Me+ "', Micros_Exam = '" + cD_Candidate.Micros_Exam+ "', Albumin_Per = '" + cD_Candidate.Albumin_Per+"', " +
				"Usugar = '" + cD_Candidate.Usugar+ "', Ualbumin = '" + cD_Candidate.Ualbumin+ "', Helminthes = '" + cD_Candidate.Helminthes+"', " +
				"Giardia = '" + cD_Candidate.Giardia+ "', Salmonella = '" + cD_Candidate.Salmonella+ "', Malaria = '" + cD_Candidate.Malaria+ "', Haemo = '" + cD_Candidate.Haemo+ "', Microf = '" + cD_Candidate.Microf+"', " +
				"FBS = '" + cD_Candidate.FBS+ "', LFT = '" + cD_Candidate.LFT+ "', Creatinine = '" + cD_Candidate.Creatinine+ "', Pregnancy = '" + cD_Candidate.Pregnancy+"', " +
				"Remarks = '" + cD_Candidate.Remarks+ "', FitStatus = '" + cD_Candidate.FitStatus+ "', UnfitRemarks = '" + cD_Candidate.UnfitRemarks+"' " +
                " WHERE CandidateID = "+ cD_Candidate.CandidateID;


			using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Execute(query, cD_Candidate);
                db.Dispose();
            }
        }

        public CD_Candidate GetLabRecordById(int id)
        {
            string query = "Select * from CD_Candidate where CandidateID = " + id + "";

            using (var db = DBHelper.GetDbConnection())
            {
                return db.Query<CD_Candidate>(query).SingleOrDefault();
            }
        }

        public List<CandidateVM> GetLabRecordByLabId(int id, int year)
        {
            string query = "Select c.*, v.CountryName Country from CD_Candidate c" +
                " left join MS_VisaStampingCountry v on c.VisaStampingCountryID = v.CountryId" + 
                " where LabCode = " + id + " and LabNoIdThisYear = " + year + "";

            using (var db = DBHelper.GetDbConnection())
            {
                return db.Query<CandidateVM>(query).ToList();
            }
        }



        public List<CandidateVM> GetLabRecord(int id)
        {
            string query = "Select c.CandidateID, c.CandidateName, d.DistrictName, c.ContactNo, c.Gender, c.DOB_AD, b.BloodGroupName," +
                " c.LabCode, c.VisaNo, c.VisaStampingCountryID, c.LabTestEnteredBy," +
                " v.CountryName Country, j.JobProfessionName Job, c.PassportNo from CD_Candidate c" +
                " left join MS_JobProfession j on j.JobProfessionId = c.JobProfessionId" +
                " left join MS_VisaStampingCountry v on c.VisaStampingCountryID = v.CountryId" +
                " left join MS_District d on d.DistrictId = c.Address" +
                " left join MS_BloodGroupRH b on b.BloodGroupId = c.BloodGroup_RH" +
                " where CandidateID = " + id + "";

            using (var db = DBHelper.GetDbConnection())
            {
                return db.Query<CandidateVM>(query).ToList();
            }
        }

        public List<CandidateVM> GetLabEntryList()
        {
            string query = "Select Top 30 c.*, d.DistrictName, b.BloodGroupName, j.JobProfessionName Job, " +
                "DATEDIFF(year, c.DOB_AD, GETDATE()) Age from CD_Candidate c " +
                "left join MS_District d on d.DistrictId = c.Address " +
                "left join MS_BloodGroupRH b on b.BloodGroupId = c.BloodGroup_RH " +
                "left join MS_JobProfession j on j.JobProfessionId = c.JobProfessionId " +
                "where c.CandidateDetailsEnteredDate >= DATEADD(MONTH, -3, GETDATE())" +
                "order by c.CandidateDetailsEnteredDate desc";

            using (var db = DBHelper.GetDbConnection())
            {
                return db.Query<CandidateVM>(query).ToList();
            }
        }

        public int GetMaxVaccinationBatch()
        {
            string query = "Select Max(VaccinationBatchId) from MS_VaccinationBatch";

            using (var db = DBHelper.GetDbConnection())
            {
                return db.Query<int>(query).SingleOrDefault();
            }
        }
    }
}
