using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace En_Luna.Migrations
{
    /// <inheritdoc />
    public partial class refactoring_relationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatusUpdates_SolicitationContractors_SolicitationContractorId",
                table: "StatusUpdates");

            migrationBuilder.DropTable(
                name: "SolicitationContractors");

            migrationBuilder.RenameColumn(
                name: "SolicitationContractorId",
                table: "StatusUpdates",
                newName: "SolicitationRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_StatusUpdates_SolicitationContractorId",
                table: "StatusUpdates",
                newName: "IX_StatusUpdates_SolicitationRoleId");

            //migrationBuilder.UpdateData(
            //    schema: "Identity",
            //    table: "User",
            //    keyColumn: "Id",
            //    keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
            //    columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
            //    values: new object[] { "0fe5a0fc-778b-4bda-9fc9-3f0ca734b2b2", "AQAAAAIAAYagAAAAEJzv6XAuo3P8h8/258Oel8jvA0k1WacAae7LYydMXGQ5XfWWEcDBDN7ndE7asUIUtw==", "a3bdf5a8-1adb-4318-bec3-4172afa76284" });

            migrationBuilder.AddForeignKey(
                name: "FK_StatusUpdates_SolicitationRoles_SolicitationRoleId",
                table: "StatusUpdates",
                column: "SolicitationRoleId",
                principalTable: "SolicitationRoles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatusUpdates_SolicitationRoles_SolicitationRoleId",
                table: "StatusUpdates");

            migrationBuilder.RenameColumn(
                name: "SolicitationRoleId",
                table: "StatusUpdates",
                newName: "SolicitationContractorId");

            migrationBuilder.RenameIndex(
                name: "IX_StatusUpdates_SolicitationRoleId",
                table: "StatusUpdates",
                newName: "IX_StatusUpdates_SolicitationContractorId");

            migrationBuilder.CreateTable(
                name: "SolicitationContractors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractorId = table.Column<int>(type: "int", nullable: false),
                    SolicitationId = table.Column<int>(type: "int", nullable: false),
                    SolicitationRoleId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitationContractors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolicitationContractors_Contractors_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "Contractors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SolicitationContractors_SolicitationRoles_SolicitationRoleId",
                        column: x => x.SolicitationRoleId,
                        principalTable: "SolicitationRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolicitationContractors_Solicitations_SolicitationId",
                        column: x => x.SolicitationId,
                        principalTable: "Solicitations",
                        principalColumn: "Id");
                });

            //migrationBuilder.UpdateData(
            //    schema: "Identity",
            //    table: "User",
            //    keyColumn: "Id",
            //    keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
            //    columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
            //    values: new object[] { "5eb79d3a-8af3-40ab-8c33-a21090b2d0e9", "AQAAAAIAAYagAAAAEBwfs0qTC4sg1hL9Erd1CDuErw/UZvms8MllDVKdQ0I/0R4rHfMwNFnwtq1bDC9BVQ==", "d5aec173-82f7-4eca-a5c1-2352bca96d33" });

            migrationBuilder.CreateIndex(
                name: "IX_SolicitationContractors_ContractorId",
                table: "SolicitationContractors",
                column: "ContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitationContractors_SolicitationId",
                table: "SolicitationContractors",
                column: "SolicitationId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitationContractors_SolicitationRoleId",
                table: "SolicitationContractors",
                column: "SolicitationRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_StatusUpdates_SolicitationContractors_SolicitationContractorId",
                table: "StatusUpdates",
                column: "SolicitationContractorId",
                principalTable: "SolicitationContractors",
                principalColumn: "Id");
        }
    }
}
