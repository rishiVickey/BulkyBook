using Microsoft.EntityFrameworkCore.Migrations;

namespace BulkuBook.DataAccess.Migrations
{
    public partial class AddPhoenNumbertoCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "companies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "companies");
        }
    }
}
