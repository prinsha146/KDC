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
    public class PatientLabTestDetailRepo
    {
        public List<PatientLabTestDetailVM> GetPatientTestDetail(int id)
        {
            string query = "Select d.*, s.ServiceName, g.GroupName, p.PatientName, p.LabCode, p.Gender, l.Particular," +
				" l.Datatype DataType, l.Unit ParticulatUnit from BL_PatientLabTestDetail d" +
                " left join SV_Service s on s.ServiceId = d.ServiceId" +
                " left join SV_ServiceGroup g on g.GroupId = d.GroupId" +
                " left join BL_Patient p on p.PatientId = d.PatientId" +
                " left join SV_ServiceLabDetail l on l.DetailId = d.ServiceLabDetailId" +
                " where d.IsDeleted = 0 and d.PatientId = " + id;
            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<PatientLabTestDetailVM>(query).ToList();
                return result;
            }
        }

        //public PatientLabTestDetailVM GetPatientDetail(int id)
        //{
        //    string query = "Select PatientId, PatientName, LabCode, InvoiceNo" +
        //        " from BL_Patient where IsDeleted = 0 and PatientId = " + id;
        //    using (var db = DBHelper.GetDbConnection())
        //    {
        //        var result = db.Query<PatientLabTestDetailVM>(query).SingleOrDefault();
        //        return result;
        //    }
        //}

        public void EditLabTestDetail(BL_PatientLabTestDetail labTest, int id)
        {
            string query = "Update BL_PatientLabTestDetail set" +
                " Result = UPPER(@Result), IsNormal = @IsNormal, EnteredBy = @EnteredBy, EnteredDate = @EnteredDate, IsResultAdded = @IsResultAdded" +
                " where PatientLabTestDetailId = " + id;

            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(query, labTest);
                db.Close();
            }
        }

        public string GetGender(int id)
        {
            string query = "Select p.Gender from BL_Patient p" +
                " left join BL_PatientLabTestDetail d on d.PatientId = p.PatientId" +
                " where d.PatientLabTestDetailId = " + id;
            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<string>(query).SingleOrDefault();
                return result;
            }
        }

        public string CheckNormal(string result, int id, string gender, string serviceId)
        {
            string sql = "Select count(DetailId) from SV_ServiceLabDetail sv" +
                " left join BL_PatientLabTestDetail p on p.ServiceLabDetailId = sv.DetailId" +
                " where sv.DetailId = '" + serviceId + "' and maxvalue is null and minvalue is null";

            using (var db = DBHelper.GetDbConnection())
            {
                int a = db.Query<int>(sql).SingleOrDefault();
                if (a < 1)
                {
                    string query = "Select count(sv.DetailId) from SV_ServiceLabDetail sv" +
                     " left join BL_PatientLabTestDetail d on d.ServiceLabDetailId = sv.DetailId" +
                     " where '" + result + "' between maxvalue and minvalue" +
                     " and (sex = '" + gender + "' or sex = '(None)') " +
                     " and PatientLabTestDetailId = " + id;

                    int res = db.Query<int>(sql).SingleOrDefault();
                    if (res > 0)
                    {
                        return "Yes";
                    }
                    else
                    {
                        return "No";
                    }
                }
                else
                {
                    return "Yes";
                }

            }
        }

        public List<PatientLabTestDetailVM> GetServiceLabDetail(int id, string Gender)
        {
            string query = "select s.ServiceId, s.ServiceName, s.GroupId, g.GroupName, bl.Result, det.MAXVALUE," +
				" det.minvalue, bl.IsNormal, det.particular, det.unit ParticulatUnit, det.datatype" +
                " from BL_PatientLabTestDetail bl " +
                " left join SV_ServiceLabDetail det on det.detailid = bl.ServiceLabDetailId" +
                " left join SV_Service s on s.serviceid = bl.serviceid" +
                " left join SV_ServiceGroup g on g.GroupId = bl.groupId" +
                " where bl.PatientId = " + id + " and bl.IsDeleted = 0";

            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<PatientLabTestDetailVM>(query).ToList();
                return result;
            }
        }

		public List<PatientLabTestDetailVM> GetDistinctGroup(int id)
		{
			string query = "select distinct(s.GroupId), g.GroupName " +
				" from BL_PatientLabTestDetail bl " +
				" left join SV_Service s on s.serviceid = bl.serviceid" +
				" left join SV_ServiceGroup g on g.GroupId = bl.groupId" +
				" where bl.PatientId = " + id + " and bl.IsDeleted = 0";
			using (var db = DBHelper.GetDbConnection())
			{
				var result = db.Query<PatientLabTestDetailVM>(query).ToList();
				return result;
			}
		}

		public List<PatientLabTestDetailVM> GetDistinctService(int id)
		{
			string query = "select distinct(bl.ServiceId), s.ServiceName, s.GroupId " +
				" from BL_PatientLabTestDetail bl " +
				" left join SV_Service s on s.ServiceId = bl.ServiceId " +
				" where bl.PatientId = " + id + " and bl.IsDeleted = 0";

			using (var db = DBHelper.GetDbConnection())
			{
				var result = db.Query<PatientLabTestDetailVM>(query).ToList();
				return result;
			}
		}

        public PatientLabTestDetailVM GetPatientDetail(int id)
        {
            string query = "Select Top 1 p.PatientName, " +
				" Cast(DATENAME(month, p.InvoiceDateAD) as varchar) + ' '+ cast(month(p.InvoiceDateAD) as varchar)+ ', ' + cast(year(p.InvoiceDateAD) as varchar) as InvoiceDate," +
				" p.InvoiceDateAD, p.InvoiceDateBS, p.Age, p.Gender, p.LabCode," +
				" Cast(DATENAME(month, pd.EnteredDate) as varchar) + ' '+ cast(month(pd.EnteredDate) as varchar)+ ', ' + cast(year(pd.EnteredDate) as varchar) as LabDate, " +
                " p.Address, r.RefererName Referrer, p.InvoiceNo" +
                " from BL_Patient p" +
                " left join MS_Referer r on r.RefererId = p.ReferrerId" +
				" left join BL_PatientLabTestDetail pd on pd.PatientId = p.PatientId"+
                " where p.PatientId = " + id + " and p.IsDeleted = 0";

            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<PatientLabTestDetailVM>(query).SingleOrDefault();
                return result;
            }
        }

		public string GetDate(int id)
		{
			string query = "Select InvoiceDateBS from BL_Patient where PatientId = " + id;
			using (var db = DBHelper.GetDbConnection())
			{
				return db.Query<string>(query).SingleOrDefault();
			}
		}
    }
}
