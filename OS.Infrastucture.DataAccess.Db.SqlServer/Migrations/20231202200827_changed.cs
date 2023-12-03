using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OS.Infrastucture.Db.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class changed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCart_Cart",
                table: "ProductCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCart_Product",
                table: "ProductCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCarts_Cart_CartId1",
                table: "ProductCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCarts_ProductBooth_ProductBoothId1",
                table: "ProductCarts");

            migrationBuilder.DropIndex(
                name: "IX_ProductCarts_CartId1",
                table: "ProductCarts");

            migrationBuilder.DropIndex(
                name: "IX_ProductCarts_ProductBoothId1",
                table: "ProductCarts");

            migrationBuilder.DropColumn(
                name: "CartId1",
                table: "ProductCarts");

            migrationBuilder.DropColumn(
                name: "ProductBoothId1",
                table: "ProductCarts");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCarts_Cart_CartId",
                table: "ProductCarts",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCarts_ProductBooth_ProductBoothId",
                table: "ProductCarts",
                column: "ProductBoothId",
                principalTable: "ProductBooth",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCarts_Cart_CartId",
                table: "ProductCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCarts_ProductBooth_ProductBoothId",
                table: "ProductCarts");

            migrationBuilder.AddColumn<int>(
                name: "CartId1",
                table: "ProductCarts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductBoothId1",
                table: "ProductCarts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCarts_CartId1",
                table: "ProductCarts",
                column: "CartId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCarts_ProductBoothId1",
                table: "ProductCarts",
                column: "ProductBoothId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCart_Cart",
                table: "ProductCarts",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCart_Product",
                table: "ProductCarts",
                column: "ProductBoothId",
                principalTable: "ProductBooth",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCarts_Cart_CartId1",
                table: "ProductCarts",
                column: "CartId1",
                principalTable: "Cart",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCarts_ProductBooth_ProductBoothId1",
                table: "ProductCarts",
                column: "ProductBoothId1",
                principalTable: "ProductBooth",
                principalColumn: "Id");
        }
    }
}
