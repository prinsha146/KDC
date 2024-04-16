namespace KDC.DL.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ams_kdcdb : DbContext
    {
        public ams_kdcdb()
            : base("name=ams_kdcdb")
        {
        }

        public virtual DbSet<CD_Candidate> CD_Candidate { get; set; }
        public virtual DbSet<MS_BloodGroupRH> MS_BloodGroupRH { get; set; }
        public virtual DbSet<MS_District> MS_District { get; set; }
        public virtual DbSet<MS_JobProfession> MS_JobProfession { get; set; }
        public virtual DbSet<MS_LabServiceGroup> MS_LabServiceGroup { get; set; }
        public virtual DbSet<MS_LabServiceItem> MS_LabServiceItem { get; set; }
        public virtual DbSet<MS_MedicalReportType> MS_MedicalReportType { get; set; }
        public virtual DbSet<MS_OrganizationSetup> MS_OrganizationSetup { get; set; }
        public virtual DbSet<MS_RecruitingAgency> MS_RecruitingAgency { get; set; }
        public virtual DbSet<MS_Referer> MS_Referer { get; set; }
        public virtual DbSet<MS_VaccinationBatch> MS_VaccinationBatch { get; set; }
        public virtual DbSet<MS_VaccinationType> MS_VaccinationType { get; set; }
        public virtual DbSet<MS_VisaStampingCountry> MS_VisaStampingCountry { get; set; }
        public virtual DbSet<MS_Year> MS_Year { get; set; }
        public virtual DbSet<SC_User> SC_User { get; set; }
        public virtual DbSet<SV_Service> SV_Service { get; set; }
        public virtual DbSet<MS_Doctor> MS_Doctor { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.GccCode)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.GccHMC)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.VisaNo)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.RQNoManpower)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.GamcaNo)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.DateOfIssueByKDC_BS)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.CandidateName)
                .IsUnicode(false);

            //modelBuilder.Entity<CD_Candidate>()
            //    .Property(e => e.Address)
            //    .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.ContactNo)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.DOB_BS)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.Height_in_cm)
                .HasPrecision(10, 2);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.Weight_in_kg)
                .HasPrecision(10, 2);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.PassportNo)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.InvoiceNo)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.FingerPrintRemarks)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.PhotoScanned)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.PhotoCamera)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.Barcode)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.RightEye)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.LeftEye)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.RightEar)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.LeftEar)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.BloodPressure)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.Heart)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.Lungs)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.Chest)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.Abdomen)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.Hernia)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.Veins)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.Extermities)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.Deformities)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.Skin)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.Clinical)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.Cns)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.Pshychiatry)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.UHb)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.UTC_in_cumm)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.UHIV_1_2)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.UHBsAg)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.UAnti_HCV)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.UTPHA)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.UVDRL)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.UMP)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.UMF)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.Urine_Re_Me)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.BSugar)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.BAlbumin)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.Stool_RE)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.BDC_N)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.BDC_L)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.BDC_E)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.BDC_M)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.BDC_B)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.Platelets)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.Sugar_Block)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.Bill_T_Per)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.Albumin_Per)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.Bil_D_Per)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.TPro_Per)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.Alk_Pho_Per)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.Creat_Block)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.SGPT_Per)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.Urea_Per)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.ESR_Per)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.GGT_Per)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.SGOT_Per)
                .IsUnicode(false);

            modelBuilder.Entity<CD_Candidate>()
                .Property(e => e.Other)
                .IsUnicode(false);

            modelBuilder.Entity<MS_BloodGroupRH>()
                .Property(e => e.BloodGroupName)
                .IsUnicode(false);

            modelBuilder.Entity<MS_District>()
                .Property(e => e.DistrictName)
                .IsUnicode(false);

            modelBuilder.Entity<MS_JobProfession>()
                .Property(e => e.JobProfessionName)
                .IsUnicode(false);

            modelBuilder.Entity<MS_LabServiceGroup>()
                .Property(e => e.ServiceGroupName)
                .IsUnicode(false);

            modelBuilder.Entity<MS_LabServiceItem>()
                .Property(e => e.Result)
                .IsUnicode(false);

            modelBuilder.Entity<MS_LabServiceItem>()
                .Property(e => e.ItemDetail)
                .IsUnicode(false);

            modelBuilder.Entity<MS_LabServiceItem>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<MS_LabServiceItem>()
                .Property(e => e.Rate)
                .HasPrecision(10, 2);

            modelBuilder.Entity<MS_MedicalReportType>()
                .Property(e => e.ReportTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<MS_OrganizationSetup>()
                .Property(e => e.OrganizationName)
                .IsUnicode(false);

            modelBuilder.Entity<MS_OrganizationSetup>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<MS_OrganizationSetup>()
                .Property(e => e.Contact)
                .IsUnicode(false);

            modelBuilder.Entity<MS_OrganizationSetup>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<MS_OrganizationSetup>()
                .Property(e => e.Website)
                .IsUnicode(false);

            modelBuilder.Entity<MS_OrganizationSetup>()
                .Property(e => e.PAN)
                .IsUnicode(false);

            modelBuilder.Entity<MS_OrganizationSetup>()
                .Property(e => e.GccCodeNo)
                .IsUnicode(false);

            modelBuilder.Entity<MS_RecruitingAgency>()
                .Property(e => e.RecruitingAgencyName)
                .IsUnicode(false);

            modelBuilder.Entity<MS_RecruitingAgency>()
                .Property(e => e.CODE)
                .IsUnicode(false);

            modelBuilder.Entity<MS_RecruitingAgency>()
                .Property(e => e.NAFEA)
                .IsUnicode(false);

            modelBuilder.Entity<MS_RecruitingAgency>()
                .Property(e => e.DirectorName)
                .IsUnicode(false);

            modelBuilder.Entity<MS_RecruitingAgency>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<MS_RecruitingAgency>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<MS_Referer>()
                .Property(e => e.RefererName)
                .IsUnicode(false);

            modelBuilder.Entity<MS_VaccinationBatch>()
                .Property(e => e.Details)
                .IsUnicode(false);

            modelBuilder.Entity<MS_VaccinationBatch>()
                .Property(e => e.Manufacturer)
                .IsUnicode(false);

            modelBuilder.Entity<MS_VaccinationBatch>()
                .Property(e => e.BatchNo)
                .IsUnicode(false);

            modelBuilder.Entity<MS_VaccinationType>()
                .Property(e => e.VaccinationTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<MS_VisaStampingCountry>()
                .Property(e => e.CountryName)
                .IsUnicode(false);

            modelBuilder.Entity<SC_User>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<SC_User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<SC_User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<SC_User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<SC_User>()
                .Property(e => e.UserType)
                .IsUnicode(false);

            modelBuilder.Entity<SC_User>()
                .Property(e => e.RegKey)
                .IsUnicode(false);

            //modelBuilder.Entity<SV_Service>()
            //   .Property(e => e.ServiceId)
            //   .IsUnicode(false);

            modelBuilder.Entity<SV_Service>()
                .Property(e => e.ServiceName)
                .IsUnicode(false);

            modelBuilder.Entity<SV_Service>()
               .Property(e => e.Rate)
               .IsUnicode(false);

            modelBuilder.Entity<SV_Service>()
               .Property(e => e.GroupId)
               .IsUnicode(false);

            modelBuilder.Entity<SV_Service>()
               .Property(e => e.UserId)
               .IsUnicode(false);

            modelBuilder.Entity<SV_Service>()
               .Property(e => e.Discount)
               .IsUnicode(false);

            modelBuilder.Entity<SV_Service>()
               .Property(e => e.Status)
               .IsUnicode(false);

            modelBuilder.Entity<SV_Service>()
               .Property(e => e.OrderBy)
               .IsUnicode(false);

            modelBuilder.Entity<MS_Doctor>()
              .Property(e => e.DoctorName)
              .IsUnicode(false);

            modelBuilder.Entity<MS_Doctor>()
              .Property(e => e.Degree)
              .IsUnicode(false);

            modelBuilder.Entity<MS_Doctor>()
              .Property(e => e.Specialization)
              .IsUnicode(false);
        }
    }
}
