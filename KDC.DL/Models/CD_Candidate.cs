namespace KDC.DL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("ams_kdcdb1.CD_Candidate")]
    public partial class CD_Candidate
    {
        [Key]
        public int CandidateID { get; set; }

        public int? MedicalCenterID { get; set; }

        public int? LabCode { get; set; }

        [StringLength(50)]
        public string GccCode { get; set; }

        [StringLength(50)]
        public string GccHMC { get; set; }

        [StringLength(50)]
        public string VisaNo { get; set; }

        public string VisaDate { get; set; }

        [StringLength(50)]
        public string RQNoManpower { get; set; }

        [StringLength(50)]
        public string GamcaNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfIssueByKDC_AD { get; set; }

        [StringLength(10)]
        public string DateOfIssueByKDC_BS { get; set; }

        [StringLength(150)]
        public string CandidateName { get; set; }
        
        public int? Address { get; set; }

        [StringLength(100)]
        public string ContactNo { get; set; }

        [StringLength(1)]
        public string Gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DOB_AD { get; set; }

        [StringLength(10)]
        public string DOB_BS { get; set; }

        public decimal? Height_in_cm { get; set; }

        public decimal? Weight_in_kg { get; set; }

        [StringLength(50)]
        public string Nationality { get; set; }

        public int? JobProfessionID { get; set; }

        [StringLength(50)]
        public string PassportNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PassportDateAD { get; set; }

        [StringLength(10)]
        public string PassportDateBS { get; set; }

        public int? PassportPlaceOfIssue { get; set; }

        public int? RecruitingAgencyID { get; set; }

        public int? VisaStampingCountryID { get; set; }

        [StringLength(50)]
        public string InvoiceNo { get; set; }

        public bool? Allergy { get; set; }

        [StringLength(50)]
        public string Others { get; set; }

        [Column(TypeName = "ntext")]
        public string FingerPrint { get; set; }

        [StringLength(50)]
        public string FingerPrintRemarks { get; set; }

        [StringLength(50)]
        public string PhotoScanned { get; set; }

        [StringLength(50)]
        public string PhotoCamera { get; set; }

        [StringLength(50)]
        public string Barcode { get; set; }

        public int? CandidateDetailsEnteredBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CandidateDetailsEnteredDate { get; set; }

        public int? LabNoIdThisYear { get; set; }

        [StringLength(20)]
        public string RightEye { get; set; }

        [StringLength(20)]
        public string LeftEye { get; set; }

        [StringLength(20)]
        public string RightEar { get; set; }

        [StringLength(20)]
        public string LeftEar { get; set; }

        [StringLength(20)]
        public string BloodPressure { get; set; }

        [StringLength(20)]
        public string Heart { get; set; }

        [StringLength(20)]
        public string Lungs { get; set; }

        [StringLength(20)]
        public string Chest { get; set; }

        [StringLength(20)]
        public string Abdomen { get; set; }

        [StringLength(20)]
        public string Hernia { get; set; }

        [StringLength(20)]
        public string Veins { get; set; }

        [StringLength(20)]
        public string Extermities { get; set; }

        [StringLength(20)]
        public string Deformities { get; set; }

        [StringLength(20)]
        public string Skin { get; set; }

        [StringLength(20)]
        public string Clinical { get; set; }

        [StringLength(20)]
        public string Cns { get; set; }

        [StringLength(20)]
        public string Pshychiatry { get; set; }

        [StringLength(20)]
        public string UHb { get; set; }

        [StringLength(20)]
        public string UTC_in_cumm { get; set; }

        [StringLength(20)]
        public string UHIV_1_2 { get; set; }

        [StringLength(20)]
        public string UHBsAg { get; set; }

        [StringLength(20)]
        public string UAnti_HCV { get; set; }

        [StringLength(20)]
        public string UTPHA { get; set; }

        [StringLength(20)]
        public string UVDRL { get; set; }

        [StringLength(20)]
        public string UMP { get; set; }

        [StringLength(20)]
        public string UMF { get; set; }

        [StringLength(20)]
        public string Urine_Re_Me { get; set; }

        [StringLength(20)]
        public string BSugar { get; set; }

        [StringLength(20)]
        public string BAlbumin { get; set; }

        [StringLength(20)]
        public string Stool_RE { get; set; }

        [StringLength(20)]
        public string BDC_N { get; set; }

        [StringLength(20)]
        public string BDC_L { get; set; }

        [StringLength(20)]
        public string BDC_E { get; set; }

        [StringLength(20)]
        public string BDC_M { get; set; }

        [StringLength(20)]
        public string BDC_B { get; set; }

        [StringLength(20)]
        public string Platelets { get; set; }

        [StringLength(20)]
        public string Sugar_Block { get; set; }

        [StringLength(20)]
        public string Bill_T_Per { get; set; }

        [StringLength(20)]
        public string Albumin_Per { get; set; }

        [StringLength(20)]
        public string Bil_D_Per { get; set; }

        [StringLength(20)]
        public string TPro_Per { get; set; }

        [StringLength(20)]
        public string Alk_Pho_Per { get; set; }

        [StringLength(20)]
        public string Creat_Block { get; set; }

        [StringLength(20)]
        public string SGPT_Per { get; set; }

        [StringLength(20)]
        public string Urea_Per { get; set; }

        [StringLength(20)]
        public string ESR_Per { get; set; }

        [StringLength(20)]
        public string GGT_Per { get; set; }

        [StringLength(20)]
        public string SGOT_Per { get; set; }

        public int? BloodGroup_RH { get; set; }

        [StringLength(50)]
        public string Micros_Exam { get; set; }

        [StringLength(20)]
        public string Other { get; set; }

        public bool? Pregnancy { get; set; }

        public int? LabTestEnteredBy { get; set; }

        public DateTime? LabTestEnteredDate { get; set; }

        public DateTime? DateOfVaccination { get; set; }

        public int? VaccinationDataEnteredBy { get; set; }

        [StringLength(20)]
        public string Helminthes { get; set; }

        [StringLength(20)]
        public string Usugar { get; set; }

        [StringLength(20)]
        public string Ualbumin { get; set; }

        [StringLength(20)]
        public string Giardia { get; set; }

        [StringLength(20)]
        public string Salmonella { get; set; }

        [StringLength(20)]
        public string Haemo { get; set; }

        [StringLength(20)]
        public string Malaria { get; set; }

        [StringLength(20)]
        public string Microf { get; set; }

        [StringLength(20)]
        public string FBS { get; set; }

        [StringLength(20)]
        public string LFT { get; set; }

        [StringLength(200)]
        public string Remarks { get; set; }

        [StringLength(20)]
        public string Creatinine { get; set; }

        public int? VaccinationBatchId { get; set; }

        public bool? FitStatus { get; set; }

        [StringLength(50)]
        public string UnfitRemarks { get; set; }

        public bool? Married { get; set; }

        [StringLength(10)]
        public string Religion { get; set; }

        public int? LastUpdatedBy { get; set; }

        public DateTime? LastUpdatedDate { get; set; }

		//public int EnteredBy { get; set; }

		//public DateTime EnteredDate { get; set; }
		[StringLength(50)]
		public string Status { get; set; }

        public int RVNoToday { get; set; }
	}
}
