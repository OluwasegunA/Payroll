﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Payroll_Application.Models
{
    public class MyDbContext:DbContext
    {
        public DbSet<UserEntity>Users { get; set; }
        public DbSet<CompanyInfoEntity> CompanyInfo { get; set; }
        public DbSet<BranchEntity> Branches { get; set; }
        public DbSet<StartDocumentNoEntity> StartDocumentNo { get; set; }
        public DbSet<EmployeeInfoEntity> EmployeeInfo { get; set; }
        public DbSet<TitleEntity> Titles { get; set; }
        public DbSet<LevelEntity> Levels { get; set; }
        public DbSet<EmploymentTypeEntity> EmployementType { get; set; }
        public DbSet<DepartmentEntity> Depts { get; set; }
        public DbSet<DesignationEntity> Designations { get; set; }
        public DbSet<DegreeEntity> Degrees { get; set; }
        public DbSet<CountryEntity> Countries { get; set; }
        public DbSet<StateEntity> States { get; set; }
        public DbSet<PrefixEntity> StaffPrefix { get; set; }
        public DbSet<PersonalInformationEntity> PersonalInfo { get; set; }
        public DbSet<EmpContactInfoEntity> EmployeeContactInfo { get; set; }
        public DbSet<NextofKinEntity> EmpNextofKin { get; set; }
        public DbSet<GurrantorEntity> EmpGurrantor { get; set; }
        public DbSet<ReferenceEntity> EmpReference { get; set; }
        public DbSet<EmpEmploymentEntity> EmpEmploymentInfo { get; set; }
        public DbSet<EmpExperienceEntity> EmpExperiences { get; set; }
        public DbSet<EmpQualificationEntity> EmpQualifications { get; set; }
        public DbSet<MedicalEntity> MedicalHistory { get; set; }
        public DbSet<AttachmentEntity> Attachments { get; set; }
        public DbSet<AllowanceEntity> Allowances { get; set; }
        public DbSet<PensionEntity> Pensions { get; set; }
        public DbSet<LoanEntity> Loans { get; set; }
        public DbSet<PenaltyEntity> Penalties { get; set; }
        public DbSet<SalaryEntity> Salaries { get; set; }
        public DbSet<StaffLoanEntity> StaffLoans { get; set; }
        public DbSet<DeductionEntity> StaffDeductions { get; set; }
        public DbSet<MessageEntity> Messages { get; set; }
        public DbSet<LeaveEntity> Leaves { get; set; }
        public DbSet<PAYEEntity> PayE { get; set; }
    }
}