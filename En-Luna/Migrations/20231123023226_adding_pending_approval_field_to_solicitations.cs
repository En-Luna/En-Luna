using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace En_Luna.Migrations
{
    /// <inheritdoc />
    public partial class adding_pending_approval_field_to_solicitations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PendingApproval",
                table: "Solicitations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0a0f040b-4170-4e0b-982a-ce9f742d6f63", "AQAAAAIAAYagAAAAEIkE92Mn4XS1Ws5/GUQElFSocXpMkqS+JhXNGrHVGPK4KwksyBTMmHJ177ade4tApg==", "4ea6724d-4c5e-493c-8d7f-f65a7bc0222e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PendingApproval",
                table: "Solicitations");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90f48527-5c18-41ff-82ea-579af628d9ad", "AQAAAAIAAYagAAAAECsGQK1e3sQBH3PoY6et7JfZbK3/+8jyI6Ffh+JoIZIbvrAH3tXZd97HFvDF5IMDyA==", "f7ee9153-ae5b-41ab-ac6f-dc90038d4d11" });
        }
    }
}
