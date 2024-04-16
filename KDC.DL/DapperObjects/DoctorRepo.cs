using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KDC.DL.Models;
using Dapper;
using KDC.DL.DapperObjects;

namespace KDC.DL.DapperObjects
{
	public class DoctorRepo
	{
		public List<MS_Doctor> GetDoctorList()
		{
			string query = "Select * from MS_Doctor where IsDeleted = 0";
			using (var db = DBHelper.GetDbConnection())
			{
				var result = db.Query<MS_Doctor>(query).ToList();
				return result;
			}
		}

		public MS_Doctor GetDoctorById(int id)
		{
			string query = "Select * from MS_Doctor where IsDeleted = 0 and DoctorId = " + id;
			using (var db = DBHelper.GetDbConnection())
			{
				var result = db.Query<MS_Doctor>(query).SingleOrDefault();
				return result;
			}
		}

		public void AddDoctor(MS_Doctor doctor)
		{
			string query = "Insert into MS_Doctor (DoctorName, Degree, Specialization, IsActive, IsDeleted) " +
				" values (@DoctorName, @Degree, @Specialization, @IsActive, @IsDeleted)";
			using (var db = DBHelper.GetDbConnection())
			{
				db.Execute(query, doctor);
				db.Close();
			}
		}

		public void EditDoctor(MS_Doctor doctor)
		{
			string query = "Update MS_Doctor set DoctorName = @DoctorName, Degree = @Degree, " +
				" Specialization = @Specialization, IsActive = @IsActive, IsDeleted = @IsDeleted where DoctorId = @DoctorId";
			using (var db = DBHelper.GetDbConnection())
			{
				db.Execute(query, doctor);
				db.Close();
			}
		}

		public void RemoveDoctor(int id)
		{
			string query = "Update MS_Doctor set IsDeleted = 1 where DoctorId = " + id;
			using (var db = DBHelper.GetDbConnection())
			{
				db.Execute(query);
				db.Close();
			}
		}
	}
}
