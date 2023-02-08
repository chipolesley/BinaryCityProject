using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BCityData.Migrations
{
    /// <inheritdoc />
    public partial class MakeContactAssignmentNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_ContactAssignments_ContactAssignmentsId",
                table: "Contacts");

            migrationBuilder.AlterColumn<int>(
                name: "ContactAssignmentsId",
                table: "Contacts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_ContactAssignments_ContactAssignmentsId",
                table: "Contacts",
                column: "ContactAssignmentsId",
                principalTable: "ContactAssignments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_ContactAssignments_ContactAssignmentsId",
                table: "Contacts");

            migrationBuilder.AlterColumn<int>(
                name: "ContactAssignmentsId",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_ContactAssignments_ContactAssignmentsId",
                table: "Contacts",
                column: "ContactAssignmentsId",
                principalTable: "ContactAssignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
