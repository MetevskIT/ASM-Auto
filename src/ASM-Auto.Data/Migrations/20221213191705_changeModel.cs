using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASM_Auto.Data.Migrations
{
    public partial class changeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "CartProduct",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Product_ProductId",
                table: "Orders",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartProduct_Orders_OrderId",
                table: "CartProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Product_ProductId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProductId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_CartProduct_OrderId",
                table: "CartProduct");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "CartProduct");

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    OrderedProductsProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrdersOrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.OrderedProductsProductId, x.OrdersOrderId });
                    table.ForeignKey(
                        name: "FK_OrderProduct_Orders_OrdersOrderId",
                        column: x => x.OrdersOrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Product_OrderedProductsProductId",
                        column: x => x.OrderedProductsProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_OrdersOrderId",
                table: "OrderProduct",
                column: "OrdersOrderId");
        }
    }
}
