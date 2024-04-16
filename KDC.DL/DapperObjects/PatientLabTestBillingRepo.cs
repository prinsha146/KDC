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
    public class PatientLabTestBillingRepo
    {
        public List<PatientBillingVM> GetLabTestList(int id)
        {
            string query = "Select p.*, b.PatientName, b.LabCode, s.ServiceName Service from BL_PatientLabTestBill p " +
                " left join BL_Patient b on b.PatientId = p.PatientId" +
                " left join SV_Service s on s.ServiceId = p.ServiceId" +
                " where b.IsDeleted = 0 and p.PatientId = " + id + 
                " order by p.EnteredDate desc";

            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<PatientBillingVM>(query).ToList();
                return result;
            }
        }

        public BL_PatientLabTestBill GetLabTestById(int id)
        {
            string query = "Select * from BL_PatientLabTestBill where IsDeleted = 0 and PatientLabTestId = " + id;

            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<BL_PatientLabTestBill>(query).SingleOrDefault();
                return result;
            }
        }

        public List<PatientLabTestDetailVM> GetLabTestDetailById(int serviceId, int PatientId)
        {
            string query = "Select b.*, g.GroupName, s.ServiceName, sv.Particular" +
                " from BL_PatientLabTestDetail b" +
                " left join SV_Service s on s.ServiceId = b.ServiceId" +
                " left join SV_ServiceGroup g on g.GroupId = b.GroupId" +
                " left join SV_ServiceLabDetail sv on sv.ServiceId = b.ServiceId" +
                " where b.PatientId = " + PatientId + " and b.ServiceId = " + serviceId; 

            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<PatientLabTestDetailVM>(query).ToList();
                return result;
            }
        }

        public void EditPatientLabTest(BL_PatientLabTestBill patient)
        {
            string query = "Update BL_PatientLabTestBill set " +
                "ServiceId = @ServiceId, GroupId = @GroupId, Unit = @Unit, UnitPrice = @UnitPrice, " +
                "Amount = @Amount, IsDeleted = @IsDeleted, EnteredBy = @EnteredBy, EnteredDate = @EnteredDate " +
                "where PatientLabTestId = @PatientLabTestId";

            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(query, patient);
                db.Close();
            }
        }

        //if Patient is deleted (set IsDeleted = 1 to all labTest of that patient)
        public void RemovePatientLabTest(int id) // id = PatientId
        {
            string query = "Update BL_PatientLabTestBill set IsDeleted = 1 where PatientId = " + id;

            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(query);
                db.Close();
            }
        }

        //if only labTest of the patient is deleted
        public void RemoveLabTest(int id) // id = PatientLabTestId
        {
            string query = "Update BL_PatientLabTestBill set IsDeleted = 1 where PatientLabTestId = " + id;

            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(query);
                db.Close();
            }
        }
    }
}
