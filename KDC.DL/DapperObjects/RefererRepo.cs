using Dapper;
using KDC.DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KDC.DL;

namespace KDC.DL.DapperObjects
{
    public class RefererRepo
    {
        public List<MS_Referer> GetRefererList()
        {
            string query = "Select * from MS_Referer where IsDeleted = 0";

            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<MS_Referer>(query).ToList();
                db.Dispose();
                return result;
            }
        }

        public MS_Referer GetRefererById(int id)
        {
            string query = "Select * from MS_Referer where RefererId = " + id + " and IsDeleted = 0";

            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<MS_Referer>(query).SingleOrDefault();
                db.Dispose();
                return result;
            }
        }

        public void AddReferer(MS_Referer referer)
        {
            string query = "Insert into MS_Referer (RefererName) " +
                "values (@RefererName)";

            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(query, referer);
                db.Dispose();
            }
        }

        public void EditReferer(MS_Referer referer)
        {
            string query = "Update MS_Referer set RefererName = @RefererName" +
                           " where RefererId = @RefererId";

            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(query, referer);
                db.Dispose();
            }
        }

        public void RemoveReferer(int id)
        {
            string query = "Update MS_Referer set IsDeleted = 1 where RefererId = " + id + "";
            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(query);
                db.Dispose();
            }
        }
    }
}