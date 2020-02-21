using Microsoft.EntityFrameworkCore.Migrations;

namespace CarDIler.Migrations
{
    public partial class C8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "Cars",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "AddByName",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddByPhoneNumber",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddByPosition",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddBySurname",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
