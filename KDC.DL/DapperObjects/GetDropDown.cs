using System.Collections.Generic;
using System.Linq;
using KDC.DL.ViewModel;
using Dapper;
using System;

namespace KDC.DL.DapperObjects
{
    public class GetDropDown
    {
        public List<Basic> GetVaccinationTypeDDL()
        {

            string query = "select VaccinationTypeId Id, VaccinationTypeName Name from MS_VaccinationType Order by VaccinationTypeName";
            using (var db = DBHelper.GetDbConnection())
            {
                var list = db.Query<Basic>(query).ToList();
                return list;
            }
        }

        public List<Basic> GetStampingCountryListDDl()
        {
            string query = "Select CountryId Id, CountryName Name from MS_VisaStampingCountry order by CountryName";
            using (var db = DBHelper.GetDbConnection())
            {
                var list = db.Query<Basic>(query).ToList();
                return list;
            }
        }

        public List<Basic> GetServiceDDL()
        {
            string query = "Select ServiceId ID, ServiceName Name from SV_Service Order by ServiceName";
            using (var db = DBHelper.GetDbConnection())
            {
                var list = db.Query<Basic>(query).ToList();
                return list;
            }
        }

        public List<Basic> GetDistrictDDL()
        {
            string query = "Select DistrictId Id, DistrictName Name from MS_District order by DistrictName";
            using (var db = DBHelper.GetDbConnection())
            {
                var list = db.Query<Basic>(query).ToList();
                return list;
            }
        }

        public List<Basic> GetYearList()
        {
            int strtyear = 2018;
            List<Basic> yearlst = new List<Basic>();
            for (int i = 2018; i <= DateTime.Today.Year; i++)
            {
                //strtyear++;
                yearlst.Add(new Basic { Id = i, Name = i.ToString() });
            }
            return yearlst;
        }

        public List<Basic> GetDoctorList()
        {
            string query = "Select DoctorId Id, DoctorName Name from MS_Doctor order by DoctorName";
            using (var db = DBHelper.GetDbConnection())
            {
                var list = db.Query<Basic>(query).ToList();
                return list;
            }

        }
		public List<Basic> GetStampingCountryList()
		{
			string query = "Select CountryId Id, CountryName Name from MS_VisaStampingCountry order by CountryName";
			using (var db = DBHelper.GetDbConnection())
			{
				var list = db.Query<Basic>(query).ToList();
				return list;
			}
		}

		public List<Basic> GetOPDPatientDDL()
		{
			string query = "Select PatientId Id, PatientName Name from OPD_Patient where IsDeleted = 0 order by PatientName";
			using (var db = DBHelper.GetDbConnection())
			{
				var list = db.Query<Basic>(query).ToList();
				return list;
			}
		}
	}
}