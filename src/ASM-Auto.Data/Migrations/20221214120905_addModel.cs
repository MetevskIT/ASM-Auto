using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASM_Auto.Data.Migrations
{
    public partial class addModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartProduct_Orders_OrderId",
                table: "CartProduct");

            migrationBuilder.DropIndex(
                name: "IX_CartProduct_OrderId",
                table: "CartProduct");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "CartProduct");

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrderProducts",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "CartProduct",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_OrderId",
                table: "CartProduct",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartProduct_Orders_OrderId",
                table: "CartProduct",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId");
        }
    }
}
