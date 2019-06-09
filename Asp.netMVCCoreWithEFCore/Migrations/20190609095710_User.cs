using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.netMVCCoreWithEFCore.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OfficeLocations",
                table: "Employees",
                type: "nvarchar(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "EmpCode",
                table: "Employees",
                type: "nvarchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OfficeLocations",
                table: "Employees",
                type: "nvarchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmpCode",
                table: "Employees",
                type: "nvarchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");
        }
    }
}
