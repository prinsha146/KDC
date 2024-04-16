using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KDC.DL.Models;
using Dapper;
using KDC.DL.DapperObjects;

namespace KDC.DL.DapperObjects
{
    public class BloodGroupRepo
    {
        public void AddBloodGroup(MS_BloodGroupRH bloodGroupRH)
        {
            string sql = "insert into MS_BloodGroupRH " +
                "(BloodGroupName) " +
                "values " +
                "(@BloodGroupName)";

            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(sql, bloodGroupRH);
                db.Dispose();
            }
        }

        public void EditBloodGroup(MS_BloodGroupRH bloodGroupRH)
        {
            string sql = "update MS_BloodGroupRH set " +
                "BloodGroupName = @BloodGroupName " +
                "where BloodGroupId = @BloodGroupId";

            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(sql, bloodGroupRH);
                db.Dispose();
            }
        }

        public MS_BloodGroupRH GetBloodGroupById(int bloodGroupId)
        {
            string sql = "select * " +
                "from MS_BloodGroupRH " +
                "where BloodGroupId = @BloodGroupId ";

            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<MS_BloodGroupRH>(sql, new { bloodGroupId }).SingleOrDefault();
                db.Dispose();
                return result;
            }
        }

        public List<MS_BloodGroupRH> GetBloodGroupList()
        {
            string sql = "select *" +
                "from MS_BloodGroupRH ";

            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<MS_BloodGroupRH>(sql).ToList();
                db.Dispose();
                return result;
            }
        }

        public void DeleteBloodGroup(int bloodGroupId)
        {
            string sql = "delete " +
                "from MS_BloodGroupRH " +
                "where BloodGroupId = @BloodGroupId";

            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(sql, new { bloodGroupId });
                db.Dispose();
            }
        }
    }
}