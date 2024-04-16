using Dapper;
using KDC.DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KDC.DL;

namespace KDC.DL.DapperObjects
{
    public class MedicalReportTypeRepo
    {
        public List<MS_MedicalReportType> GetMedicalReportTypeList()
        {
            string query = "Select * from MS_MedicalReportType";

            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<MS_MedicalReportType>(query).ToList();
                db.Dispose();
                return result;
            }
        }

        public MS_MedicalReportType GetMedicalReportTypeById(int id)
        {
            string query = "Select * from MS_MedicalReportType where ReportTypeId = " + id + "";

            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<MS_MedicalReportType>(query).SingleOrDefault();
                db.Dispose();
                return result;
            }
        }

        public void AddMedicalReportType(MS_MedicalReportType reportType)
        {
            string query = "Insert into MS_MedicalReportType (ReportTypeName) " +
                "values (@ReportTypeName)";

            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(query, reportType);
                db.Dispose();
            }
        }

        public void EditMedicalReportType(MS_MedicalReportType reportType)
        {
            string query = "Update MS_MedicalReportType set ReportTypeName = @ReportTypeName" +
                           " where ReportTypeId = @ReportTypeId";

            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(query, reportType);
                db.Dispose();
            }
        }

        public void RemoveMedicalReportType(int id)
        {
            string query = "Delete from MS_MedicalReportType where ReportTypeId = " + id + "";
            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(query);
                db.Dispose();
            }
        }
    }
}