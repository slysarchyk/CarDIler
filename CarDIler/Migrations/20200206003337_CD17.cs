using Microsoft.EntityFrameworkCore.Migrations;

namespace CarDIler.Migrations
{
    public partial class CD17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddByName",
                table: "Cars",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AddByPhoneNumber",
                table: "Cars",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AddByPosition",
                table: "Cars",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AddBySurname",
                table: "Cars",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddByName",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "AddByPhoneNumber",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "AddByPosition",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "AddBySurname",
                table: "Cars");
        }
    }
}
