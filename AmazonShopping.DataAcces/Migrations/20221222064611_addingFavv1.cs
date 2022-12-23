using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmazonShopping.DataAcces.Migrations
{
    public partial class addingFavv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favourit_Products_ProductId",
                table: "Favourit");

            migrationBuilder.DropForeignKey(
                name: "FK_Favourit_Users_UserId",
                table: "Favourit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favourit",
                table: "Favourit");

            migrationBuilder.RenameTable(
                name: "Favourit",
                newName: "Favourits");

            migrationBuilder.RenameIndex(
                name: "IX_Favourit_UserId",
                table: "Favourits",
                newName: "IX_Favourits_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Favourit_ProductId",
                table: "Favourits",
                newName: "IX_Favourits_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favourits",
                table: "Favourits",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Favourits_Products_ProductId",
                table: "Favourits",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Favourits_Users_UserId",
                table: "Favourits",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favourits_Products_ProductId",
                table: "Favourits");

            migrationBuilder.DropForeignKey(
                name: "FK_Favourits_Users_UserId",
                table: "Favourits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favourits",
                table: "Favourits");

            migrationBuilder.RenameTable(
                name: "Favourits",
                newName: "Favourit");

            migrationBuilder.RenameIndex(
                name: "IX_Favourits_UserId",
                table: "Favourit",
                newName: "IX_Favourit_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Favourits_ProductId",
                table: "Favourit",
                newName: "IX_Favourit_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favourit",
                table: "Favourit",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Favourit_Products_ProductId",
                table: "Favourit",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Favourit_Users_UserId",
                table: "Favourit",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
