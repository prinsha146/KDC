using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDC.DL.ViewModel
{
    public class CandidateDetailVM
    {
        public int CandidateID { get; set; }

        public int? MedicalCenterID { get; set; }

        public string GccCode { get; set; }

        public string GccHMC { get; set; }
        public string VisaNo { get; set; }
        public DateTime? VisaDate { get; set; }
        public string RQNoManpower { get; set; }
        public string GamcaNo { get; set; }
        public DateTime? DateOfIssueByKDC_AD { get; set; }
        public string DateOfIssueByKDC_BS { get; set; }
        public string CandidateName { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string Gender { get; set; }
        public DateTime? DOB_AD { get; set; }
        public string DOB_BS { get; set; }
        public decimal? Height_in_cm { get; set; }

        public decimal? Weight_in_kg { get; set; }

        public byte[] Nationality { get; set; }

        public int? JobProfessionID { get; set; }

        public string PassportNo { get; set; }

        public DateTime? PassportDateAD { get; set; }

        public byte[] PassportDateBS { get; set; }

        public int? PassportPlaceOfIssue { get; set; }

        public int? RecruitingAgencyID { get; set; }

        public int? VisaStampingCountryID { get; set; }

        public string InvoiceNo { get; set; }

        public bool? Allergy { get; set; }

        public bool? Others { get; set; }

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

        public string Hb { get; set; }

        public string TC_in_cumm { get; set; }

        public string HIV_1_2 { get; set; }

        public string HBsAg { get; set; }

        public string Anti_HCV { get; set; }

        public string TPHA { get; set; }

        public string VDRL { get; set; }

        public string MP { get; set; }

        public string MF { get; set; }

        public string Urine_Re_Me { get; set; }

        public string Sugar { get; set; }
        public string Albumin { get; set; }

        public string Stool_RE { get; set; }

        public string DC_N { get; set; }

        public string DC_L { get; set; }

        public string DC_E { get; set; }

        public string DC_M { get; set; }

        public string DC_B { get; set; }

        public string Platelets { get; set; }

        public string Sugar_Block { get; set; }

        public string Bill_T_Per { get; set; }

        public string Albumin_Per { get; set; }

        public string Bil_D_Per { get; set; }
    }
}
