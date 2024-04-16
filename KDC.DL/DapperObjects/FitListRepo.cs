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
    public class FitListRepo
    {
        public CandidateVM GetCandidateFitStatus(int id)
        {
            string query = "Select CandidateID, LabCode, CandidateName, Nationality, PhotoScanned, PassportNo, PassportPlaceOfIssue, GccCode, GccHMC, RVNoToday, " +
                "JobProfessionID, VisaStampingCountryID, LabTestEnteredDate, Weight_in_kg, Height_in_cm, DATEDIFF(hour,DOB_AD,GETDATE())/8766 AS Age, Remarks, Status from CD_Candidate where CandidateID = " + id + "";

            using (var db = DBHelper.GetDbConnection())
            {
                return db.Query<CandidateVM>(query).SingleOrDefault();
            }
        }

        public List<CandidateVM> GetAllCandidate()
        {
            string query = "Select c.CandidateID, c.LabCode, c.CandidateName, c.Gender, c.PhotoScanned, c.PassportNo, c.BarCode, c.RVNoToday," +
                " DATEDIFF(hour,c.DOB_AD,GETDATE())/8766 AS Age, v.CountryName Country, c.CandidateDetailsEnteredDate" +
                " from CD_Candidate c left join MS_VisaStampingCountry v on v.CountryId = c.VisaStampingCountryId" +
                " where c.CandidateDetailsEnteredDate = '" + DateTime.Today.ToString("yyyy-MM-dd") + "'";
               
            using (var db = DBHelper.GetDbConnection())
            {
                return db.Query<CandidateVM>(query).ToList();
            }
        }

        public List<CandidateVM> GetAllCandidateByDate(string from="", string to="")
        {
            string query = "Select c.CandidateID, c.LabCode, c.CandidateName, c.Gender, c.PhotoScanned, c.PassportNo, c.BarCode, c.RVNoToday, " +
                " DATEDIFF(hour,c.DOB_AD,GETDATE())/8766 AS Age, v.CountryName Country, c.CandidateDetailsEnteredDate" +
                " from CD_Candidate c left join MS_VisaStampingCountry v on v.CountryId = c.VisaStampingCountryId" +
                " where 1=1";

            if (string.IsNullOrEmpty(from))
            {
                query += "";
            }
            else
            {
                query += " and c.CandidateDetailsEnteredDate >= '" + from + "'";
            }
            
            if (string.IsNullOrEmpty(to))
            {
                query += "";
            }
            else
            {
                query += " and c.CandidateDetailsEnteredDate <= '" + to + "'";
            }
            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<CandidateVM>(query).ToList();
                return result;
            }
        }

        public List<CD_Candidate> GetFitCandidateList()
        {
            string query = "Select CandidateID, LabCode, CandidateName, PassportNo, PassportPlaceOfIssue, GccCode, GccHMC, JobProfessionID, RVNoToday," +
                "JobProfessionID, VisaStampingCountryID, LabTestEnteredDate, Weight_in_kg, Height_in_cm, Remarks from CD_Candidate where Status = 'Fit'";

            using (var db = DBHelper.GetDbConnection())
            {
                return db.Query<CD_Candidate>(query).ToList();
            }
        }

        public List<CandidateVM> GetUnfitCandidateList()
        {
            string query = "Select CandidateID, LabCode, CandidateName, PassportNo, PhotoScanned, PassportPlaceOfIssue, GccCode, GccHMC, JobProfessionID, " +
				"VisaStampingCountryID, LabTestEnteredDate, Weight_in_kg, Height_in_cm, UnfitRemarks, DATEDIFF(hour,DOB_AD,GETDATE())/8766 AS Age, RVNoToday from CD_Candidate " +
                "where Status = 'UnFit' and Convert(date, LabTestEnteredDate) = '" + DateTime.Today.ToString("yyyy-MM-dd") + "'";

            using (var db = DBHelper.GetDbConnection())
            {
                return db.Query<CandidateVM>(query).ToList();
            }
        }

        public List<CandidateVM> GetUnfitCandidateListByDate(string from="", string to="")
        {
            string query = "Select CandidateID, LabCode, CandidateName, PassportNo, PhotoScanned, RVNoToday, " +
                "DATEDIFF(hour,DOB_AD,GETDATE())/8766 AS Age, UnfitRemarks from CD_Candidate where Status = 'UnFit' ";

            if (string.IsNullOrEmpty(from))
            {
                query += "";
            }
            else
            {
                query += " and Convert(date, LabTestEnteredDate) >= '" + from + "'";
            }
            if (string.IsNullOrEmpty(to))
            {
                query += "";
            }
            else
            {
                query += " and Convert(date, LabTestEnteredDate) <= '" + to + "'";
            }

            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<CandidateVM>(query).ToList();
                return result;
            }
        }
    }
}
