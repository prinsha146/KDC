using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KDC.DL.Models;
using KDC.DL.ViewModel;
using Dapper;

namespace KDC.DL.DapperObjects
{
	public class OPDPatientRepo
	{
		public List<OPDPatientVM> GetOPDPatientList()
		{
			string query = "Select Top 50 * from OPD_Patient order by EnteredDate desc";
			using (var db = DBHelper.GetDbConnection())
			{
				var result = db.Query<OPDPatientVM>(query).ToList();
				return result;
			}
		}

		public OPDPatientVM GetOPDPatientById(int id)
		{
			string query = "Select * from OPD_Patient " +
				" where IsDeleted = 0 and PatientId = " + id;
			using (var db = DBHelper.GetDbConnection())
			{
				var result = db.Query<OPDPatientVM>(query).SingleOrDefault();
				return result;
			}
		}

		public List<OPDPatientVM> SearchOPDPatient(int PatientCode = 0, string PatientName = "")
		{
			using (var db = DBHelper.GetDbConnection())
			{
				string query = "Select * from OPD_Patient" +
					" where IsDeleted = 0";
			
			if (PatientCode != 0)
			{
				query += " and PatientCode = " + PatientCode;
			}
			else
			{
				query += "";
			}

			if (string.IsNullOrEmpty(PatientName))
			{
				query += "";
			}

			else
			{
				query += " and PatientName = '" + PatientName + "'";
			}

				var result = db.Query<OPDPatientVM>(query).ToList();
				return result;
				
			}


		}
		public OPD_Patient GetOPDPatient(int id)
		{
			string query = "Select * from OPD_Patient" +
				" where IsDeleted = 0 and PatientId = " + id;
			using (var db = DBHelper.GetDbConnection())
			{
				var result = db.Query<OPD_Patient>(query).SingleOrDefault();
				return result;
			}
		}

		public void AddOPDPatient(OPD_Patient patient)
		{
			string query = "Insert into OPD_Patient" +
				" (PatientName, PatientCode, Age, Gender, Address, Phone, EnteredDate, EnteredBy, IsDeleted)" +
				" values" +
				" (UPPER(@PatientName), @PatientCode, @Age, @Gender, UPPER(@Address), @Phone, @EnteredDate, @EnteredBy, @IsDeleted)";

			using (var db = DBHelper.GetDbConnection())
			{
				db.Execute(query, patient);
				db.Close();
			}
		}

		public void EditOPDPatient(OPD_Patient patient)
		{
			string query = "Update OPD_Patient set" +
				" PatientName = UPPER(@PatientName), PatientCode = @PatientCode, Age = @Age, Gender = @Gender, Address = UPPER(@Address), " +
				" Phone = @Phone, EnteredDate = @EnteredDate, EnteredBy = @EnteredBy, IsDeleted = @IsDeleted" +
				" where PatientId = @PatientId";

			using (var db = DBHelper.GetDbConnection())
			{
				db.Execute(query, patient);
				db.Close();
			}
		}

		public void RemoveOPDPatient(int id)
		{
			string query = "Update OPD_Patient set" +
				" IsDeleted = 1 where PatientId = " + id;

			using (var db = DBHelper.GetDbConnection())
			{
				db.Execute(query);
				db.Close();
			}
		}

        public List<string> GetOPDPatient()
        {
            string query = "Select PatientName from OPD_Patient where IsDeleted = 0 order by PatientName";
            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<string>(query).ToList();
                return result;
            }
        }
	}
}
