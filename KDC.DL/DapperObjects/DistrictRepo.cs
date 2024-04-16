using Dapper;
using KDC.DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KDC.DL.DapperObjects;
using KDC.DL;

namespace KDC.DL.DapperObjects
{
    public class DistrictRepo
    {
        public List<MS_District> GetDistrictList() {
            string query = "Select * from MS_District order by DistrictName";

            using (var db = DBHelper.GetDbConnection()) {
                var result = db.Query<MS_District>(query).ToList();
                db.Dispose();
                return result;
            } 
        }

        public MS_District GetDistrictById(int id) {
            string query = "Select * from MS_District where DistrictId = " + id + "";

            using (var db = DBHelper.GetDbConnection()) {
                var result = db.Query<MS_District>(query).SingleOrDefault();
                db.Dispose();
                return result;
            }
        }

        public void AddDistrict(MS_District district) {
            string query = "Insert into MS_District (DistrictName) values (@DistrictName)";

            using (var db = DBHelper.GetDbConnection()) {
                db.Execute(query, district);
                db.Dispose();
            }
        }

        public void EditDistrict(MS_District district)
        {
            string query = "Update MS_District set DistrictName = @DistrictName " +
                           " where DistrictId = @DistrictId";

            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(query, district);
                db.Dispose();
            }
        }

        public void RemoveDistrict(int id)
        {
            string query = "Delete From MS_District where DistrictId = " + id + "";
            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(query);
                db.Dispose();
            }
        }
    }
}