using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASM_Auto.Data.Migrations
{
    public partial class serNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Product_ProductId",
                table: "Images");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "Images",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Product_ProductId",
                table: "Images",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Product_ProductId",
                table: "Images");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "Images",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Product_ProductId",
                table: "Images",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
