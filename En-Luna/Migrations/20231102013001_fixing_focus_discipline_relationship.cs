using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace En_Luna.Migrations
{
    /// <inheritdoc />
    public partial class fixing_focus_discipline_relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Focuses_Disciplines_DisciplineId",
                table: "Focuses");

            migrationBuilder.DropIndex(
                name: "IX_Focuses_DisciplineId",
                table: "Focuses");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90f48527-5c18-41ff-82ea-579af628d9ad", "AQAAAAIAAYagAAAAECsGQK1e3sQBH3PoY6et7JfZbK3/+8jyI6Ffh+JoIZIbvrAH3tXZd97HFvDF5IMDyA==", "f7ee9153-ae5b-41ab-ac6f-dc90038d4d11" });

            migrationBuilder.CreateIndex(
                name: "IX_Focuses_DisciplineId",
                table: "Focuses",
                column: "DisciplineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Focuses_Disciplines_DisciplineId",
                table: "Focuses",
                column: "DisciplineId",
                principalTable: "Disciplines",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Focuses_Disciplines_DisciplineId",
                table: "Focuses");

            migrationBuilder.DropIndex(
                name: "IX_Focuses_DisciplineId",
                table: "Focuses");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "198b7c12-4ef1-434c-b208-10000090e301", "AQAAAAIAAYagAAAAEGYoZXDD4YOSQ2arPTiXTXSWg4NwLTPXK865PKIse1BTp5Vqcz6p0Ibafk2f2OM+Og==", "8527fad1-c593-4dd3-a1da-3a3a29049842" });

            migrationBuilder.CreateIndex(
                name: "IX_Focuses_DisciplineId",
                table: "Focuses",
                column: "DisciplineId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Focuses_Disciplines_DisciplineId",
                table: "Focuses",
                column: "DisciplineId",
                principalTable: "Disciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
