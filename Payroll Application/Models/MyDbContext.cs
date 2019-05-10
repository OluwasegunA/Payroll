using System;
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
        public DbSet<EmpEmploymentEntity> EmpEmploymentInfo { get; set; }
        public DbSet<EmpExperienceEntity> EmpExperiences { get; set; }
        public DbSet<EmpQualificationEntity> EmpQualifications { get; set; }
    }
}