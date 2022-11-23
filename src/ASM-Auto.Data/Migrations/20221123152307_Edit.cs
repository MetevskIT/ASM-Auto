using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASM_Auto.Data.Migrations
{
    public partial class Edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartUserProduct_AspNetUsers_IdentityUserId",
                schema: "dbo",
                table: "CartUserProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_CartUserProduct_UserId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CartUserProduct_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductUser_CartUserProduct_LikedUserId",
                table: "ProductUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductUser1_CartUserProduct_CartUserId",
                table: "ProductUser1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartUserProduct",
                schema: "dbo",
                table: "CartUserProduct");

            migrationBuilder.RenameTable(
                name: "CartUserProduct",
                schema: "dbo",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_CartUserProduct_IdentityUserId",
                table: "Users",
                newName: "IX_Users_IdentityUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Users_UserId",
                table: "Contacts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductUser_Users_LikedUserId",
                table: "ProductUser",
                column: "LikedUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductUser1_Users_CartUserId",
                table: "ProductUser1",
                column: "CartUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AspNetUsers_IdentityUserId",
                table: "Users",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Users_UserId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductUser_Users_LikedUserId",
                table: "ProductUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductUser1_Users_CartUserId",
                table: "ProductUser1");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_AspNetUsers_IdentityUserId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "CartUserProduct",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_Users_IdentityUserId",
                schema: "dbo",
                table: "CartUserProduct",
                newName: "IX_CartUserProduct_IdentityUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartUserProduct",
                schema: "dbo",
                table: "CartUserProduct",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartUserProduct_AspNetUsers_IdentityUserId",
                schema: "dbo",
                table: "CartUserProduct",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_CartUserProduct_UserId",
                table: "Contacts",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "CartUserProduct",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CartUserProduct_UserId",
                table: "Orders",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "CartUserProduct",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductUser_CartUserProduct_LikedUserId",
                table: "ProductUser",
                column: "LikedUserId",
                principalSchema: "dbo",
                principalTable: "CartUserProduct",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductUser1_CartUserProduct_CartUserId",
                table: "ProductUser1",
                column: "CartUserId",
                principalSchema: "dbo",
                principalTable: "CartUserProduct",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
