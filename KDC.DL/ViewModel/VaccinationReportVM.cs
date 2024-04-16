using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDC.DL.ViewModel
{
    public class VaccinationReportVM
    {
        public int LabCode { get; set; }

        public int CandidateID { get; set; }

        public string CandidateName { get; set; }

        public string Gender { get; set; }

        public string PassportNo { get; set; }

        public string Nationality { get; set; }

        public DateTime DateOfVaccination { get; set; }

        public string Manufacturer { get; set; }

        public string BatchNo { get; set; }

        public DateTime DateOfManufacture { get; set; }

        public DateTime DateOfExpiry { get; set; }

        public int VaccinationTypeId { get; set; }

        public string VaccinationTypeName { get; set; }

        public int VaccinationBatchId { get; set; }

        public int? MedicalCenterID { get; set; }

        
        public string GccCode { get; set; }

        
        public string GccHMC { get; set; }

        
        public string VisaNo { get; set; }

        
        public string VisaDate { get; set; }

        
        public string RQNoManpower { get; set; }

        
        public string GamcaNo { get; set; }

        
        public DateTime? DateOfIssueByKDC_AD { get; set; }

        
        public string DateOfIssueByKDC_BS { get; set; }

        
        public int? Address { get; set; }

        
        public string ContactNo { get; set; }

        
        public DateTime? DOB_AD { get; set; }

        
        public string DOB_BS { get; set; }

        public decimal? Height_in_cm { get; set; }

        public decimal? Weight_in_kg { get; set; }


        public int? JobProfessionID { get; set; }

        public DateTime? PassportDateAD { get; set; }

        
        public string PassportDateBS { get; set; }

        public int? PassportPlaceOfIssue { get; set; }

        public int? RecruitingAgencyID { get; set; }

        public int? VisaStampingCountryID { get; set; }

        public string CountryName { get; set; }
        
        public string InvoiceNo { get; set; }

        public bool? Allergy { get; set; }

        
        public string Others { get; set; }

        
        public string FingerPrint { get; set; }

        
        public string FingerPrintRemarks { get; set; }

        
        public string PhotoScanned { get; set; }

        
        public string PhotoCamera { get; set; }

        
        public string Barcode { get; set; }

        public int? CandidateDetailsEnteredBy { get; set; }

        
        public DateTime? CandidateDetailsEnteredDate { get; set; }

        public int? LabNoIdThisYear { get; set; }

        
        public string RightEye { get; set; }

        
        public string LeftEye { get; set; }

        
        public string RightEar { get; set; }

        
        public string LeftEar { get; set; }

        
        public string BloodPressure { get; set; }

        
        public string Heart { get; set; }

        
        public string Lungs { get; set; }

        
        public string Chest { get; set; }

        
        public string Abdomen { get; set; }

        
        public string Hernia { get; set; }

        
        public string Veins { get; set; }

        
        public string Extermities { get; set; }

        
        public string Deformities { get; set; }

        
        public string Skin { get; set; }

        
        public string Clinical { get; set; }

        
        public string Cns { get; set; }

        
        public string Pshychiatry { get; set; }

        
        public string UHb { get; set; }

        
        public string UTC_in_cumm { get; set; }

        
        public string UHIV_1_2 { get; set; }

        
        public string UHBsAg { get; set; }

        
        public string UAnti_HCV { get; set; }

        
        public string UTPHA { get; set; }

        
        public string UVDRL { get; set; }

        
        public string UMP { get; set; }

        
        public string UMF { get; set; }

        
        public string Urine_Re_Me { get; set; }

        
        public string BSugar { get; set; }

        
        public string BAlbumin { get; set; }

        
        public string Stool_RE { get; set; }

        
        public string BDC_N { get; set; }

        
        public string BDC_L { get; set; }

        
        public string BDC_E { get; set; }

        
        public string BDC_M { get; set; }

        
        public string BDC_B { get; set; }

        
        public string Platelets { get; set; }

        
        public string Sugar_Block { get; set; }

        
        public string Bill_T_Per { get; set; }

        
        public string Albumin_Per { get; set; }

        
        public string Bil_D_Per { get; set; }

        
        public string TPro_Per { get; set; }

        
        public string Alk_Pho_Per { get; set; }

        
        public string Creat_Block { get; set; }

        
        public string SGPT_Per { get; set; }

        
        public string Urea_Per { get; set; }

        
        public string ESR_Per { get; set; }

        
        public string GGT_Per { get; set; }

        
        public string SGOT_Per { get; set; }

        public int? BloodGroup_RH { get; set; }
        public string BloodGroupName { get; set; }
        
        public string Micros_Exam { get; set; }

        
        public string Other { get; set; }

        public bool? Pregnancy { get; set; }

        public int? LabTestEnteredBy { get; set; }

        public DateTime? LabTestEnteredDate { get; set; }


        public int? VaccinationDataEnteredBy { get; set; }

        
        public string Helminthes { get; set; }

        
        public string Usugar { get; set; }

        
        public string Ualbumin { get; set; }

        
        public string Giardia { get; set; }

        
        public string Salmonella { get; set; }

        
        public string Haemo { get; set; }

        
        public string Malaria { get; set; }

        
        public string Microf { get; set; }

        
        public string FBS { get; set; }

        
        public string LFT { get; set; }

        
        public string Remarks { get; set; }

        
        public string Creatinine { get; set; }

        public int Doctor { get; set; }

        public int Age { get; set; }

		public int RVNoToday { get; set; }
    }
}
