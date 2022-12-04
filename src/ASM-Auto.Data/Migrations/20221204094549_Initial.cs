using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASM_Auto.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarsMakes",
                columns: table => new
                {
                    CarMakeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarMakeText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarsMakes", x => x.CarMakeId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "CleaningAccessories",
                columns: table => new
                {
                    CleaningAccessoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CleaningAccessoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CleaningAccessories", x => x.CleaningAccessoryId);
                });

            migrationBuilder.CreateTable(
                name: "ExteriorsAccessories",
                columns: table => new
                {
                    ExteriorAccessoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExteriorAccessory = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExteriorsAccessories", x => x.ExteriorAccessoryId);
                });

            migrationBuilder.CreateTable(
                name: "FoilsColor",
                columns: table => new
                {
                    FoilColorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoilColor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoilsColor", x => x.FoilColorId);
                });

            migrationBuilder.CreateTable(
                name: "FoilsPurpose",
                columns: table => new
                {
                    FoilPurposeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoilPurpose = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoilsPurpose", x => x.FoilPurposeId);
                });

            migrationBuilder.CreateTable(
                name: "FoilsTypes",
                columns: table => new
                {
                    FoilTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoilType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoilsTypes", x => x.FoilTypeId);
                });

            migrationBuilder.CreateTable(
                name: "InteriorsAccessories",
                columns: table => new
                {
                    InteriorAccessoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InteriorAccessory = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InteriorsAccessories", x => x.InteriorAccessoryId);
                });

            migrationBuilder.CreateTable(
                name: "LedlightsColors",
                columns: table => new
                {
                    LedlightsColorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LedlightColor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LedlightsColors", x => x.LedlightsColorId);
                });

            migrationBuilder.CreateTable(
                name: "LedlightsFormats",
                columns: table => new
                {
                    LedlightsFormatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LedlightFormat = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LedlightsFormats", x => x.LedlightsFormatId);
                });

            migrationBuilder.CreateTable(
                name: "LedlightsPowers",
                columns: table => new
                {
                    LedlightsPowerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LedlightPower = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LedlightsPowers", x => x.LedlightsPowerId);
                });

            migrationBuilder.CreateTable(
                name: "LedlightsTypes",
                columns: table => new
                {
                    LedlightsTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LedlightType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LedlightsTypes", x => x.LedlightsTypeId);
                });

            migrationBuilder.CreateTable(
                name: "MatsTypes",
                columns: table => new
                {
                    MatsTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatsTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatsTypes", x => x.MatsTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Theme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_Contacts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarsModels",
                columns: table => new
                {
                    CarModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarModelText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarMakeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarsModels", x => x.CarModelId);
                    table.ForeignKey(
                        name: "FK_CarsModels_CarsMakes_CarMakeId",
                        column: x => x.CarMakeId,
                        principalTable: "CarsMakes",
                        principalColumn: "CarMakeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    ProductTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.ProductTypeId);
                    table.ForeignKey(
                        name: "FK_ProductTypes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    FreeDelivery = table.Column<bool>(type: "bit", nullable: false),
                    CarMakeId = table.Column<int>(type: "int", nullable: true),
                    CarModelId = table.Column<int>(type: "int", nullable: true),
                    LedlightsTypeId = table.Column<int>(type: "int", nullable: true),
                    LedlightsPowerId = table.Column<int>(type: "int", nullable: true),
                    LedlightsColorId = table.Column<int>(type: "int", nullable: true),
                    LedlightsFormatId = table.Column<int>(type: "int", nullable: true),
                    FoilsTypeId = table.Column<int>(type: "int", nullable: true),
                    FoilsColorId = table.Column<int>(type: "int", nullable: true),
                    FoilsPurposeId = table.Column<int>(type: "int", nullable: true),
                    InteriorsAccessoryId = table.Column<int>(type: "int", nullable: true),
                    ExteriorsAccessoryId = table.Column<int>(type: "int", nullable: true),
                    CleaningAccessoryId = table.Column<int>(type: "int", nullable: true),
                    MatsTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_CarsMakes_CarMakeId",
                        column: x => x.CarMakeId,
                        principalTable: "CarsMakes",
                        principalColumn: "CarMakeId");
                    table.ForeignKey(
                        name: "FK_Product_CarsModels_CarModelId",
                        column: x => x.CarModelId,
                        principalTable: "CarsModels",
                        principalColumn: "CarModelId");
                    table.ForeignKey(
                        name: "FK_Product_CleaningAccessories_CleaningAccessoryId",
                        column: x => x.CleaningAccessoryId,
                        principalTable: "CleaningAccessories",
                        principalColumn: "CleaningAccessoryId");
                    table.ForeignKey(
                        name: "FK_Product_ExteriorsAccessories_ExteriorsAccessoryId",
                        column: x => x.ExteriorsAccessoryId,
                        principalTable: "ExteriorsAccessories",
                        principalColumn: "ExteriorAccessoryId");
                    table.ForeignKey(
                        name: "FK_Product_FoilsColor_FoilsColorId",
                        column: x => x.FoilsColorId,
                        principalTable: "FoilsColor",
                        principalColumn: "FoilColorId");
                    table.ForeignKey(
                        name: "FK_Product_FoilsPurpose_FoilsPurposeId",
                        column: x => x.FoilsPurposeId,
                        principalTable: "FoilsPurpose",
                        principalColumn: "FoilPurposeId");
                    table.ForeignKey(
                        name: "FK_Product_FoilsTypes_FoilsTypeId",
                        column: x => x.FoilsTypeId,
                        principalTable: "FoilsTypes",
                        principalColumn: "FoilTypeId");
                    table.ForeignKey(
                        name: "FK_Product_InteriorsAccessories_InteriorsAccessoryId",
                        column: x => x.InteriorsAccessoryId,
                        principalTable: "InteriorsAccessories",
                        principalColumn: "InteriorAccessoryId");
                    table.ForeignKey(
                        name: "FK_Product_LedlightsColors_LedlightsColorId",
                        column: x => x.LedlightsColorId,
                        principalTable: "LedlightsColors",
                        principalColumn: "LedlightsColorId");
                    table.ForeignKey(
                        name: "FK_Product_LedlightsFormats_LedlightsFormatId",
                        column: x => x.LedlightsFormatId,
                        principalTable: "LedlightsFormats",
                        principalColumn: "LedlightsFormatId");
                    table.ForeignKey(
                        name: "FK_Product_LedlightsPowers_LedlightsPowerId",
                        column: x => x.LedlightsPowerId,
                        principalTable: "LedlightsPowers",
                        principalColumn: "LedlightsPowerId");
                    table.ForeignKey(
                        name: "FK_Product_LedlightsTypes_LedlightsTypeId",
                        column: x => x.LedlightsTypeId,
                        principalTable: "LedlightsTypes",
                        principalColumn: "LedlightsTypeId");
                    table.ForeignKey(
                        name: "FK_Product_MatsTypes_MatsTypeId",
                        column: x => x.MatsTypeId,
                        principalTable: "MatsTypes",
                        principalColumn: "MatsTypeId");
                    table.ForeignKey(
                        name: "FK_Product_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "ProductTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "ProductUser",
                columns: table => new
                {
                    LikedId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LikedProductsProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductUser", x => new { x.LikedId, x.LikedProductsProductId });
                    table.ForeignKey(
                        name: "FK_ProductUser_AspNetUsers_LikedId",
                        column: x => x.LikedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductUser_Product_LikedProductsProductId",
                        column: x => x.LikedProductsProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductUser1",
                columns: table => new
                {
                    CartId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CartProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductUser1", x => new { x.CartId, x.CartProductId });
                    table.ForeignKey(
                        name: "FK_ProductUser1_AspNetUsers_CartId",
                        column: x => x.CartId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductUser1_Product_CartProductId",
                        column: x => x.CartProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CarsModels_CarMakeId",
                table: "CarsModels",
                column: "CarMakeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_UserId",
                table: "Contacts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_OrdersOrderId",
                table: "OrderProduct",
                column: "OrdersOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CarMakeId",
                table: "Product",
                column: "CarMakeId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CarModelId",
                table: "Product",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CleaningAccessoryId",
                table: "Product",
                column: "CleaningAccessoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ExteriorsAccessoryId",
                table: "Product",
                column: "ExteriorsAccessoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_FoilsColorId",
                table: "Product",
                column: "FoilsColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_FoilsPurposeId",
                table: "Product",
                column: "FoilsPurposeId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_FoilsTypeId",
                table: "Product",
                column: "FoilsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_InteriorsAccessoryId",
                table: "Product",
                column: "InteriorsAccessoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_LedlightsColorId",
                table: "Product",
                column: "LedlightsColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_LedlightsFormatId",
                table: "Product",
                column: "LedlightsFormatId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_LedlightsPowerId",
                table: "Product",
                column: "LedlightsPowerId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_LedlightsTypeId",
                table: "Product",
                column: "LedlightsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_MatsTypeId",
                table: "Product",
                column: "MatsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductTypeId",
                table: "Product",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_CategoryId",
                table: "ProductTypes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductUser_LikedProductsProductId",
                table: "ProductUser",
                column: "LikedProductsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductUser1_CartProductId",
                table: "ProductUser1",
                column: "CartProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "ProductUser");

            migrationBuilder.DropTable(
                name: "ProductUser1");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CarsModels");

            migrationBuilder.DropTable(
                name: "CleaningAccessories");

            migrationBuilder.DropTable(
                name: "ExteriorsAccessories");

            migrationBuilder.DropTable(
                name: "FoilsColor");

            migrationBuilder.DropTable(
                name: "FoilsPurpose");

            migrationBuilder.DropTable(
                name: "FoilsTypes");

            migrationBuilder.DropTable(
                name: "InteriorsAccessories");

            migrationBuilder.DropTable(
                name: "LedlightsColors");

            migrationBuilder.DropTable(
                name: "LedlightsFormats");

            migrationBuilder.DropTable(
                name: "LedlightsPowers");

            migrationBuilder.DropTable(
                name: "LedlightsTypes");

            migrationBuilder.DropTable(
                name: "MatsTypes");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "CarsMakes");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
