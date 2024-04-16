using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDC.DL.ViewModel
{
    public class PathologyLabVM
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

        public string Nationality { get; set; }

        public int? JobProfessionID { get; set; }

        public string PassportNo { get; set; }
        public string PhotoScanned { get; set; }
        public string PhotoCamera { get; set; }
        public string Barcode { get; set; }

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

        public string TPro_Per { get; set; }

        public string Alk_Pho_Per { get; set; }

        public string Creat_Block { get; set; }

        public string SGPT_Per { get; set; }

        public string Urea_Per { get; set; }

        public string ESR_Per { get; set; }

        public string GGT_Per { get; set; }

        public string SGOT_Per { get; set; }

        public int? BloodGroup_RH { get; set; }

        public string Other { get; set; }
    }
}
