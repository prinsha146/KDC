using Dapper;
using KDC.DL;
using KDC.DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KDC.DL.DapperObjects
{
    public class VaccinationTypeRepo
    {
        public List<MS_VaccinationType> GetVaccinationTypeList()
        {
            string query = "Select * from MS_VaccinationType";

            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<MS_VaccinationType>(query).ToList();
                db.Dispose();
                return result;
            }
        }

        public MS_VaccinationType GetVaccinationTypeById(int id)
        {
            string query = "Select * from MS_VaccinationType where VaccinationTypeId = " + id + " ";

            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<MS_VaccinationType>(query).SingleOrDefault();
                db.Dispose();
                return result;
            }
        }

        public void AddVaccinationType(MS_VaccinationType vaccinationType)
        {
            string query = "Insert into MS_VaccinationType (VaccinationTypeName) " +
                "values (@VaccinationTypeName)";

            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(query, vaccinationType);
                db.Dispose();
            }
        }

        public void EditVaccinationType(MS_VaccinationType vaccinationType)
        {
            string query = "Update MS_VaccinationType set VaccinationTypeName = @VaccinationTypeName" +
                           " where VaccinationTypeId = @VaccinationTypeId";

            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(query, vaccinationType);
                db.Dispose();
            }
        }

        public void RemoveVaccinationType(int id)
        {
            string query = "Delete From MS_VaccinationType where VaccinationTypeId = " + id + "";
            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(query);
                db.Dispose();
            }
        }
    }
}