using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KDC.DL.Models;

namespace KDC.DL.ViewModel
{
    public class CandidateVM
    {
        public int CandidateID { get; set; }
        public string CandidateName { get; set; }
        public int Address { get; set; }
        public string DistrictName { get; set; }
        public string ContactNo { get; set; }
        public string Gender { get; set; }
        public DateTime DOB_AD { get; set; }
        public string VisaNo { get; set; }
        public int JobProfessionID { get; set; }
        public string Job { get; set; }
        public string PassportNo { get; set; }
        public string RQNoManpower { get; set; }
        public DateTime DateOfIssueByKDC_AD { get; set; }
        public int VisaStampingCountryID { get; set; }
        public string Country { get; set; }
        public string Barcode { get; set; }
        public int? LabTestEnteredBy { get; set; }
        public DateTime LabTestEnteredDate { get; set; }
        public string BloodGroupName { get; set; }
        public int LabCode { get; set; }
        public string Remarks { get; set; }
        public int Age { get; set; }
        public decimal Weight_in_kg { get; set; }
        public decimal Height_in_cm { get; set; }
        public string PassportPlaceOfIssue { get; set; }
        public string GccCode { get; set; }
        public string GccHMC { get; set; }
        public string PhotoScanned { get; set; }
        public string Nationality { get; set; }
        public bool FitStatus { get; set; }
        public string UnfitRemarks { get; set; }
        public string Status { get; set; }
        public DateTime CandidateDetailsEnteredDate { get; set; }
        public int RVNoToday { get; set; }
        
    }
}
