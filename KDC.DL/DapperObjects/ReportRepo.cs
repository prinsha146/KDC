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
    public class ReportRepo
    {
        public VaccinationReportVM GetLaboratoryReport(int CandidateId)
        {
            string query = "Select c.*, v.CountryName from CD_Candidate c " +
                "left join MS_VisaStampingCountry v on c.VisaStampingCountryId = v.CountryId " +
                "where CandidateID = "+ CandidateId + "";
            using (var db = DBHelper.GetDbConnection())
            {
                return db.Query<VaccinationReportVM>(query).SingleOrDefault();
            }
        }
		public List<MedicalStatusVM> GetMedicalStatusReport(string date)
		{
			string query = "select CandidateId, CandidateName,PassportNo,RQNoManpower MofaNo,DateOfIssueByKDC_AD IssueDate,IsNULL(Status,'') Status,'Kantipur Diagnostic Center' MedicalCenterName"+
			" from cd_candidate "+
			" where DateOfIssueByKDC_AD = '"+ date + "' and Status = 'FIT' and RQNoManpower is not Null and VisaStampingCountryId = 1" +
			" order by candidateName";
			using (var db = DBHelper.GetDbConnection())
			{
				return db.Query<MedicalStatusVM>(query).ToList();
			}
		}

		public VaccinationReportVM GetLabReport(int CandidateId)
        {
            string query = "Select c.LabCode, c.CandidateName, c.CandidateID, c.Gender, c.PassportNo, c.Nationality, c.DateOfVaccination, c.PhotoScanned, " +
                "v.*, vacc.* from CD_Candidate c " +
                "left join MS_VaccinationBatch v on c.VaccinationBatchId = v.VaccinationBatchId " +
                "left join MS_VaccinationType vacc on vacc.VaccinationTypeId = v.VaccinationTypeId " +
                "where c.CandidateID = " + CandidateId +"";
            using (var db = DBHelper.GetDbConnection())
            {
                return db.Query<VaccinationReportVM>(query).SingleOrDefault();
            }
        }

        public VaccinationReportVM GetLabReportByLabCode(int LabCode, int year)
        {
            string query = "Select c.*, visa.CountryName, " +
                "v.*, vacc.*, b.BloodGroupName, DATEDIFF(year, c.DOB_AD, GetDate()) Age from CD_Candidate c " +
                "left join MS_VaccinationBatch v on c.VaccinationBatchId = v.VaccinationBatchId " +
                "left join MS_VaccinationType vacc on vacc.VaccinationTypeId = v.VaccinationTypeId " +
                "left join MS_BloodGroupRH b on b.BloodGroupId = c.BloodGroup_RH " +
                "left join MS_VisaStampingCountry visa on visa.CountryId = c.VisaStampingCountryId " +
                "where c.LabCode = " + LabCode + " and c.LabNoIdThisYear = " + year;
            using (var db = DBHelper.GetDbConnection())
            {
                return db.Query<VaccinationReportVM>(query).SingleOrDefault();
            }
        }

        public List<VaccinationReportVM> GetLabReportByLabRange(int LabFrom, int LabTo)
        {
            string query = "Select c.*, visa.CountryName, " +
                "v.*, vacc.*, b.BloodGroupName, DATEDIFF(year, c.DOB_AD, GetDate()) Age from CD_Candidate c " +
                "left join MS_VaccinationBatch v on c.VaccinationBatchId = v.VaccinationBatchId " +
                "left join MS_VaccinationType vacc on vacc.VaccinationTypeId = v.VaccinationTypeId " +
                "left join MS_BloodGroupRH b on b.BloodGroupId = c.BloodGroup_RH " +
                "left join MS_VisaStampingCountry visa on visa.CountryId = c.VisaStampingCountryId " +
                "where c.LabNoIdThisYear = '2019' and C.LabCode between " + LabFrom + " and " + LabTo + "";

            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<VaccinationReportVM>(query).ToList();
                return result;
            }
        }

		public List<VaccinationReportVM> GetMultipleVaccination(int LabFrom, int LabTo)
		{
			string query = "Select c.*, visa.CountryName, " +
				"v.*, vacc.*, b.BloodGroupName, DATEDIFF(year, c.DOB_AD, GetDate()) Age from CD_Candidate c " +
				"left join MS_VaccinationBatch v on c.VaccinationBatchId = v.VaccinationBatchId " +
				"left join MS_VaccinationType vacc on vacc.VaccinationTypeId = v.VaccinationTypeId " +
				"left join MS_BloodGroupRH b on b.BloodGroupId = c.BloodGroup_RH " +
				"left join MS_VisaStampingCountry visa on visa.CountryId = c.VisaStampingCountryId " +
				"where c.LabNoIdThisYear = '2019' and c.LabCode between " + LabFrom + " and " + LabTo + "";

			using (var db = DBHelper.GetDbConnection())
			{
				var result = db.Query<VaccinationReportVM>(query).ToList();
				return result;
			}
		}


		public string GetDoctorInfo(int id)
        {
            //string query = "Select DoctorId, DoctorName, Degree, Specialization from MS_Doctor" +
            //    " where DoctorId = "+ id + "";

            string query = "Select DoctorName from MS_Doctor where DoctorId = " + id;
            using (var db = DBHelper.GetDbConnection())
            {
                return db.Query<string>(query).SingleOrDefault();
            }
        }

		public MS_Doctor GetActiveDoctor()
		{
			string query = "Select * from MS_Doctor"+
				" where IsActive = 1 and IsDeleted = 0";
			using (var db = DBHelper.GetDbConnection())
			{
				var result =  db.Query<MS_Doctor>(query).SingleOrDefault();
				return result;
			}
		}
    }
}
