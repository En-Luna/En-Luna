using En_Luna.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace En_Luna.Extensions
{
    internal static class ModelBuilderExtension
    {
        public static void ConfigureIdentityTableNames(this ModelBuilder builder) 
        {
            builder.Entity<User>(entity =>
            {
                entity.ToTable(name: "User", "Identity");
            });

            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role", "Identity");
            });

            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles", "Identity");
            });

            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims", "Identity");
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins", "Identity");
            });

            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims", "Identity");
            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens", "Identity");
            });

            builder.SeedAdminData();
        }

        public static void DefineRelationships(this ModelBuilder modelBuilder)
        {
            #region User
            modelBuilder.Entity<User>()
                .HasOne(x => x.Address)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasOne(x => x.Contractor)
                .WithOne(x => x.Account)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasOne(x => x.Solicitor)
                .WithOne(x => x.Account)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasOne(x => x.BankAccount)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasOne(x => x.CompanyType)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany(x => x.ContractorReviews)
                .WithOne(x => x.ContractorUser)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany(x => x.SolicitorReviews)
                .WithOne(x => x.SolicitorUser)
                .OnDelete(DeleteBehavior.NoAction);

            #endregion

            #region Address

            modelBuilder.Entity<Address>()
                .HasOne(x => x.State)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            #endregion

            #region Contractor

            modelBuilder.Entity<Contractor>()
                .HasOne(x => x.ProfessionDiscipline)
                .WithMany(x => x.Contractors)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Contractor>()
                .HasMany(x => x.Licenses)
                .WithOne(x => x.Contractor)
                .OnDelete(DeleteBehavior.NoAction);

            #endregion

            #region ContractorSoftware

            modelBuilder.Entity<ContractorSoftware>()
                .HasOne(x => x.Contractor)
                .WithMany(x => x.AvailableSoftware)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ContractorSoftware>()
                .HasOne(x => x.Software)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            #endregion

            #region Document

            modelBuilder.Entity<Document>()
                .HasOne(x => x.User)
                .WithMany(x => x.Documents)
                .OnDelete(DeleteBehavior.NoAction);

            #endregion

            #region Discipline

            modelBuilder.Entity<Discipline>()
                .HasMany(x => x.ProfessionDisciplines)
                .WithOne(x => x.Discipline)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Discipline>()
                .HasMany(x => x.Focuses)
                .WithOne(X => X.Discipline)
                .OnDelete(DeleteBehavior.NoAction);

            #endregion

            #region Profession

            modelBuilder.Entity<Profession>()
                .HasMany(x => x.ProfessionDisciplines)
                .WithOne(x => x.Profession)
                .OnDelete(DeleteBehavior.NoAction);

            #endregion

            #region License

            modelBuilder.Entity<License>()
                .HasOne(x => x.State)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            #endregion

            #region Review 

            modelBuilder.Entity<Review>()
                .HasOne(x => x.ContractorUser)
                .WithMany(x => x.ContractorReviews)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Review>()
                .HasOne(x => x.SolicitorUser)
                .WithMany(x => x.SolicitorReviews)
                .OnDelete(DeleteBehavior.NoAction);

            #endregion

            #region Solicitation

            modelBuilder.Entity<Solicitation>()
                .HasOne(x => x.Solicitor)
                .WithMany(x => x.Solicitations)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Solicitation>()
                .HasOne(x => x.Deadline)
                .WithOne(x => x.Solicitation)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Solicitation>()
                .HasMany(x => x.Contractors)
                .WithOne(x => x.Solicitation)
                .OnDelete(DeleteBehavior.NoAction);

            #endregion

            #region SolicitationContractor

            modelBuilder.Entity<SolicitationContractor>()
                .HasOne(x => x.Contractor)
                .WithMany(x => x.Solicitations)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SolicitationContractor>()
                .HasMany(x => x.StatusUpdates)
                .WithOne(x => x.Contractor)
                .OnDelete(DeleteBehavior.NoAction);

            #endregion

            #region SolicitationDeadline

            modelBuilder.Entity<SolicitationDeadline>()
                .HasOne(x => x.DeadlineType)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            #endregion

            #region SolicitationRole

            modelBuilder.Entity<SolicitationRole>()
                .HasMany(x => x.ProvidedSoftware)
                .WithOne(x => x.SolicitationRole)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SolicitationRole>()
                .HasMany(x => x.RequiredSoftware)
                .WithOne(x => x.SolicitationRole)
                .OnDelete(DeleteBehavior.NoAction);

            #endregion

            #region Solicitor

            modelBuilder.Entity<Solicitor>()
                .HasMany(x => x.StatusUpdates)
                .WithOne(x => x.Solicitor)
                .OnDelete(DeleteBehavior.NoAction);

            #endregion

            #region Specialty

            modelBuilder.Entity<Expertise>()
                .HasOne(x => x.Focus)
                .WithMany(x => x.Expertises)
                .OnDelete(DeleteBehavior.NoAction);

            #endregion
        }

        public static void SeedAdminData(this ModelBuilder modelBuilder)
        {
            string ADMIN_ID = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
            string ROLE_ID = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";

            //seed admin role
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });

            modelBuilder.Entity<Profession>().HasData(new Profession 
            {
                Id = 1,
                Name = "Admin",
                CreatedBy = "seed"
            });

            modelBuilder.Entity<Discipline>().HasData(new Discipline
            {
                Id = 1,
                Name = "Admin",
                CreatedBy = "seed"
            });

            modelBuilder.Entity<ProfessionDiscipline>().HasData(new ProfessionDiscipline 
            {
                Id = 1,
                ProfessionId = 1,
                DisciplineId = 1
            });

            modelBuilder.Entity<Contractor>().HasData(new Contractor
            {
                Id = 1,
                ProfessionDisciplineId = 1
            });

            modelBuilder.Entity<State>().HasData(new State
            {
                Id = 1,
                Name = "Colorado",
                Abbreviation = "CO"
            });

            
            modelBuilder.Entity<Address>().HasData(new Address
            {
                Id = 1,
                StateId = 1
            });

            modelBuilder.Entity<BankAccount>().HasData(new BankAccount
            {
                Id = 1,
            });

            //create user
            var appUser = new User
            {
                Id = ADMIN_ID,
                Email = "superadmin@superadmin.com",
                EmailConfirmed = true,
                FirstName = "Frank",
                LastName = "Ofoedu",
                UserName = "superadmin",
                NormalizedUserName = "SUPERADMIN",
                ContractorId = 1,
                AddressId = 1,
                BankAccountId = 1
            };

            //set user password
            PasswordHasher<User> ph = new PasswordHasher<User>();
            appUser.PasswordHash = ph.HashPassword(appUser, "jobbielol");

            //seed user
            modelBuilder.Entity<User>().HasData(appUser);

            //set user role to admin
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
        }
    }
}
