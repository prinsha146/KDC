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
    public class PatientBillingRepo
    {
        public List<PatientBillingVM> GetPatientList()
        {
            string query = "Select distinct(p.PatientId), p.PatientName, p.Gender, p.PhoneMobile, p.LabCode," +
                " p.Age, p.EnteredDate, p.Address, lb.IsResultAdded from BL_Patient p" +
                " left join BL_PatientLabTestDetail lb on lb.PatientId = p.PatientId" +
                " where p.IsDeleted = 0";
            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<PatientBillingVM>(query).ToList();
                return result;
            }
        }

        public BL_Patient GetPatientBillById(int id)
        {
            string query = "Select * from BL_Patient where PatientId = " + id + " and IsDeleted = 0";

            using (var db = DBHelper.GetDbConnection())
            {
                return db.Query<BL_Patient>(query).SingleOrDefault();
            }
        }

        public PatientBillVM GetPatientBill(int id)
        {
            string query = "Select p.PatientId, p.PatientName, p.Gender, p.PhoneMobile, p.LabCode," +
                " p.Age, p.EnteredDate, p.Address, p.InvoiceNo, p.ManualNo," +
                " p.InvoiceDateAD, p.InvoiceDateBS, r.RefererName Referrer," +
                " p.TotalAmount, p.Discount, p.Net, p.Change, p.Tender, u.FullName EnteredBy" +
                " from BL_Patient p " +
                " left join MS_Referer r on r.RefererId = p.ReferrerId" +
                " left join SC_User u on u.UserId = p.EnteredBy" +
                " where p.PatientId =  " + id + " and p.IsDeleted = 0";

            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<PatientBillVM>(query).SingleOrDefault();
                return result;
            }
        }

        public List<PatientBillVM> GetPatientBillDetailById(int id)
        {
            string query = "Select b.PatientId, s.ServiceName Service, b.Unit, b.Amount, b.UnitPrice, b.Remarks" +
                " from BL_PatientLabTestBill b" +
                " left join SV_Service s on s.ServiceId = b.ServiceId" +
                " where b.PatientId = " + id + " and b.IsDeleted = 0";

            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<PatientBillVM>(query).ToList();
                return result;
            }
        }

		public List<PatientBillVM> SearchPatient(int LabCode = 0, int Invoice = 0)
		{
			string query = "Select b.PatientId, s.ServiceName Service, b.Unit, b.Amount, b.UnitPrice, b.Remarks" +
			   " from BL_PatientLabTestBill b" +
			   " left join SV_Service s on s.ServiceId = b.ServiceId" +
			   " left join BL_Patient p on p.PatientId = b.PatientId" +
			   " where b.IsDeleted = 0";
			
			   if (LabCode != 0)
			   {
				query += " and p.LabCode = " + LabCode;
			   }
			   if (Invoice != 0)
			   {
				query += " and p.InvoiceNo = " + Invoice;
			   }

			using (var db = DBHelper.GetDbConnection())
			{
				var result = db.Query<PatientBillVM>(query).ToList();
				return result;
			}
		}

		public string GetGroupByService(string ServiceId)
        {
            string query = "Select GroupId from SV_Service where ServiceId = '" + ServiceId + "'";
            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<string>(query).SingleOrDefault();
                return result;
            }
        }

        public int GetPatientId(int LabCode)
        {
            string query = "Select PatientId from BL_Patient where LabCode = " + LabCode;
            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<int>(query).SingleOrDefault();
                return result;
            }
        }

		

        public string GetGenderByPatientId(int id)
        {
            string sql = "Select Gender from BL_Patient where PatientId = " + id;
            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<string>(sql).SingleOrDefault();
                return result;
            }
        }

        public List<string> GetServiceLabDetailByService(string ServiceId, string gender)
        {
            //string sl = "Select DetailId" +
            //    " case" +
            //    " when gender = 'M' (select * from SV_ServiceLabDetail where sex = 'Male' or sex = 'None')" +
            //    " when gender = 'F' (select * from SV_ServiceLabDetail where sex = 'Female' or sex = 'None')" +
            //    " else (select * from SV_ServiceLabDetail)" +
            //    "from SV_ServiceLabDetail where ServiceId = '" + ServiceId + "'";

            string query = "Select DetailId from SV_ServiceLabDetail where ServiceId = '" + ServiceId + "' and" +
                " (sex = '" + gender + "' or sex = '(None)')";
            
            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<string>(query).ToList();
                return result;
            }
        }


        public void AddPatientLabTestBill(BL_PatientLabTestBill labTest)
        {
            string query = "Insert into BL_PatientLabTestBill (GroupId, ServiceId, Unit, UnitPrice, Amount, Remarks," +
                " PatientId, EnteredBy, EnteredDate, IsDeleted) " +
                " values" +
				" (@GroupId, @ServiceId, @Unit, @UnitPrice, @Amount, @Remarks, @PatientId, @EnteredBy, @EnteredDate, @IsDeleted)";

            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(query, labTest);
                db.Close();
            }
        }

        public void EditPatientLabTestBill(BL_PatientLabTestBill labTest)
        {
            string query = "Update BL_PatientLabTestBill set " +
                " GroupId = @GroupId, ServiceId = @ServiceId, Unit = @Unit, UnitPrice = @UnitPrice, Amount = @Amount" +
                " PatientId = @PatientId, EnteredBy = @EnteredBy, EnteredDate = @EnteredDate " +
                " where PatientLabTestId = @PatientLabTestId";

            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(query, labTest);
                db.Close();
            }

        }

        public void AddPatientBill(BL_Patient patient)
        {
            string query = "Insert into BL_Patient (PatientName, Gender, Age, Address, PhoneMobile, ManualNo, InvoiceNo, " +
                "InvoiceDateAD, InvoiceDateBS, ReferrerId, EnteredBy, EnteredDate, LabCode, TotalAmount, Discount, Net, Tender, Change, IsDeleted)" +
                " values (UPPER(@PatientName), @Gender, @Age, UPPER(@Address), @PhoneMobile, @ManualNo, @InvoiceNo, @InvoiceDateAD, " +
                "@InvoiceDateBS, @ReferrerId, @EnteredBy, @EnteredDate, @LabCode, @TotalAmount, @Discount, @Net, @Tender, @Change, @IsDeleted)";

            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(query, patient);
                db.Close();
            }
        }

        public void EditPatientBill(BL_Patient patient)
        {
    //        string query = "Update BL_Patient set PatientName = UPPER(@PatientName), Gender = @Gender, Age = @Age, Address = UPPER(@Address)," +
    //            " PhoneMobile = @PhoneMobile, ManualNo = @ManualNo, InvoiceNo = @InvoiceNo, InvoiceDateAD = @InvoiceDateAD, " +
				//" InvoiceDateBS = @InvoiceDateBS, ReferrerId = @ReferrerId, EnteredBy = @EnteredBy, EnteredDate = @EnteredDate, " +
    //            " IsDeleted = @IsDeleted where PatientId = @PatientId";

			string sql = "Update BL_Patient set PatientName = UPPER('" + patient.PatientName + "'), Gender = '" + patient.Gender + "', " +
				" Age = " + patient.Age + ", Address = UPPER('" + patient.Address + "'), PhoneMobile = '" + patient.PhoneMobile + "', " +
				" ManualNo = '" + patient.ManualNo + "', InvoiceNo = '" + patient.InvoiceNo + "', InvoiceDateAD = '" + patient.InvoiceDateAD + "', " +
				" InvoiceDateBS = '" + patient.InvoiceDateBS + "', ReferrerId = " + patient.ReferrerId + ", EnteredBy = " + patient.EnteredBy + ", " +
				" EnteredDate = '" + patient.EnteredDate + "', IsDeleted = '" + patient.IsDeleted + "' where PatientId = " + patient.PatientId;


			using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(sql, patient);
                db.Close();
            }
        }

       

        public void RemovePatientBl(int id)
        {
            string query = "Update BL_Patient set IsDeleted = 1 where PatientId =" + id; 

            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(query);
                db.Close();
            }
        }

        public float GetRateAmount(double id)
        {
            string query = "Select Rate from SV_Service where serviceId = " + id;
            using (var db = DBHelper.GetDbConnection())
            {
                return db.Query<float>(query).SingleOrDefault();
            }
        }

        public int GetLastLabCode()
        {
            string query = "Select max(LabCode) from BL_Patient";

            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<int>(query).SingleOrDefault();
                return result;
            }
        }

        public int GetLabCodeById(int id)
        {
            string query = "Select LabCode from BL_Patient where PatientId = " + id;

            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<int>(query).SingleOrDefault();
                return result;
            }
        }

        public void AddPatientLabTestDetail(BL_PatientLabTestDetail testDetail)
        {
            string query = "Insert into BL_PatientLabTestDetail" +
                " (PatientId, GroupId, ServiceId, ServiceLabDetailId, Result, IsNormal, EnteredBy, EnteredDate, IsDeleted, IsResultAdded)" +
                " values" +
                " (@PatientId, @GroupId, @ServiceId, @ServiceLabDetailId, '00', @IsNormal, @EnteredBy, @EnteredDate, @IsDeleted, @IsResultAdded)";

            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(query, testDetail);
                db.Close();
            }
        }

		public int GetInvoiceNo()
		{
			using (var db = DBHelper.GetDbConnection())
			{
				string query = "Select max(InvoiceNo) from BL_Patient where EnteredDate = '" + DateTime.Today.ToString("yyyy-MM-dd") + "'";
				var result = db.Query<string>(query).SingleOrDefault();
				if (result != null)
				{
					int num = Convert.ToInt32(result);
					return num;
				}
				else
				{
					return 0;
				}
				
			}
		}

		public List<PatientBillVM> GetAllPatientBillToday()
		{
			string query = "Select PatientName, InvoiceNo, ManualNo, TotalAmount, Discount, Net" +
				" from BL_Patient where IsDeleted = 0 and InvoiceDateAD = '2019-05-13'"; // + DateTime.Today.ToString("yyyy/MM/dd") + "'";

			using (var db = DBHelper.GetDbConnection())
			{
				var result = db.Query<PatientBillVM>(query).ToList();
				return result;
			}
		}

		public List<PatientBillVM> GetAllPatientBill(string from = "", string to = "")
		{
			string query = "Select PatientName, InvoiceNo, ManualNo, TotalAmount, Discount, Net, InvoiceDateAD" +
				" from BL_Patient where IsDeleted = 0";

			if (string.IsNullOrEmpty(from))
			{
				query += " and InvoiceDateAD >= '"+ DateTime.Today.ToString("yyyy/MM/dd") + "'"; 
			}
			else
			{
				query += " and InvoiceDateAD >= '" + from + "'";
			}

			if (string.IsNullOrEmpty(to))
			{
				query += " and InvoiceDateAD <= '" + DateTime.Today.ToString("yyyy/MM/dd") + "'";
			}
			else
			{
				query += " and InvoiceDateAD <= '" + to + "'";
			}

			using (var db = DBHelper.GetDbConnection())
			{
				var result = db.Query<PatientBillVM>(query).ToList();
				return result;
			}
		}

		public List<PatientBillVM> GetGroupWiseBill(string from = "", string to = "")
		{
			string query = "Select InvoiceDateAD, sum(TotalAmount) as TotalAmount, sum(Discount) as Discount, sum(Net) as Net" +
				" from BL_Patient where IsDeleted = 0";

			if (string.IsNullOrEmpty(from))
			{
				query += " and InvoiceDateAD >= '" + DateTime.Today.ToString("yyyy/MM/dd") + "'";
			}
			else
			{
				query += " and InvoiceDateAD >= '" + from + "'";
			}

			if (string.IsNullOrEmpty(to))
			{
				query += " and InvoiceDateAD <= '" + DateTime.Today.ToString("yyyy/MM/dd") + "'";
			}
			else
			{
				query += " and InvoiceDateAD <= '" + to + "'";
			}

			query += " group by InvoiceDateAD";

			using (var db = DBHelper.GetDbConnection())
			{
				var result = db.Query<PatientBillVM>(query).ToList();
				return result;
			}
		}

	}
}
