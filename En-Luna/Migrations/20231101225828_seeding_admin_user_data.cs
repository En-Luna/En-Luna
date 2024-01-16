using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace En_Luna.Migrations
{
    /// <inheritdoc />
    public partial class seeding_admin_user_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BankAccounts",
                columns: new[] { "Id", "AccountNumber", "AccountType", "BankName", "CreatedBy", "CreatedDate", "IsDeleted", "IsVerified", "ModifiedBy", "ModifiedDate", "RoutingNumber" },
                values: new object[] { 1, "", "", "", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "" });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[] { 1, "seed", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin" });

            migrationBuilder.InsertData(
                table: "Professions",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "HasLicense", "HasSubtype", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[] { 1, "seed", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, false, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "341743f0-asd2–42de-afbf-59kmkkmk72cf6", "341743f0-asd2–42de-afbf-59kmkkmk72cf6", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Abbreviation", "CreatedBy", "CreatedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name", "SolicitationId" },
                values: new object[] { 1, "CO", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Colorado", null });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Address1", "Address2", "City", "Country", "CreatedBy", "CreatedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "StateId", "ZipCode" },
                values: new object[] { 1, "", "", "", null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "" });

            migrationBuilder.InsertData(
                table: "ProfessionDisciplines",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DisciplineId", "IsDeleted", "ModifiedBy", "ModifiedDate", "ProfessionId" },
                values: new object[] { 1, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Contractors",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "ProfessionDisciplineId" },
                values: new object[] { 1, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AboutMe", "AccessFailedCount", "AddressId", "BankAccountId", "CompanyName", "CompanyTypeId", "ConcurrencyStamp", "ContractorId", "CurrentWorkload", "Email", "EmailConfirmed", "EmployerIdentificationNumber", "FirstName", "HoursAvailablePerWeek", "IsDeleted", "IsVerified", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SocialSecurityNumber", "SolicitorId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "02174cf0–9412–4cfe-afbf-59f706d72cf6", "", 0, 1, 1, "", null, "198b7c12-4ef1-434c-b208-10000090e301", 1, 0, "superadmin@superadmin.com", true, "", "Frank", 0, false, false, "Ofoedu", false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAEGYoZXDD4YOSQ2arPTiXTXSWg4NwLTPXK865PKIse1BTp5Vqcz6p0Ibafk2f2OM+Og==", null, false, "8527fad1-c593-4dd3-a1da-3a3a29049842", "", null, false, "superadmin" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "341743f0-asd2–42de-afbf-59kmkkmk72cf6", "02174cf0–9412–4cfe-afbf-59f706d72cf6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "341743f0-asd2–42de-afbf-59kmkkmk72cf6", "02174cf0–9412–4cfe-afbf-59f706d72cf6" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6");

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BankAccounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contractors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProfessionDisciplines",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Professions",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
