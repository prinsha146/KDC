using Dapper;
using KDC.DL;
using KDC.DL.Models;
using KDC.DL.DapperObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace KDC.DL.DapperObjects
{
    public class UserRepo
    {
        public List<SC_User> GetUserList()
        {
            string query = "Select * from SC_User where IsDeleted = 0";

            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<SC_User>(query).ToList();
                db.Dispose();
                return result;
            }
        }

        public SC_User GetUserById(int id)
        {
            string query = "Select * from SC_User where UserId = " + id + " and IsDeleted = 0";

            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<SC_User>(query).SingleOrDefault();
                db.Dispose();
                return result;
            }
        }

        public void AddUser(SC_User user)
        {
            string query = "Insert into SC_User (FullName, Email, UserName, Password, UserType, EnteredDate, RegKey, IsActive) " +
                "values (@FullName, @Email, @UserName, @Password, @UserType, @EnteredDate, @RegKey, @IsActive )";

            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(query, user);
                db.Dispose();
            }
        }

        public void EditUser(SC_User user)
        {
            string query = "Update SC_user set FullName = @FullName, Email = @Email, UserName = @UserName, Password = @Password, UserType = @UserType, EnteredDate = @EnteredDate, RegKey = @RegKey, IsActive = @IsActive " +
                           " where UserId = @UserId";

            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(query, user);
                db.Dispose();
            }
        }

        public void RemoveUser(int id)
        {
            string query = "Update SC_User set IsDeleted = 1 where UserId = " + id + "";
            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(query);
                db.Dispose();
            }
        }

        public SC_User CheckUserExists(string email, string password)
        {
            string query = "Select * from SC_User where Email = '" + email + "' and Password='" + password + "' and IsActive=1 and IsDeleted=0" ;

            using (SqlConnection conn = DBHelper.GetDbConnection())
            {
                var result = conn.Query<SC_User>(query).SingleOrDefault();
                conn.Dispose();
                return result;
            }
        }
            
    }
}