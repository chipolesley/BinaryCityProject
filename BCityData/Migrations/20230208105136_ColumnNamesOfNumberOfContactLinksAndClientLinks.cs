using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BCityData.Migrations
{
    /// <inheritdoc />
    public partial class ColumnNamesOfNumberOfContactLinksAndClientLinks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfLinkedClients",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfLinkedContacts",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfLinkedClients",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "NumberOfLinkedContacts",
                table: "Clients");
        }
    }
}
