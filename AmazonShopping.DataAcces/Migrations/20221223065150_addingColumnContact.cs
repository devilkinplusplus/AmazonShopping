using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmazonShopping.DataAcces.Migrations
{
    public partial class addingColumnContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Contacts");
        }
    }
}
