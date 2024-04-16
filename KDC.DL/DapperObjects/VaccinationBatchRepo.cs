using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using KDC.DL.Models;

namespace KDC.DL.DapperObjects
{
    public class VaccinationBatchRepo
    {
        public List<MS_VaccinationBatch> GetVaccinationBatchList()
        {
            string query = "Select b.*, t.VaccinationTypeName from MS_VaccinationBatch b LEFT JOIN MS_VaccinationType t " +
                           "ON b.VaccinationTypeId = t.VaccinationTypeId " +
                           "where b.IsDeleted = 0";

            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<MS_VaccinationBatch>(query).ToList();
                db.Dispose();
                return result;
            }
        }

        public MS_VaccinationBatch GetVaccinationBatchById(int id)
        {
            string query = "Select * from MS_VaccinationBatch where VaccinationBatchId = " + id + " ";

            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<MS_VaccinationBatch>(query).SingleOrDefault();
                db.Dispose();
                return result;
            }
        }

        public void Add(MS_VaccinationBatch vaccinationBatch)
        {
            string query = "Insert into MS_VaccinationBatch (Details, Manufacturer, BatchNo, DateOfManufacture, DateOfExpiry, VaccinationTypeId, IsDeleted) " +
                "values (@Details, @Manufacturer, @BatchNo, @DateOfManufacture, @DateOfExpiry, @VaccinationTypeId, @IsDeleted)";

            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(query, vaccinationBatch);
                db.Dispose();
            }
        }

        public void Edit(MS_VaccinationBatch vaccinationBatch)
        {
            string query = "Update MS_VaccinationBatch set Details = @Details, Manufacturer = @Manufacturer, " +
                "BatchNo = @BatchNo, DateOfManufacture = @DateOfManufacture, DateOfExpiry = @DateOfExpiry, " + 
                "VaccinationTypeId = @VaccinationTypeId, IsDeleted = @IsDeleted" +
                           " where VaccinationTypeId = @VaccinationTypeId";

            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(query, vaccinationBatch);
                db.Dispose();
            }
        }

        public void Delete(int id)
        {
            //string query = "Delete From MS_VaccinationBatch where VaccinationBatchId = " + id;
            string query = "Update MS_VaccinationBatch set IsDeleted = 1 where VaccinationBatchId =" + id;
            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(query);
                db.Dispose();
            }
        }
    }
}