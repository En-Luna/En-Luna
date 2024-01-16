using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace En_Luna.Migrations
{
    /// <inheritdoc />
    public partial class fixing_user_related_relationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_User_AccountId1",
                table: "Document");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_User_ContractorUserId1",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_User_SolicitorUserId1",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_ContractorUserId1",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_SolicitorUserId1",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "ContractorUserId1",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "SolicitorUserId1",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Document");

            migrationBuilder.RenameColumn(
                name: "AccountId1",
                table: "Document",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Document_AccountId1",
                table: "Document",
                newName: "IX_Document_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "SolicitorUserId",
                table: "Review",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContractorUserId",
                table: "Review",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Review_ContractorUserId",
                table: "Review",
                column: "ContractorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_SolicitorUserId",
                table: "Review",
                column: "SolicitorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_User_UserId",
                table: "Document",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_User_UserId",
                table: "Document");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_User_ContractorUserId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_User_SolicitorUserId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_ContractorUserId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_SolicitorUserId",
                table: "Review");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Document",
                newName: "AccountId1");

            migrationBuilder.RenameIndex(
                name: "IX_Document_UserId",
                table: "Document",
                newName: "IX_Document_AccountId1");

            migrationBuilder.AlterColumn<int>(
                name: "SolicitorUserId",
                table: "Review",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ContractorUserId",
                table: "Review",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContractorUserId1",
                table: "Review",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SolicitorUserId1",
                table: "Review",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Document",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Review_ContractorUserId1",
                table: "Review",
                column: "ContractorUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Review_SolicitorUserId1",
                table: "Review",
                column: "SolicitorUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_User_AccountId1",
                table: "Document",
                column: "AccountId1",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_User_ContractorUserId1",
                table: "Review",
                column: "ContractorUserId1",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_User_SolicitorUserId1",
                table: "Review",
                column: "SolicitorUserId1",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
