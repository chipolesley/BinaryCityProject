using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BCityData.Migrations
{
    /// <inheritdoc />
    public partial class MakeClientCodeNullable : Migration
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
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClientCode",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_ContactAssignments_ContactAssignmentsId",
                table: "Contacts",
                column: "ContactAssignmentsId",
                principalTable: "ContactAssignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ClientCode",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_ContactAssignments_ContactAssignmentsId",
                table: "Contacts",
                column: "ContactAssignmentsId",
                principalTable: "ContactAssignments",
                principalColumn: "Id");
        }
    }
}
