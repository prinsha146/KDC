using Dapper;
using KDC.DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KDC.DL.DapperObjects
{
    public class VisaStampingCountryRepo
    {
        public List<MS_VisaStampingCountry> GetVisaStampingCountries()
        {
            string query = "Select * from MS_VisaStampingCountry";

            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<MS_VisaStampingCountry>(query).ToList();
                db.Dispose();
                return result;
            }
        }

        public MS_VisaStampingCountry GetVisaStampingCountryById(int id)
        {
            string query = "Select * from MS_VisaStampingCountry where CountryId = " + id + " ";

            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<MS_VisaStampingCountry>(query).SingleOrDefault();
                db.Dispose();
                return result;
            }
        }

        public void AddVisaStampingCountry(MS_VisaStampingCountry country)
        {
            string query = "Insert into MS_VisaStampingCountry (CountryName, CountryCode) " +
                " values (@CountryName, @CountryCode)";

            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(query, country);
                db.Dispose();
            }
        }

        public void EditVisaStampingCountry(MS_VisaStampingCountry country)
        {
            string query = "Update MS_VisaStampingCountry set CountryName = @CountryName, CountryCode = @CountryCode" +
                           " where CountryId = @CountryId";

            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(query, country);
                db.Dispose();
            }
        }

        public void RemoveVaccinationType(int id)
        {
            string query = "Delete From MS_VisaStampingCountry where CountryId = " + id + "";
            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(query);
                db.Dispose();
            }
        }
    }
}