using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace En_Luna.Migrations
{
    /// <inheritdoc />
    public partial class adding_profession_discipline_to_soliciation_role : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequiredProfessionDisciplineId",
                table: "SolicitationRoles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SolicitationRoles_RequiredProfessionDisciplineId",
                table: "SolicitationRoles",
                column: "RequiredProfessionDisciplineId");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitationRoles_ProfessionDisciplines_RequiredProfessionDisciplineId",
                table: "SolicitationRoles",
                column: "RequiredProfessionDisciplineId",
                principalTable: "ProfessionDisciplines",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolicitationRoles_ProfessionDisciplines_RequiredProfessionDisciplineId",
                table: "SolicitationRoles");

            migrationBuilder.DropIndex(
                name: "IX_SolicitationRoles_RequiredProfessionDisciplineId",
                table: "SolicitationRoles");

            migrationBuilder.DropColumn(
                name: "RequiredProfessionDisciplineId",
                table: "SolicitationRoles");
}
    }
}
