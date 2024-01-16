using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace En_Luna.Migrations
{
    /// <inheritdoc />
    public partial class adding_contractor_to_solicitation_role : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContractorId",
                table: "SolicitationRoles",
                type: "int",
                nullable: true);

            //migrationBuilder.UpdateData(
            //    schema: "Identity",
            //    table: "User",
            //    keyColumn: "Id",
            //    keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
            //    columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
            //    values: new object[] { "5eb79d3a-8af3-40ab-8c33-a21090b2d0e9", "AQAAAAIAAYagAAAAEBwfs0qTC4sg1hL9Erd1CDuErw/UZvms8MllDVKdQ0I/0R4rHfMwNFnwtq1bDC9BVQ==", "d5aec173-82f7-4eca-a5c1-2352bca96d33" });

            migrationBuilder.CreateIndex(
                name: "IX_SolicitationRoles_ContractorId",
                table: "SolicitationRoles",
                column: "ContractorId");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitationRoles_Contractors_ContractorId",
                table: "SolicitationRoles",
                column: "ContractorId",
                principalTable: "Contractors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolicitationRoles_Contractors_ContractorId",
                table: "SolicitationRoles");

            migrationBuilder.DropIndex(
                name: "IX_SolicitationRoles_ContractorId",
                table: "SolicitationRoles");

            migrationBuilder.DropColumn(
                name: "ContractorId",
                table: "SolicitationRoles");

            //migrationBuilder.UpdateData(
            //    schema: "Identity",
            //    table: "User",
            //    keyColumn: "Id",
            //    keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
            //    columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
            //    values: new object[] { "0cdc6799-1936-4c97-986f-8bcb27be36c8", "AQAAAAIAAYagAAAAECu24rpF+dCrW6RSfuMWev16iKQcJk1eI8xImv6vQD5KPZG9cRv4HQU2tfLHL2X3UA==", "17221e09-3d00-4fbc-83cc-4a5658e81aa9" });
        }
    }
}
