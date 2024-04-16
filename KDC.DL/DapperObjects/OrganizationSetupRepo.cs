using Dapper;
using KDC.DL.DapperObjects;
using KDC.DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KDC.DL;

namespace KDC.DL.DapperObjects
{
    public class OrganizationSetupRepo
    {
        public void AddOrganizationSetup(MS_OrganizationSetup organizationSetup)
        {
            string sql = "insert into MS_OrganizationSetup " +
                "( OrganizationName, Address, Contact, Email, Website, Fax, PAN, GccCodeNo, IsActive, IsDeleted ) " +
                "values " +
                "( @OrganizationName, @Address, @Contact, @Email, @Website, @Fax, @PAN, @GccCodeNo, @IsActive, @IsDeleted ) ";

            using (var db = DBHelper.GetDbConnection())
            {
                organizationSetup.IsDeleted = false;
                db.Execute(sql, organizationSetup);
                db.Dispose();
            }
        }

        public List<MS_OrganizationSetup> GetOrganizationSetupList()
        {
            string sql = "select * from MS_OrganizationSetup where IsDeleted != 1";

            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<MS_OrganizationSetup>(sql).ToList();
                db.Dispose();
                return result;
            }
        }

        public MS_OrganizationSetup GetOrganizationSetupById(int organizationId)
        {
            string sql = "select * from MS_OrganizationSetup " +
                "where OrganizationId = @OrganizationId " +
                "and IsDeleted != 1";

            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<MS_OrganizationSetup>(sql, new { OrganizationId = organizationId }).SingleOrDefault();
                db.Dispose();
                return result;
            }
        }

        public void EditOrganizationSetup(MS_OrganizationSetup organizationSetup)
        {
            string sql = "update MS_OrganizationSetup set " +
                "OrganizationName = @OrganizationName, " +
                "Address = @Address, " +
                "Contact = @Contact, " +
                "Email = @Email, " +
                "Website = @Website, " +
                "Fax = @Fax, " +
                "PAN = @PAN, " +
                "GccCodeNo = @GccCodeNo, " +
                "IsActive = @IsActive " +
                "where OrganizationId = @OrganizationId";

            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(sql, organizationSetup);
                db.Dispose();
            }
        }

        public void DeleteOrganizationSetup(int organizationId)
        {
            string sql = "update MS_OrganizationSetup set " +
                "IsDeleted = 1 " +
                "where OrganizationId = @OrganizationId";
            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(sql, new { OrganizationId = organizationId });
                db.Dispose();
            }
        }
    }
}