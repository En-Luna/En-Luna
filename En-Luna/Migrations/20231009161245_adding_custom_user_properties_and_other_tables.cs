using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace En_Luna.Migrations
{
    /// <inheritdoc />
    public partial class adding_custom_user_properties_and_other_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Identity",
                table: "UserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                schema: "Identity",
                table: "UserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                schema: "Identity",
                table: "UserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                schema: "Identity",
                table: "UserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<string>(
                name: "AboutMe",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                schema: "Identity",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BankAccountId",
                schema: "Identity",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CompanyTypeId",
                schema: "Identity",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContractorId",
                schema: "Identity",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentWorkload",
                schema: "Identity",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EmployerIdentificationNumber",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "HoursAvailablePerWeek",
                schema: "Identity",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsVerified",
                schema: "Identity",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SocialSecurityNumber",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SolicitorId",
                schema: "Identity",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BankAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoutingNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeadlineType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeadlineType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discipline",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discipline", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    AccountId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Document_User_AccountId1",
                        column: x => x.AccountId1,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Profession",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasSubtype = table.Column<bool>(type: "bit", nullable: false),
                    HasLicense = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profession", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectDeliverable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileFormat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectDeliverable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Software",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSubscription = table.Column<bool>(type: "bit", nullable: false),
                    SubscriptionMonthlyCost = table.Column<double>(type: "float", nullable: false),
                    InitialPurchaseCost = table.Column<double>(type: "float", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Software", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Solicitor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Focus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisciplineId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Focus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Focus_Discipline_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Discipline",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfessionDiscipline",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessionId = table.Column<int>(type: "int", nullable: false),
                    DisciplineId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionDiscipline", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfessionDiscipline_Discipline_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Discipline",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProfessionDiscipline_Profession_ProfessionId",
                        column: x => x.ProfessionId,
                        principalTable: "Profession",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Solicitation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolicitorId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsCancelled = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    County = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    SharedDriveUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstimatedEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeamMeetingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solicitation_Solicitor_SolicitorId",
                        column: x => x.SolicitorId,
                        principalTable: "Solicitor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Expertise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FocusId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expertise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expertise_Focus_FocusId",
                        column: x => x.FocusId,
                        principalTable: "Focus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contractor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessionDisciplineId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contractor_ProfessionDiscipline_ProfessionDisciplineId",
                        column: x => x.ProfessionDisciplineId,
                        principalTable: "ProfessionDiscipline",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SolicitationDeadline",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolicitationId = table.Column<int>(type: "int", nullable: false),
                    DeadlineTypeId = table.Column<int>(type: "int", nullable: false),
                    DeadlineDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitationDeadline", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolicitationDeadline_DeadlineType_DeadlineTypeId",
                        column: x => x.DeadlineTypeId,
                        principalTable: "DeadlineType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SolicitationDeadline_Solicitation_SolicitationId",
                        column: x => x.SolicitationId,
                        principalTable: "Solicitation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SolicitationRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolicitationId = table.Column<int>(type: "int", nullable: false),
                    ProjectDeliverableId = table.Column<int>(type: "int", nullable: false),
                    HasContractor = table.Column<bool>(type: "bit", nullable: false),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false),
                    IsCancelled = table.Column<bool>(type: "bit", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LumpSum = table.Column<double>(type: "float", nullable: false),
                    HourlyRate = table.Column<double>(type: "float", nullable: false),
                    SignBonus = table.Column<double>(type: "float", nullable: false),
                    Workload = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliverableDeadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractorTerminated = table.Column<bool>(type: "bit", nullable: false),
                    ContractorPaid = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitationRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolicitationRole_ProjectDeliverable_ProjectDeliverableId",
                        column: x => x.ProjectDeliverableId,
                        principalTable: "ProjectDeliverable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolicitationRole_Solicitation_SolicitationId",
                        column: x => x.SolicitationId,
                        principalTable: "Solicitation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SolicitationId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                    table.ForeignKey(
                        name: "FK_State_Solicitation_SolicitationId",
                        column: x => x.SolicitationId,
                        principalTable: "Solicitation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Specialty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpertiseId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specialty_Expertise_ExpertiseId",
                        column: x => x.ExpertiseId,
                        principalTable: "Expertise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractorSoftware",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractorId = table.Column<int>(type: "int", nullable: false),
                    SoftwareId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractorSoftware", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractorSoftware_Contractor_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "Contractor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractorSoftware_Software_SoftwareId",
                        column: x => x.SoftwareId,
                        principalTable: "Software",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractorUserId = table.Column<int>(type: "int", nullable: true),
                    SolicitorUserId = table.Column<int>(type: "int", nullable: true),
                    ReviewerId = table.Column<int>(type: "int", nullable: false),
                    SolicitationRoleId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractorUserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SolicitorUserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_SolicitationRole_SolicitationRoleId",
                        column: x => x.SolicitationRoleId,
                        principalTable: "SolicitationRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Review_User_ContractorUserId1",
                        column: x => x.ContractorUserId1,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Review_User_SolicitorUserId1",
                        column: x => x.SolicitorUserId1,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SolicitationContractor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractorId = table.Column<int>(type: "int", nullable: false),
                    SolicitationId = table.Column<int>(type: "int", nullable: false),
                    SolicitationRoleId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitationContractor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolicitationContractor_Contractor_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "Contractor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SolicitationContractor_SolicitationRole_SolicitationRoleId",
                        column: x => x.SolicitationRoleId,
                        principalTable: "SolicitationRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolicitationContractor_Solicitation_SolicitationId",
                        column: x => x.SolicitationId,
                        principalTable: "Solicitation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SolicitationRoleProvidedSoftware",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolicitationRoleId = table.Column<int>(type: "int", nullable: false),
                    SoftwareId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitationRoleProvidedSoftware", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolicitationRoleProvidedSoftware_Software_SoftwareId",
                        column: x => x.SoftwareId,
                        principalTable: "Software",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolicitationRoleProvidedSoftware_SolicitationRole_SolicitationRoleId",
                        column: x => x.SolicitationRoleId,
                        principalTable: "SolicitationRole",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SolicitationRoleRequiredSoftware",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolicitationRoleId = table.Column<int>(type: "int", nullable: false),
                    SoftwareId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitationRoleRequiredSoftware", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolicitationRoleRequiredSoftware_Software_SoftwareId",
                        column: x => x.SoftwareId,
                        principalTable: "Software",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolicitationRoleRequiredSoftware_SolicitationRole_SolicitationRoleId",
                        column: x => x.SolicitationRoleId,
                        principalTable: "SolicitationRole",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "License",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractorId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    LicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_License", x => x.Id);
                    table.ForeignKey(
                        name: "FK_License_Contractor_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "Contractor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_License_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StatusUpdate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolicitationContractorId = table.Column<int>(type: "int", nullable: true),
                    SolicitorId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusUpdate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatusUpdate_SolicitationContractor_SolicitationContractorId",
                        column: x => x.SolicitationContractorId,
                        principalTable: "SolicitationContractor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StatusUpdate_Solicitor_SolicitorId",
                        column: x => x.SolicitorId,
                        principalTable: "Solicitor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_AddressId",
                schema: "Identity",
                table: "User",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_BankAccountId",
                schema: "Identity",
                table: "User",
                column: "BankAccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_CompanyTypeId",
                schema: "Identity",
                table: "User",
                column: "CompanyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ContractorId",
                schema: "Identity",
                table: "User",
                column: "ContractorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_SolicitorId",
                schema: "Identity",
                table: "User",
                column: "SolicitorId",
                unique: true,
                filter: "[SolicitorId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Address_StateId",
                table: "Address",
                column: "StateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contractor_ProfessionDisciplineId",
                table: "Contractor",
                column: "ProfessionDisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractorSoftware_ContractorId",
                table: "ContractorSoftware",
                column: "ContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractorSoftware_SoftwareId",
                table: "ContractorSoftware",
                column: "SoftwareId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_AccountId1",
                table: "Document",
                column: "AccountId1");

            migrationBuilder.CreateIndex(
                name: "IX_Expertise_FocusId",
                table: "Expertise",
                column: "FocusId");

            migrationBuilder.CreateIndex(
                name: "IX_Focus_DisciplineId",
                table: "Focus",
                column: "DisciplineId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_License_ContractorId",
                table: "License",
                column: "ContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_License_StateId",
                table: "License",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionDiscipline_DisciplineId",
                table: "ProfessionDiscipline",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionDiscipline_ProfessionId",
                table: "ProfessionDiscipline",
                column: "ProfessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ContractorUserId1",
                table: "Review",
                column: "ContractorUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Review_SolicitationRoleId",
                table: "Review",
                column: "SolicitationRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_SolicitorUserId1",
                table: "Review",
                column: "SolicitorUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitation_SolicitorId",
                table: "Solicitation",
                column: "SolicitorId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitationContractor_ContractorId",
                table: "SolicitationContractor",
                column: "ContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitationContractor_SolicitationId",
                table: "SolicitationContractor",
                column: "SolicitationId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitationContractor_SolicitationRoleId",
                table: "SolicitationContractor",
                column: "SolicitationRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitationDeadline_DeadlineTypeId",
                table: "SolicitationDeadline",
                column: "DeadlineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitationDeadline_SolicitationId",
                table: "SolicitationDeadline",
                column: "SolicitationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SolicitationRole_ProjectDeliverableId",
                table: "SolicitationRole",
                column: "ProjectDeliverableId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitationRole_SolicitationId",
                table: "SolicitationRole",
                column: "SolicitationId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitationRoleProvidedSoftware_SoftwareId",
                table: "SolicitationRoleProvidedSoftware",
                column: "SoftwareId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitationRoleProvidedSoftware_SolicitationRoleId",
                table: "SolicitationRoleProvidedSoftware",
                column: "SolicitationRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitationRoleRequiredSoftware_SoftwareId",
                table: "SolicitationRoleRequiredSoftware",
                column: "SoftwareId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitationRoleRequiredSoftware_SolicitationRoleId",
                table: "SolicitationRoleRequiredSoftware",
                column: "SolicitationRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Specialty_ExpertiseId",
                table: "Specialty",
                column: "ExpertiseId");

            migrationBuilder.CreateIndex(
                name: "IX_State_SolicitationId",
                table: "State",
                column: "SolicitationId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusUpdate_SolicitationContractorId",
                table: "StatusUpdate",
                column: "SolicitationContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusUpdate_SolicitorId",
                table: "StatusUpdate",
                column: "SolicitorId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Address_AddressId",
                schema: "Identity",
                table: "User",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_BankAccount_BankAccountId",
                schema: "Identity",
                table: "User",
                column: "BankAccountId",
                principalTable: "BankAccount",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_CompanyType_CompanyTypeId",
                schema: "Identity",
                table: "User",
                column: "CompanyTypeId",
                principalTable: "CompanyType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Contractor_ContractorId",
                schema: "Identity",
                table: "User",
                column: "ContractorId",
                principalTable: "Contractor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Solicitor_SolicitorId",
                schema: "Identity",
                table: "User",
                column: "SolicitorId",
                principalTable: "Solicitor",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Address_AddressId",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_BankAccount_BankAccountId",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_CompanyType_CompanyTypeId",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Contractor_ContractorId",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Solicitor_SolicitorId",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "BankAccount");

            migrationBuilder.DropTable(
                name: "CompanyType");

            migrationBuilder.DropTable(
                name: "ContractorSoftware");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "License");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "SolicitationDeadline");

            migrationBuilder.DropTable(
                name: "SolicitationRoleProvidedSoftware");

            migrationBuilder.DropTable(
                name: "SolicitationRoleRequiredSoftware");

            migrationBuilder.DropTable(
                name: "Specialty");

            migrationBuilder.DropTable(
                name: "StatusUpdate");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "DeadlineType");

            migrationBuilder.DropTable(
                name: "Software");

            migrationBuilder.DropTable(
                name: "Expertise");

            migrationBuilder.DropTable(
                name: "SolicitationContractor");

            migrationBuilder.DropTable(
                name: "Focus");

            migrationBuilder.DropTable(
                name: "Contractor");

            migrationBuilder.DropTable(
                name: "SolicitationRole");

            migrationBuilder.DropTable(
                name: "ProfessionDiscipline");

            migrationBuilder.DropTable(
                name: "ProjectDeliverable");

            migrationBuilder.DropTable(
                name: "Solicitation");

            migrationBuilder.DropTable(
                name: "Discipline");

            migrationBuilder.DropTable(
                name: "Profession");

            migrationBuilder.DropTable(
                name: "Solicitor");

            migrationBuilder.DropIndex(
                name: "IX_User_AddressId",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_BankAccountId",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_CompanyTypeId",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ContractorId",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_SolicitorId",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AboutMe",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AddressId",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "BankAccountId",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CompanyTypeId",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ContractorId",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CurrentWorkload",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "EmployerIdentificationNumber",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "HoursAvailablePerWeek",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IsVerified",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "SocialSecurityNumber",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "SolicitorId",
                schema: "Identity",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Identity",
                table: "UserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                schema: "Identity",
                table: "UserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                schema: "Identity",
                table: "UserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                schema: "Identity",
                table: "UserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
