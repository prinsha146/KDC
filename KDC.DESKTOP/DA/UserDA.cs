using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using KDC.DESKTOP.DO;

namespace KDC.DESKTOP.DA
{
    public class UserDA
    {
        public static SC_User CheckUserExists(string email, string password)
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            string sql = "Select * from SC_User where Email = '" + email + "' and Password='" + password + "' and IsActive=1 and IsDeleted=0";

            SC_User user = null;
            DbDataReader dr = oDatabaseHelper.ExecuteReader(sql, CommandType.Text);
            while (dr.Read())
            {
                user = new SC_User();
                user.Email = email;
                user.Password = password;
                user.UserName = dr["UserName"].ToString();
                user.UserType = dr["UserType"].ToString();
                user.UserId = Convert.ToInt32(dr["UserId"]);
            }
            return user;
        }
    }
}
