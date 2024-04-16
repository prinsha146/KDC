using KDC.DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KDC.DL.DapperObjects;
using Dapper;
using KDC.DL;

namespace KDC.DL.DapperObjects
{
    public class JobProfessionRepo
    { 
        public List<MS_JobProfession> GetJobProfessionList()
        {
            string query = "Select * from MS_JobProfession";

            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<MS_JobProfession>(query).ToList();
                db.Dispose();
                return result;
            }
        }

        public MS_JobProfession GetJobProfessionById(int id)
        {
            string query = "Select * from MS_JobProfession where JobProfessionId = " + id + "";

            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<MS_JobProfession>(query).SingleOrDefault();
                db.Dispose();
                return result;
            }
        }

        public void AddJobProfession(MS_JobProfession jobProfession)
        {
            string query = "Insert into MS_JobProfession (JobProfessionName, Active) values (@JobProfessionName, @Active)";

            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(query, jobProfession);
                db.Dispose();
            }
        }

        public void EditJobProfession(MS_JobProfession jobProfession)
        {
            string query = "Update MS_JobProfession set JobProfessionName = @JobProfessionName, Active = @Active " +
                           " where JobProfessionId = @JobProfessionId";

            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(query, jobProfession);
                db.Dispose();
            }
        }

        public void RemoveJobProfession(int id)
        {
            string query = "Delete From MS_JobProfession where JobProfessionId = " + id + "";
            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(query);
                db.Dispose();
            }
        }
    }
}