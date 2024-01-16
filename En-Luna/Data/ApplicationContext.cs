using En_Luna.Data.Models;
using En_Luna.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace En_Luna.Data
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        #region DbSets

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<CompanyType> CompanyTypes { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<ContractorSoftware> ContractorSoftware { get; set; }
        public DbSet<DeadlineType> DeadlineTypes { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<Expertise> Expertises { get; set; }
        public DbSet<Focus> Focuses { get; set; }
        public DbSet<License> Licenses { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<ProfessionDiscipline> ProfessionDisciplines { get; set; }
        public DbSet<ProjectDeliverable> ProjectDeliverables { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Software> Software { get; set; }
        public DbSet<Solicitation> Solicitations { get; set; }
        public DbSet<SolicitationContractor> SolicitationContractors { get; set; }
        public DbSet<SolicitationDeadline> SolicitationDeadlines { get; set; }
        public DbSet<SolicitationRole> SolicitationRoles { get; set; }
        public DbSet<SolicitationRoleProvidedSoftware> SolicitationRoleProvidedSoftware { get; set; }
        public DbSet<SolicitationRoleRequiredSoftware> SolicitationRoleRequiredSoftware { get; set; }
        public DbSet<Solicitor> Solicitors { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<StatusUpdate> StatusUpdates { get; set; }

        #endregion

        private readonly IHttpContextAccessor? _httpContextAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public ApplicationContext(DbContextOptions<ApplicationContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationContext"/> class.
        /// </summary>
        public ApplicationContext() { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureIdentityTableNames();
            builder.DefineRelationships();
        }


        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return (await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken));
        }

        private void OnBeforeSaving()
        {
            IEnumerable<EntityEntry> entries = ChangeTracker.Entries();
            string userName = _httpContextAccessor?.HttpContext?.User?.Identity?.Name ?? "admin";

            foreach (var entry in entries)
            {
                // for entities that inherit from Audit,
                // set fields appropriately
                if (entry.Entity is BaseEntity trackable)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:

                            trackable.ModifiedDate = DateTime.Now;
                            trackable.ModifiedBy = userName;

                            // mark property as "don't touch"
                            // we don't want to update on a Modify operation
                            //entry.Property("CreatedDate").IsModified = false;
                            //entry.Property("CreatedBy").IsModified = false;
                            break;

                        case EntityState.Added:

                            trackable.CreatedDate = DateTime.Now;
                            trackable.CreatedBy = userName;
                            trackable.ModifiedDate = DateTime.Now;
                            trackable.ModifiedBy = userName;
                            break;
                    }
                }
            }
        }
    }
}