using APIGateway.AuthGrid;
using APIGateway.DomainObjects.Company;
using APIGateway.DomainObjects.Credit;
using APIGateway.DomainObjects.hrm;
using APIGateway.DomainObjects.Modules;
using APIGateway.DomainObjects.Questions;
using APIGateway.DomainObjects.UserAccount;
using APIGateway.DomainObjects.Workflow;
using APIGateway.Handlers.Seeder;
using APIGateway.MailHandler;
using GODP.APIsContinuation.DomainObjects.Account;
using GODP.APIsContinuation.DomainObjects.Company;
using GODP.APIsContinuation.DomainObjects.Currency;
using GODP.APIsContinuation.DomainObjects.Ifrs;
using GODP.APIsContinuation.DomainObjects.Operation;
using GODP.APIsContinuation.DomainObjects.Others;
using GODP.APIsContinuation.DomainObjects.Staff;
using GODP.APIsContinuation.DomainObjects.UserAccount;
using GODP.APIsContinuation.DomainObjects.Workflow;
using GODPAPIs.Contracts.GeneralExtension;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Data
{
    public class DataContext : IdentityDbContext<cor_useraccount>
    {
        public DataContext() { }
        public readonly IHttpContextAccessor _accessor;
        public DataContext(DbContextOptions<DataContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options) { _accessor = httpContextAccessor ; }


       /// <summary>
       /// hrm data objects starts
       /// </summary>

        public DbSet<hrm_setup_jobtitle> hrm_setup_jobtitle { get; set; } 
        public DbSet<hrm_setup_sub_skill> hrm_setup_sub_skill { get; set; }
        public DbSet<hrm_setup_jobgrade> hrm_setup_jobgrade { get; set; }
        public DbSet<hrm_setup_employmenttype> hrm_setup_employmenttype { get; set; }
        public DbSet<hrm_setup_employmentlevel> hrm_setup_employmentlevel { get; set; }
        public DbSet<hrm_setup_academic_qualification> hrm_setup_academic_qualification { get; set; }
        public DbSet<hrm_setup_academic_discipline> hrm_setup_academic_discipline { get; set; }
        public DbSet<hrm_setup_academic_grade> hrm_setup_academic_grade { get; set; }
        public DbSet<hrm_setup_high_school_subjects> hrm_setup_high_school_subjects { get; set; }
        public DbSet<hrm_setup_high_school_grade> hrm_setup_high_school_grades { get; set; }
        public DbSet<hrm_setup_proffessional_certification> hrm_setup_proffessional_certification { get; set; }
        public DbSet<hrm_setup_languages> hrm_setup_languages { get; set; }
        public DbSet<hrm_setup_proffesional_membership> hrm_setup_proffesional_membership { get; set; }
        public DbSet<hrm_setup_hmo> hrm_setup_hmo { get; set; }
        public DbSet<hrm_setup_gym_workouts> hrm_setup_gym_workouts { get; set; }
        public DbSet<hrm_setup_location> hrm_setup_location { get; set; }
        public DbSet<hrm_setup_hospital_management> hrm_setup_hospital_management { get; set; }
        // hrm setup stops

        // hrm employee starts
        public DbSet<hrm_emp_identification> hrm_emp_identifications { get; set; }
        public DbSet<hrm_emp_emergency_contact> hrm_emp_emergency_contact { get; set; }
        public DbSet<hrm_emp_dependent_contact> hrm_emp_dependent_contact { get; set; }
        public DbSet<hrm_emp_language> hrm_emp_language { get; set; }
        public DbSet<hrm_emp_career> hrm_emp_career { get; set; }
        public DbSet<hrm_emp_hobbies> hrm_emp_hobbies { get; set; }
        public DbSet<hrm_emp_referees> hrm_emp_referees { get; set; }
        public DbSet<hrm_emp_assets> hrm_emp_assets { get; set; }
        public DbSet<hrm_emp_prof_certification> hrm_emp_prof_certification { get; set; }
        public DbSet<hrm_emp_qualification> hrm_emp_qualification { get; set; }
        public DbSet<hrm_emp_hmo> hrm_emp_hmo { get; set; }
        public DbSet<hrm_emp_hmo_change_request> hrm_emp_hmo_change_request { get; set; }
        public DbSet<hrm_emp_hospital> hrm_emp_hospital { get; set; }
        public DbSet<hrm_emp_hospital_change_request> hrm_emp_hospital_change_request { get; set; }
        public DbSet<hrm_emp_hospital_meeting> hrm_emp_hospital_meeting { get; set; }
        public DbSet<hrm_emp_gym> hrm_emp_gym { get; set; }
        public DbSet<hrm_emp_gym_change_request> hrm_emp_gym_change_request { get; set; }
        public DbSet<hrm_emp_gym_meeting> hrm_emp_gym_meeting { get; set; }
        public DbSet<hrm_emp_skills> hrm_emp_skills { get; set; }
        public DbSet<hrm_staffs> hrm_staffs { get; set; }
        /// <summary>
        /// hrm data objects stops
        /// </summary>

        public DbSet<Questions> Questions { get; set; } 
        public DbSet<SessionChecker> SessionChecker { get; set; }
        public DbSet<LogingFailedChecker> LogingFailedChecker { get; set; }
        public DbSet<SolutionModule> SolutionModule { get; set; }
        public DbSet<OTPTracker> OTPTracker { get; set; }
        public DbSet<Tracker> Tracker { get; set; }
        public DbSet<ScrewIdentifierGrid> ScrewIdentifierGrid { get; set; }
        public DbSet<cor_emailconfig> cor_emailconfig { get; set; }
        public DbSet<cor_identification> cor_identification { get; set; }
        public DbSet<credit_documenttype> credit_documenttype { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<cor_staff> cor_staff { get; set; }
        public DbSet<cor_workflowtask> cor_workflowtask { get; set; }
        public DbSet<cor_companystructure> cor_companystructure { get; set; }
        public DbSet<cor_useremailconfirmation> Cor_Useremailconfirmations { get; set; }
        public virtual DbSet<cor_state> cor_state { get; set; } 
        public virtual DbSet<cor_userrole> cor_userrole { get; set; }
        public virtual DbSet<cor_userroleactivity> cor_userroleactivity { get; set; }
        public virtual DbSet<cor_activity> cor_activity { get; set; }
        public virtual DbSet<cor_activityparent> cor_activityparent { get; set; }
        public virtual DbSet<cor_useraccess> cor_useraccess { get; set; }
        public virtual DbSet<cor_operationtype> cor_operationtype { get; set; }
        public virtual DbSet<cor_workflowgroup> cor_workflowgroup { get; set; }
        public virtual DbSet<cor_companystructuredefinition> cor_companystructuredefinition { get; set; } 
        public virtual DbSet<cor_country> cor_country { get; set; } 
        public virtual DbSet<cor_company> cor_company { get; set; } 
        public virtual DbSet<cor_operation> cor_operation { get; set; }
        public virtual DbSet<cor_workflowaccess> cor_workflowaccess { get; set; }
        public virtual DbSet<cor_workflow> cor_workflow { get; set; } 
        public virtual DbSet<cor_userroleadditionalactivity> cor_userroleadditionalactivity { get; set; }
        public virtual DbSet<EmailMessage> EmailMessage { get; set; }
        public virtual DbSet<EmailAddress> EmailAddress { get; set; }
        public virtual DbSet<cor_branch> cor_branch { get; set; } 
        public virtual DbSet<cor_city> cor_city { get; set; } 
        public virtual DbSet<cor_currency> cor_currency { get; set; }
        public virtual DbSet<cor_currencyrate> cor_currencyrate { get; set; } 
        public virtual DbSet<cor_department> cor_department { get; set; }
        public virtual DbSet<cor_employertype> cor_employertype { get; set; } 
        public virtual DbSet<cor_gender> cor_gender { get; set; } 
        public virtual DbSet<cor_jobtitles> cor_jobtitles { get; set; } 
        public virtual DbSet<cor_maritalstatus> cor_maritalstatus { get; set; } 
        public virtual DbSet<cor_title> cor_title { get; set; } 
        public virtual DbSet<cor_workflowdetails> cor_workflowdetails { get; set; }
        public virtual DbSet<cor_workflowdetailsaccess> cor_workflowdetailsaccess { get; set; } 
        public virtual DbSet<cor_workflowlevel> cor_workflowlevel { get; set; }
        public virtual DbSet<cor_workflowlevelstaff> cor_workflowlevelstaff { get; set; } 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot config = builder.Build();
            optionsBuilder.EnableSensitiveDataLogging();  
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
        }

        public override int SaveChanges()
        {
            var loggedInUserId = _accessor?.HttpContext?.User?.FindFirst(x => x?.Type == "userId")?.Value ?? "useradmin";
            foreach (var entry in ChangeTracker.Entries<GeneralEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.Active = true;
                    entry.Entity.Deleted = false;
                    entry.Entity.Active = true;
                    entry.Entity.CreatedOn = DateTime.Now;
                    entry.Entity.CreatedBy = loggedInUserId;
                }
                else
                {
                    entry.Entity.UpdatedOn = DateTime.Now;
                    entry.Entity.UpdatedBy = loggedInUserId;
                }
            }
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var loggedInUserId = _accessor?.HttpContext?.User?.FindFirst(x => x?.Type == "userId")?.Value ?? "useradmin";
            foreach (var entry in ChangeTracker.Entries<GeneralEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.Active = true;
                    entry.Entity.Deleted = false;
                    entry.Entity.Active = true;
                    entry.Entity.CreatedOn = DateTime.Now;
                    entry.Entity.CreatedBy = loggedInUserId;
                }
                else
                {
                    entry.Entity.UpdatedOn = DateTime.Now;
                    entry.Entity.UpdatedBy = loggedInUserId;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
