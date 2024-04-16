using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using KDC.DESKTOP.DO;
using KDC.DL.ViewModel;

namespace KDC.DESKTOP.DA
{
    public class CandidateDA
    {
        public static List<Candidate> GetCandidateList(string fromDate, string toDate)
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            string sql = "Select CandidateID, CandidateName, PassportNo,case when (DataLength(FingerPrint)=0 or FingerPrint is null) then 'Not-Taken' else 'Taken' end  Barcode,PhotoScanned,FingerPrint from CD_Candidate " +
				" where 1=1 and DateOfIssueByKDC_AD<='"+toDate+ "' and DateOfIssueByKDC_AD>='"+fromDate+ "' and (CodeFromExcel !='Y' or CodeFromexcel is null) order by CandidateName";
			
            List<Candidate> candidateList = new List<Candidate>();
            DbDataReader dr = oDatabaseHelper.ExecuteReader(sql, CommandType.Text);
            while (dr.Read())
            {
                DO.Candidate candidate = new DO.Candidate();
                candidate.CandidateID = Convert.ToInt32(dr["CandidateID"]);
                candidate.CandidateName = dr["CandidateName"].ToString();
                candidate.PassportNo = dr["PassportNo"].ToString();                
                candidate.Barcode = dr["Barcode"].ToString();
				candidate.PhotoScanned = dr["PhotoScanned"].ToString();
				candidate.FingerPrint = dr["FingerPrint"].ToString();
				candidateList.Add(candidate);
            }
            return candidateList;
        }
		//SearchCandidateByPassportNo
		public static Candidate SearchCandidateByPassportNo(string Password)
		{
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			string sql = "Select CandidateID, CandidateName, PassportNo, Barcode,PhotoScanned,FingerPrint from CD_Candidate where PassportNo='"+ Password + "'";

			Candidate candidate = new Candidate();
			DbDataReader dr = oDatabaseHelper.ExecuteReader(sql, CommandType.Text);
			while (dr.Read())
			{
				 candidate = new DO.Candidate();
				candidate.CandidateID = Convert.ToInt32(dr["CandidateID"]);
				candidate.CandidateName = dr["CandidateName"].ToString();
				candidate.PassportNo = dr["PassportNo"].ToString();
				candidate.Barcode = dr["Barcode"].ToString();
				candidate.PhotoScanned = dr["PhotoScanned"].ToString();
				candidate.FingerPrint = dr["FingerPrint"].ToString();
				//candidateList.Add(candidate);
			}
			return candidate;
		}
		public static int UpdateCandidateThumb(CandidateThumb candidate,bool UpdateThumb,bool UpdatePhoto)
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            string sql = "";
            if (UpdatePhoto && UpdateThumb)
            {
                sql = "Update CD_Candidate Set FingerPrint = @FingerPrint, FingerPrintRemarks = @FingerPrintRemarks, PhotoCamera = @PhotoCamera where CandidateId = @CandidateId";
                if (candidate.FingerPrint != null)
                    oDatabaseHelper.AddParameter("@FingerPrint", candidate.FingerPrint);
                else
                    oDatabaseHelper.AddParameter("@FingerPrint", DBNull.Value);
                if (candidate.FingerPrintRemarks != null)
                    oDatabaseHelper.AddParameter("@FingerPrintRemarks", candidate.FingerPrintRemarks);
                else
                    oDatabaseHelper.AddParameter("@FingerPrintRemarks", DBNull.Value);
                if (candidate.PhotoCamera != null)
                    oDatabaseHelper.AddParameter("@PhotoCamera", candidate.PhotoCamera);
                else
                    oDatabaseHelper.AddParameter("@PhotoCamera", DBNull.Value);
            }
            else if (UpdatePhoto && !UpdateThumb)
            {
                sql = "Update CD_Candidate Set PhotoCamera = @PhotoCamera where CandidateId = @CandidateId";
                if (candidate.PhotoCamera != null)
                    oDatabaseHelper.AddParameter("@PhotoCamera", candidate.PhotoCamera);
                else
                    oDatabaseHelper.AddParameter("@PhotoCamera", DBNull.Value);
            }
            else if (!UpdatePhoto && UpdateThumb)
            {
                sql = "Update CD_Candidate Set FingerPrint = @FingerPrint, FingerPrintRemarks = @FingerPrintRemarks where CandidateId = @CandidateId";
                if (candidate.FingerPrint != null)
                    oDatabaseHelper.AddParameter("@FingerPrint", candidate.FingerPrint);
                else
                    oDatabaseHelper.AddParameter("@FingerPrint", DBNull.Value);
                if (candidate.FingerPrintRemarks != null)
                    oDatabaseHelper.AddParameter("@FingerPrintRemarks", candidate.FingerPrintRemarks);
                else
                    oDatabaseHelper.AddParameter("@FingerPrintRemarks", DBNull.Value);
            }
            else
            {
                oDatabaseHelper.Dispose();
                return 0;
            }
            
            oDatabaseHelper.AddParameter("@CandidateId", candidate.CandidateId);
            try
            {
                int result= oDatabaseHelper.ExecuteNonQuery(sql, CommandType.Text);
                oDatabaseHelper.Dispose();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
                //oDatabaseHelper.Dispose();
            }
            
        }
        public static CandidateDetailVM GetCandidateDetailById(int id)
        {
            CandidateDetailVM candidate = null;
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            string qry = "Select CandidateName, PassportNo,CandidateId From CD_Candidate Where candidateId = " + id;
            DbDataReader dr = (DbDataReader)oDatabaseHelper.ExecuteReader(qry, CommandType.Text);
            try
            {
                while (dr.Read())
                {
                    candidate = new CandidateDetailVM();

                    candidate.CandidateID = id;
                    candidate.CandidateName = dr["CandidateName"].ToString();
                    candidate.PassportNo = dr["PassportNo"].ToString();
                                    }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            dr.Dispose();
            return candidate;
        }
        public static string GetCandidateImageById(int id)
        {
            string candidate = null;
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            string qry = "Select PhotoScanned From CD_Candidate Where candidateId = " + id;
            DbDataReader dr = (DbDataReader)oDatabaseHelper.ExecuteReader(qry, CommandType.Text);
            try
            {
                while (dr.Read())
                {
                    //candidate = new CandidateDetailVM();

                    //candidate.CandidateID = id;
                    candidate = dr["PhotoScanned"].ToString();
                    //candidate.PassportNo = dr["PassportNo"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            dr.Dispose();
            return candidate;
        }
    }
}
