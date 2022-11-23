using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASM_Auto.Data.Migrations
{
    public partial class EditMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Users_UserId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Users_UserId1",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_UserId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_UserId1",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Product");

            migrationBuilder.CreateTable(
                name: "ProductUser",
                columns: table => new
                {
                    LikedProductsProductId = table.Column<int>(type: "int", nullable: false),
                    LikedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductUser", x => new { x.LikedProductsProductId, x.LikedUserId });
                    table.ForeignKey(
                        name: "FK_ProductUser_Product_LikedProductsProductId",
                        column: x => x.LikedProductsProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductUser_Users_LikedUserId",
                        column: x => x.LikedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductUser1",
                columns: table => new
                {
                    CartProductId = table.Column<int>(type: "int", nullable: false),
                    CartUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductUser1", x => new { x.CartProductId, x.CartUserId });
                    table.ForeignKey(
                        name: "FK_ProductUser1_Product_CartProductId",
                        column: x => x.CartProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductUser1_Users_CartUserId",
                        column: x => x.CartUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductUser_LikedUserId",
                table: "ProductUser",
                column: "LikedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductUser1_CartUserId",
                table: "ProductUser1",
                column: "CartUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductUser");

            migrationBuilder.DropTable(
                name: "ProductUser1");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Product",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "Product",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_UserId",
                table: "Product",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UserId1",
                table: "Product",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Users_UserId",
                table: "Product",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Users_UserId1",
                table: "Product",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
