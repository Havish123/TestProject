using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestProject.Solution.Data.Migrations
{
    public partial class UpdateForeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Countries_CountryId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Products",
                newName: "MerchantId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CountryId",
                table: "Products",
                newName: "IX_Products_MerchantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Merchants_MerchantId",
                table: "Products",
                column: "MerchantId",
                principalTable: "Merchants",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Merchants_MerchantId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "MerchantId",
                table: "Products",
                newName: "CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_MerchantId",
                table: "Products",
                newName: "IX_Products_CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Countries_CountryId",
                table: "Products",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
