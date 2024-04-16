using Dapper;
using KDC.DL;
using KDC.DL.Models;
using KDC.DL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KDC.DL.DapperObjects
{
    public class LoginRepo
    {
        public SessionVM CheckLogin(string Email, string Password, string returnUrl)
        {
            string query = "select u.UserId, u.FullName, u.Email, u.UserType" +
                " from SC_User u" +
                " where u.Email = '" + Email + "' and u.Password = '" + Password + "' and u.IsDeleted = 0";
            using (var db = DBHelper.GetDbConnection())
            {
                return db.Query<SessionVM>(query).SingleOrDefault();
            }
        }
    }
}
