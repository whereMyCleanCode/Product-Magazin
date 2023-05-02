using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EfLesson.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderModel",
                columns: table => new
                {
                    OrderId = table.Column<string>(type: "text", nullable: false),
                    OrderStartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OrderEndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OrderState = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    ProductsId = table.Column<List<int>>(type: "integer[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderModel", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<int>(type: "integer", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    OrdersId = table.Column<List<int>>(type: "integer[]", nullable: false),
                    BasketId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "usersbaskets",
                columns: table => new
                {
                    BasketId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    ProductsId = table.Column<List<int>>(type: "integer[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usersbaskets", x => x.BasketId);
                });

            migrationBuilder.CreateTable(
                name: "OrderModelUserModel",
                columns: table => new
                {
                    OrdersOrderId = table.Column<string>(type: "text", nullable: false),
                    UsersUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderModelUserModel", x => new { x.OrdersOrderId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_OrderModelUserModel_OrderModel_OrdersOrderId",
                        column: x => x.OrdersOrderId,
                        principalTable: "OrderModel",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderModelUserModel_users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasketModelUserModel",
                columns: table => new
                {
                    UserBasketBasketId = table.Column<int>(type: "integer", nullable: false),
                    UserModelsUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketModelUserModel", x => new { x.UserBasketBasketId, x.UserModelsUserId });
                    table.ForeignKey(
                        name: "FK_BasketModelUserModel_users_UserModelsUserId",
                        column: x => x.UserModelsUserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketModelUserModel_usersbaskets_UserBasketBasketId",
                        column: x => x.UserBasketBasketId,
                        principalTable: "usersbaskets",
                        principalColumn: "BasketId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productscatalog",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductName = table.Column<string>(type: "text", nullable: false),
                    ProductPrice = table.Column<int>(type: "integer", nullable: false),
                    ProductCategory = table.Column<string>(type: "text", nullable: false),
                    ProductCount = table.Column<int>(type: "integer", nullable: false),
                    ProductPhoto = table.Column<string>(type: "text", nullable: false),
                    BasketModelBasketId = table.Column<int>(type: "integer", nullable: true),
                    OrderModelOrderId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productscatalog", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_productscatalog_OrderModel_OrderModelOrderId",
                        column: x => x.OrderModelOrderId,
                        principalTable: "OrderModel",
                        principalColumn: "OrderId");
                    table.ForeignKey(
                        name: "FK_productscatalog_usersbaskets_BasketModelBasketId",
                        column: x => x.BasketModelBasketId,
                        principalTable: "usersbaskets",
                        principalColumn: "BasketId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketModelUserModel_UserModelsUserId",
                table: "BasketModelUserModel",
                column: "UserModelsUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderModelUserModel_UsersUserId",
                table: "OrderModelUserModel",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_productscatalog_BasketModelBasketId",
                table: "productscatalog",
                column: "BasketModelBasketId");

            migrationBuilder.CreateIndex(
                name: "IX_productscatalog_OrderModelOrderId",
                table: "productscatalog",
                column: "OrderModelOrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketModelUserModel");

            migrationBuilder.DropTable(
                name: "OrderModelUserModel");

            migrationBuilder.DropTable(
                name: "productscatalog");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "OrderModel");

            migrationBuilder.DropTable(
                name: "usersbaskets");
        }
    }
}
