using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace En_Luna.Migrations
{
    /// <inheritdoc />
    public partial class update_table_names : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_State_StateId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Contractor_ProfessionDiscipline_ProfessionDisciplineId",
                table: "Contractor");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractorSoftware_Contractor_ContractorId",
                table: "ContractorSoftware");

            migrationBuilder.DropForeignKey(
                name: "FK_Document_User_UserId",
                table: "Document");

            migrationBuilder.DropForeignKey(
                name: "FK_Expertise_Focus_FocusId",
                table: "Expertise");

            migrationBuilder.DropForeignKey(
                name: "FK_Focus_Discipline_DisciplineId",
                table: "Focus");

            migrationBuilder.DropForeignKey(
                name: "FK_License_Contractor_ContractorId",
                table: "License");

            migrationBuilder.DropForeignKey(
                name: "FK_License_State_StateId",
                table: "License");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionDiscipline_Discipline_DisciplineId",
                table: "ProfessionDiscipline");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionDiscipline_Profession_ProfessionId",
                table: "ProfessionDiscipline");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_SolicitationRole_SolicitationRoleId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_User_ContractorUserId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_User_SolicitorUserId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitation_Solicitor_SolicitorId",
                table: "Solicitation");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitationContractor_Contractor_ContractorId",
                table: "SolicitationContractor");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitationContractor_SolicitationRole_SolicitationRoleId",
                table: "SolicitationContractor");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitationContractor_Solicitation_SolicitationId",
                table: "SolicitationContractor");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitationDeadline_DeadlineType_DeadlineTypeId",
                table: "SolicitationDeadline");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitationDeadline_Solicitation_SolicitationId",
                table: "SolicitationDeadline");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitationRole_ProjectDeliverable_ProjectDeliverableId",
                table: "SolicitationRole");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitationRole_Solicitation_SolicitationId",
                table: "SolicitationRole");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitationRoleProvidedSoftware_SolicitationRole_SolicitationRoleId",
                table: "SolicitationRoleProvidedSoftware");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitationRoleRequiredSoftware_SolicitationRole_SolicitationRoleId",
                table: "SolicitationRoleRequiredSoftware");

            migrationBuilder.DropForeignKey(
                name: "FK_Specialty_Expertise_ExpertiseId",
                table: "Specialty");

            migrationBuilder.DropForeignKey(
                name: "FK_State_Solicitation_SolicitationId",
                table: "State");

            migrationBuilder.DropForeignKey(
                name: "FK_StatusUpdate_SolicitationContractor_SolicitationContractorId",
                table: "StatusUpdate");

            migrationBuilder.DropForeignKey(
                name: "FK_StatusUpdate_Solicitor_SolicitorId",
                table: "StatusUpdate");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatusUpdate",
                table: "StatusUpdate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_State",
                table: "State");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specialty",
                table: "Specialty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Solicitor",
                table: "Solicitor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SolicitationRole",
                table: "SolicitationRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SolicitationDeadline",
                table: "SolicitationDeadline");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SolicitationContractor",
                table: "SolicitationContractor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Solicitation",
                table: "Solicitation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectDeliverable",
                table: "ProjectDeliverable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfessionDiscipline",
                table: "ProfessionDiscipline");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profession",
                table: "Profession");

            migrationBuilder.DropPrimaryKey(
                name: "PK_License",
                table: "License");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Focus",
                table: "Focus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expertise",
                table: "Expertise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Document",
                table: "Document");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Discipline",
                table: "Discipline");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeadlineType",
                table: "DeadlineType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contractor",
                table: "Contractor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyType",
                table: "CompanyType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BankAccount",
                table: "BankAccount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "StatusUpdate",
                newName: "StatusUpdates");

            migrationBuilder.RenameTable(
                name: "State",
                newName: "States");

            migrationBuilder.RenameTable(
                name: "Specialty",
                newName: "Specialties");

            migrationBuilder.RenameTable(
                name: "Solicitor",
                newName: "Solicitors");

            migrationBuilder.RenameTable(
                name: "SolicitationRole",
                newName: "SolicitationRoles");

            migrationBuilder.RenameTable(
                name: "SolicitationDeadline",
                newName: "SolicitationDeadlines");

            migrationBuilder.RenameTable(
                name: "SolicitationContractor",
                newName: "SolicitationContractors");

            migrationBuilder.RenameTable(
                name: "Solicitation",
                newName: "Solicitations");

            migrationBuilder.RenameTable(
                name: "Review",
                newName: "Reviews");

            migrationBuilder.RenameTable(
                name: "ProjectDeliverable",
                newName: "ProjectDeliverables");

            migrationBuilder.RenameTable(
                name: "ProfessionDiscipline",
                newName: "ProfessionDisciplines");

            migrationBuilder.RenameTable(
                name: "Profession",
                newName: "Professions");

            migrationBuilder.RenameTable(
                name: "License",
                newName: "Licenses");

            migrationBuilder.RenameTable(
                name: "Focus",
                newName: "Focuses");

            migrationBuilder.RenameTable(
                name: "Expertise",
                newName: "Expertises");

            migrationBuilder.RenameTable(
                name: "Document",
                newName: "Documents");

            migrationBuilder.RenameTable(
                name: "Discipline",
                newName: "Disciplines");

            migrationBuilder.RenameTable(
                name: "DeadlineType",
                newName: "DeadlineTypes");

            migrationBuilder.RenameTable(
                name: "Contractor",
                newName: "Contractors");

            migrationBuilder.RenameTable(
                name: "CompanyType",
                newName: "CompanyTypes");

            migrationBuilder.RenameTable(
                name: "BankAccount",
                newName: "BankAccounts");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_StatusUpdate_SolicitorId",
                table: "StatusUpdates",
                newName: "IX_StatusUpdates_SolicitorId");

            migrationBuilder.RenameIndex(
                name: "IX_StatusUpdate_SolicitationContractorId",
                table: "StatusUpdates",
                newName: "IX_StatusUpdates_SolicitationContractorId");

            migrationBuilder.RenameIndex(
                name: "IX_State_SolicitationId",
                table: "States",
                newName: "IX_States_SolicitationId");

            migrationBuilder.RenameIndex(
                name: "IX_Specialty_ExpertiseId",
                table: "Specialties",
                newName: "IX_Specialties_ExpertiseId");

            migrationBuilder.RenameIndex(
                name: "IX_SolicitationRole_SolicitationId",
                table: "SolicitationRoles",
                newName: "IX_SolicitationRoles_SolicitationId");

            migrationBuilder.RenameIndex(
                name: "IX_SolicitationRole_ProjectDeliverableId",
                table: "SolicitationRoles",
                newName: "IX_SolicitationRoles_ProjectDeliverableId");

            migrationBuilder.RenameIndex(
                name: "IX_SolicitationDeadline_SolicitationId",
                table: "SolicitationDeadlines",
                newName: "IX_SolicitationDeadlines_SolicitationId");

            migrationBuilder.RenameIndex(
                name: "IX_SolicitationDeadline_DeadlineTypeId",
                table: "SolicitationDeadlines",
                newName: "IX_SolicitationDeadlines_DeadlineTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_SolicitationContractor_SolicitationRoleId",
                table: "SolicitationContractors",
                newName: "IX_SolicitationContractors_SolicitationRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_SolicitationContractor_SolicitationId",
                table: "SolicitationContractors",
                newName: "IX_SolicitationContractors_SolicitationId");

            migrationBuilder.RenameIndex(
                name: "IX_SolicitationContractor_ContractorId",
                table: "SolicitationContractors",
                newName: "IX_SolicitationContractors_ContractorId");

            migrationBuilder.RenameIndex(
                name: "IX_Solicitation_SolicitorId",
                table: "Solicitations",
                newName: "IX_Solicitations_SolicitorId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_SolicitorUserId",
                table: "Reviews",
                newName: "IX_Reviews_SolicitorUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_SolicitationRoleId",
                table: "Reviews",
                newName: "IX_Reviews_SolicitationRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_ContractorUserId",
                table: "Reviews",
                newName: "IX_Reviews_ContractorUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfessionDiscipline_ProfessionId",
                table: "ProfessionDisciplines",
                newName: "IX_ProfessionDisciplines_ProfessionId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfessionDiscipline_DisciplineId",
                table: "ProfessionDisciplines",
                newName: "IX_ProfessionDisciplines_DisciplineId");

            migrationBuilder.RenameIndex(
                name: "IX_License_StateId",
                table: "Licenses",
                newName: "IX_Licenses_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_License_ContractorId",
                table: "Licenses",
                newName: "IX_Licenses_ContractorId");

            migrationBuilder.RenameIndex(
                name: "IX_Focus_DisciplineId",
                table: "Focuses",
                newName: "IX_Focuses_DisciplineId");

            migrationBuilder.RenameIndex(
                name: "IX_Expertise_FocusId",
                table: "Expertises",
                newName: "IX_Expertises_FocusId");

            migrationBuilder.RenameIndex(
                name: "IX_Document_UserId",
                table: "Documents",
                newName: "IX_Documents_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Contractor_ProfessionDisciplineId",
                table: "Contractors",
                newName: "IX_Contractors_ProfessionDisciplineId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_StateId",
                table: "Addresses",
                newName: "IX_Addresses_StateId");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Identity",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatusUpdates",
                table: "StatusUpdates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_States",
                table: "States",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specialties",
                table: "Specialties",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Solicitors",
                table: "Solicitors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SolicitationRoles",
                table: "SolicitationRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SolicitationDeadlines",
                table: "SolicitationDeadlines",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SolicitationContractors",
                table: "SolicitationContractors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Solicitations",
                table: "Solicitations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectDeliverables",
                table: "ProjectDeliverables",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfessionDisciplines",
                table: "ProfessionDisciplines",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Professions",
                table: "Professions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Licenses",
                table: "Licenses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Focuses",
                table: "Focuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expertises",
                table: "Expertises",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Documents",
                table: "Documents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Disciplines",
                table: "Disciplines",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeadlineTypes",
                table: "DeadlineTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contractors",
                table: "Contractors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyTypes",
                table: "CompanyTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankAccounts",
                table: "BankAccounts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ErrorLogs",
                columns: table => new
                {
                    ErrorLogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ErrorLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ErrorDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorLogs", x => x.ErrorLogId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_States_StateId",
                table: "Addresses",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contractors_ProfessionDisciplines_ProfessionDisciplineId",
                table: "Contractors",
                column: "ProfessionDisciplineId",
                principalTable: "ProfessionDisciplines",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractorSoftware_Contractors_ContractorId",
                table: "ContractorSoftware",
                column: "ContractorId",
                principalTable: "Contractors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_User_UserId",
                table: "Documents",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expertises_Focuses_FocusId",
                table: "Expertises",
                column: "FocusId",
                principalTable: "Focuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Focuses_Disciplines_DisciplineId",
                table: "Focuses",
                column: "DisciplineId",
                principalTable: "Disciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Licenses_Contractors_ContractorId",
                table: "Licenses",
                column: "ContractorId",
                principalTable: "Contractors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Licenses_States_StateId",
                table: "Licenses",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionDisciplines_Disciplines_DisciplineId",
                table: "ProfessionDisciplines",
                column: "DisciplineId",
                principalTable: "Disciplines",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionDisciplines_Professions_ProfessionId",
                table: "ProfessionDisciplines",
                column: "ProfessionId",
                principalTable: "Professions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_SolicitationRoles_SolicitationRoleId",
                table: "Reviews",
                column: "SolicitationRoleId",
                principalTable: "SolicitationRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_User_ContractorUserId",
                table: "Reviews",
                column: "ContractorUserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_User_SolicitorUserId",
                table: "Reviews",
                column: "SolicitorUserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitationContractors_Contractors_ContractorId",
                table: "SolicitationContractors",
                column: "ContractorId",
                principalTable: "Contractors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitationContractors_SolicitationRoles_SolicitationRoleId",
                table: "SolicitationContractors",
                column: "SolicitationRoleId",
                principalTable: "SolicitationRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitationContractors_Solicitations_SolicitationId",
                table: "SolicitationContractors",
                column: "SolicitationId",
                principalTable: "Solicitations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitationDeadlines_DeadlineTypes_DeadlineTypeId",
                table: "SolicitationDeadlines",
                column: "DeadlineTypeId",
                principalTable: "DeadlineTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitationDeadlines_Solicitations_SolicitationId",
                table: "SolicitationDeadlines",
                column: "SolicitationId",
                principalTable: "Solicitations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitationRoleProvidedSoftware_SolicitationRoles_SolicitationRoleId",
                table: "SolicitationRoleProvidedSoftware",
                column: "SolicitationRoleId",
                principalTable: "SolicitationRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitationRoleRequiredSoftware_SolicitationRoles_SolicitationRoleId",
                table: "SolicitationRoleRequiredSoftware",
                column: "SolicitationRoleId",
                principalTable: "SolicitationRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitationRoles_ProjectDeliverables_ProjectDeliverableId",
                table: "SolicitationRoles",
                column: "ProjectDeliverableId",
                principalTable: "ProjectDeliverables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitationRoles_Solicitations_SolicitationId",
                table: "SolicitationRoles",
                column: "SolicitationId",
                principalTable: "Solicitations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitations_Solicitors_SolicitorId",
                table: "Solicitations",
                column: "SolicitorId",
                principalTable: "Solicitors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Specialties_Expertises_ExpertiseId",
                table: "Specialties",
                column: "ExpertiseId",
                principalTable: "Expertises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_States_Solicitations_SolicitationId",
                table: "States",
                column: "SolicitationId",
                principalTable: "Solicitations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StatusUpdates_SolicitationContractors_SolicitationContractorId",
                table: "StatusUpdates",
                column: "SolicitationContractorId",
                principalTable: "SolicitationContractors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StatusUpdates_Solicitors_SolicitorId",
                table: "StatusUpdates",
                column: "SolicitorId",
                principalTable: "Solicitors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Addresses_AddressId",
                schema: "Identity",
                table: "User",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_BankAccounts_BankAccountId",
                schema: "Identity",
                table: "User",
                column: "BankAccountId",
                principalTable: "BankAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_CompanyTypes_CompanyTypeId",
                schema: "Identity",
                table: "User",
                column: "CompanyTypeId",
                principalTable: "CompanyTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Contractors_ContractorId",
                schema: "Identity",
                table: "User",
                column: "ContractorId",
                principalTable: "Contractors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Solicitors_SolicitorId",
                schema: "Identity",
                table: "User",
                column: "SolicitorId",
                principalTable: "Solicitors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_States_StateId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Contractors_ProfessionDisciplines_ProfessionDisciplineId",
                table: "Contractors");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractorSoftware_Contractors_ContractorId",
                table: "ContractorSoftware");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_User_UserId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Expertises_Focuses_FocusId",
                table: "Expertises");

            migrationBuilder.DropForeignKey(
                name: "FK_Focuses_Disciplines_DisciplineId",
                table: "Focuses");

            migrationBuilder.DropForeignKey(
                name: "FK_Licenses_Contractors_ContractorId",
                table: "Licenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Licenses_States_StateId",
                table: "Licenses");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionDisciplines_Disciplines_DisciplineId",
                table: "ProfessionDisciplines");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionDisciplines_Professions_ProfessionId",
                table: "ProfessionDisciplines");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_SolicitationRoles_SolicitationRoleId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_User_ContractorUserId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_User_SolicitorUserId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitationContractors_Contractors_ContractorId",
                table: "SolicitationContractors");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitationContractors_SolicitationRoles_SolicitationRoleId",
                table: "SolicitationContractors");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitationContractors_Solicitations_SolicitationId",
                table: "SolicitationContractors");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitationDeadlines_DeadlineTypes_DeadlineTypeId",
                table: "SolicitationDeadlines");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitationDeadlines_Solicitations_SolicitationId",
                table: "SolicitationDeadlines");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitationRoleProvidedSoftware_SolicitationRoles_SolicitationRoleId",
                table: "SolicitationRoleProvidedSoftware");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitationRoleRequiredSoftware_SolicitationRoles_SolicitationRoleId",
                table: "SolicitationRoleRequiredSoftware");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitationRoles_ProjectDeliverables_ProjectDeliverableId",
                table: "SolicitationRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitationRoles_Solicitations_SolicitationId",
                table: "SolicitationRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitations_Solicitors_SolicitorId",
                table: "Solicitations");

            migrationBuilder.DropForeignKey(
                name: "FK_Specialties_Expertises_ExpertiseId",
                table: "Specialties");

            migrationBuilder.DropForeignKey(
                name: "FK_States_Solicitations_SolicitationId",
                table: "States");

            migrationBuilder.DropForeignKey(
                name: "FK_StatusUpdates_SolicitationContractors_SolicitationContractorId",
                table: "StatusUpdates");

            migrationBuilder.DropForeignKey(
                name: "FK_StatusUpdates_Solicitors_SolicitorId",
                table: "StatusUpdates");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Addresses_AddressId",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_BankAccounts_BankAccountId",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_CompanyTypes_CompanyTypeId",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Contractors_ContractorId",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Solicitors_SolicitorId",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropTable(
                name: "ErrorLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatusUpdates",
                table: "StatusUpdates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_States",
                table: "States");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specialties",
                table: "Specialties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Solicitors",
                table: "Solicitors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Solicitations",
                table: "Solicitations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SolicitationRoles",
                table: "SolicitationRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SolicitationDeadlines",
                table: "SolicitationDeadlines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SolicitationContractors",
                table: "SolicitationContractors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectDeliverables",
                table: "ProjectDeliverables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Professions",
                table: "Professions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfessionDisciplines",
                table: "ProfessionDisciplines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Licenses",
                table: "Licenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Focuses",
                table: "Focuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expertises",
                table: "Expertises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Documents",
                table: "Documents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Disciplines",
                table: "Disciplines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeadlineTypes",
                table: "DeadlineTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contractors",
                table: "Contractors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyTypes",
                table: "CompanyTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BankAccounts",
                table: "BankAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Identity",
                table: "User");

            migrationBuilder.RenameTable(
                name: "StatusUpdates",
                newName: "StatusUpdate");

            migrationBuilder.RenameTable(
                name: "States",
                newName: "State");

            migrationBuilder.RenameTable(
                name: "Specialties",
                newName: "Specialty");

            migrationBuilder.RenameTable(
                name: "Solicitors",
                newName: "Solicitor");

            migrationBuilder.RenameTable(
                name: "Solicitations",
                newName: "Solicitation");

            migrationBuilder.RenameTable(
                name: "SolicitationRoles",
                newName: "SolicitationRole");

            migrationBuilder.RenameTable(
                name: "SolicitationDeadlines",
                newName: "SolicitationDeadline");

            migrationBuilder.RenameTable(
                name: "SolicitationContractors",
                newName: "SolicitationContractor");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "Review");

            migrationBuilder.RenameTable(
                name: "ProjectDeliverables",
                newName: "ProjectDeliverable");

            migrationBuilder.RenameTable(
                name: "Professions",
                newName: "Profession");

            migrationBuilder.RenameTable(
                name: "ProfessionDisciplines",
                newName: "ProfessionDiscipline");

            migrationBuilder.RenameTable(
                name: "Licenses",
                newName: "License");

            migrationBuilder.RenameTable(
                name: "Focuses",
                newName: "Focus");

            migrationBuilder.RenameTable(
                name: "Expertises",
                newName: "Expertise");

            migrationBuilder.RenameTable(
                name: "Documents",
                newName: "Document");

            migrationBuilder.RenameTable(
                name: "Disciplines",
                newName: "Discipline");

            migrationBuilder.RenameTable(
                name: "DeadlineTypes",
                newName: "DeadlineType");

            migrationBuilder.RenameTable(
                name: "Contractors",
                newName: "Contractor");

            migrationBuilder.RenameTable(
                name: "CompanyTypes",
                newName: "CompanyType");

            migrationBuilder.RenameTable(
                name: "BankAccounts",
                newName: "BankAccount");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_StatusUpdates_SolicitorId",
                table: "StatusUpdate",
                newName: "IX_StatusUpdate_SolicitorId");

            migrationBuilder.RenameIndex(
                name: "IX_StatusUpdates_SolicitationContractorId",
                table: "StatusUpdate",
                newName: "IX_StatusUpdate_SolicitationContractorId");

            migrationBuilder.RenameIndex(
                name: "IX_States_SolicitationId",
                table: "State",
                newName: "IX_State_SolicitationId");

            migrationBuilder.RenameIndex(
                name: "IX_Specialties_ExpertiseId",
                table: "Specialty",
                newName: "IX_Specialty_ExpertiseId");

            migrationBuilder.RenameIndex(
                name: "IX_Solicitations_SolicitorId",
                table: "Solicitation",
                newName: "IX_Solicitation_SolicitorId");

            migrationBuilder.RenameIndex(
                name: "IX_SolicitationRoles_SolicitationId",
                table: "SolicitationRole",
                newName: "IX_SolicitationRole_SolicitationId");

            migrationBuilder.RenameIndex(
                name: "IX_SolicitationRoles_ProjectDeliverableId",
                table: "SolicitationRole",
                newName: "IX_SolicitationRole_ProjectDeliverableId");

            migrationBuilder.RenameIndex(
                name: "IX_SolicitationDeadlines_SolicitationId",
                table: "SolicitationDeadline",
                newName: "IX_SolicitationDeadline_SolicitationId");

            migrationBuilder.RenameIndex(
                name: "IX_SolicitationDeadlines_DeadlineTypeId",
                table: "SolicitationDeadline",
                newName: "IX_SolicitationDeadline_DeadlineTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_SolicitationContractors_SolicitationRoleId",
                table: "SolicitationContractor",
                newName: "IX_SolicitationContractor_SolicitationRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_SolicitationContractors_SolicitationId",
                table: "SolicitationContractor",
                newName: "IX_SolicitationContractor_SolicitationId");

            migrationBuilder.RenameIndex(
                name: "IX_SolicitationContractors_ContractorId",
                table: "SolicitationContractor",
                newName: "IX_SolicitationContractor_ContractorId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_SolicitorUserId",
                table: "Review",
                newName: "IX_Review_SolicitorUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_SolicitationRoleId",
                table: "Review",
                newName: "IX_Review_SolicitationRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ContractorUserId",
                table: "Review",
                newName: "IX_Review_ContractorUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfessionDisciplines_ProfessionId",
                table: "ProfessionDiscipline",
                newName: "IX_ProfessionDiscipline_ProfessionId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfessionDisciplines_DisciplineId",
                table: "ProfessionDiscipline",
                newName: "IX_ProfessionDiscipline_DisciplineId");

            migrationBuilder.RenameIndex(
                name: "IX_Licenses_StateId",
                table: "License",
                newName: "IX_License_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_Licenses_ContractorId",
                table: "License",
                newName: "IX_License_ContractorId");

            migrationBuilder.RenameIndex(
                name: "IX_Focuses_DisciplineId",
                table: "Focus",
                newName: "IX_Focus_DisciplineId");

            migrationBuilder.RenameIndex(
                name: "IX_Expertises_FocusId",
                table: "Expertise",
                newName: "IX_Expertise_FocusId");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_UserId",
                table: "Document",
                newName: "IX_Document_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Contractors_ProfessionDisciplineId",
                table: "Contractor",
                newName: "IX_Contractor_ProfessionDisciplineId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_StateId",
                table: "Address",
                newName: "IX_Address_StateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatusUpdate",
                table: "StatusUpdate",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_State",
                table: "State",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specialty",
                table: "Specialty",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Solicitor",
                table: "Solicitor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Solicitation",
                table: "Solicitation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SolicitationRole",
                table: "SolicitationRole",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SolicitationDeadline",
                table: "SolicitationDeadline",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SolicitationContractor",
                table: "SolicitationContractor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectDeliverable",
                table: "ProjectDeliverable",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profession",
                table: "Profession",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfessionDiscipline",
                table: "ProfessionDiscipline",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_License",
                table: "License",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Focus",
                table: "Focus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expertise",
                table: "Expertise",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Document",
                table: "Document",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Discipline",
                table: "Discipline",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeadlineType",
                table: "DeadlineType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contractor",
                table: "Contractor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyType",
                table: "CompanyType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankAccount",
                table: "BankAccount",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_State_StateId",
                table: "Address",
                column: "StateId",
                principalTable: "State",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contractor_ProfessionDiscipline_ProfessionDisciplineId",
                table: "Contractor",
                column: "ProfessionDisciplineId",
                principalTable: "ProfessionDiscipline",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractorSoftware_Contractor_ContractorId",
                table: "ContractorSoftware",
                column: "ContractorId",
                principalTable: "Contractor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_User_UserId",
                table: "Document",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expertise_Focus_FocusId",
                table: "Expertise",
                column: "FocusId",
                principalTable: "Focus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Focus_Discipline_DisciplineId",
                table: "Focus",
                column: "DisciplineId",
                principalTable: "Discipline",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_License_Contractor_ContractorId",
                table: "License",
                column: "ContractorId",
                principalTable: "Contractor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_License_State_StateId",
                table: "License",
                column: "StateId",
                principalTable: "State",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionDiscipline_Discipline_DisciplineId",
                table: "ProfessionDiscipline",
                column: "DisciplineId",
                principalTable: "Discipline",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionDiscipline_Profession_ProfessionId",
                table: "ProfessionDiscipline",
                column: "ProfessionId",
                principalTable: "Profession",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_SolicitationRole_SolicitationRoleId",
                table: "Review",
                column: "SolicitationRoleId",
                principalTable: "SolicitationRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_User_ContractorUserId",
                table: "Review",
                column: "ContractorUserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_User_SolicitorUserId",
                table: "Review",
                column: "SolicitorUserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitation_Solicitor_SolicitorId",
                table: "Solicitation",
                column: "SolicitorId",
                principalTable: "Solicitor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitationContractor_Contractor_ContractorId",
                table: "SolicitationContractor",
                column: "ContractorId",
                principalTable: "Contractor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitationContractor_SolicitationRole_SolicitationRoleId",
                table: "SolicitationContractor",
                column: "SolicitationRoleId",
                principalTable: "SolicitationRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitationContractor_Solicitation_SolicitationId",
                table: "SolicitationContractor",
                column: "SolicitationId",
                principalTable: "Solicitation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitationDeadline_DeadlineType_DeadlineTypeId",
                table: "SolicitationDeadline",
                column: "DeadlineTypeId",
                principalTable: "DeadlineType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitationDeadline_Solicitation_SolicitationId",
                table: "SolicitationDeadline",
                column: "SolicitationId",
                principalTable: "Solicitation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitationRole_ProjectDeliverable_ProjectDeliverableId",
                table: "SolicitationRole",
                column: "ProjectDeliverableId",
                principalTable: "ProjectDeliverable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitationRole_Solicitation_SolicitationId",
                table: "SolicitationRole",
                column: "SolicitationId",
                principalTable: "Solicitation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitationRoleProvidedSoftware_SolicitationRole_SolicitationRoleId",
                table: "SolicitationRoleProvidedSoftware",
                column: "SolicitationRoleId",
                principalTable: "SolicitationRole",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitationRoleRequiredSoftware_SolicitationRole_SolicitationRoleId",
                table: "SolicitationRoleRequiredSoftware",
                column: "SolicitationRoleId",
                principalTable: "SolicitationRole",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Specialty_Expertise_ExpertiseId",
                table: "Specialty",
                column: "ExpertiseId",
                principalTable: "Expertise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_State_Solicitation_SolicitationId",
                table: "State",
                column: "SolicitationId",
                principalTable: "Solicitation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StatusUpdate_SolicitationContractor_SolicitationContractorId",
                table: "StatusUpdate",
                column: "SolicitationContractorId",
                principalTable: "SolicitationContractor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StatusUpdate_Solicitor_SolicitorId",
                table: "StatusUpdate",
                column: "SolicitorId",
                principalTable: "Solicitor",
                principalColumn: "Id");

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
    }
}
