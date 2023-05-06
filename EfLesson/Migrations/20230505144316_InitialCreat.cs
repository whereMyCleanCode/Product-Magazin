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
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_name = table.Column<string>(type: "text", nullable: false),
                    user_phone = table.Column<int>(type: "integer", nullable: false),
                    user_address = table.Column<string>(type: "text", nullable: false),
                    fk_order_for_user_id_from_orders = table.Column<List<int>>(type: "integer[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "baskets",
                columns: table => new
                {
                    basket_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fk_product_id = table.Column<List<int>>(type: "integer[]", nullable: false),
                    fk_user_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_baskets", x => x.basket_id);
                    table.ForeignKey(
                        name: "FK_baskets_users_fk_user_id",
                        column: x => x.fk_user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    order_id = table.Column<string>(type: "text", nullable: false),
                    order_star_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    order_end_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    orders_state = table.Column<bool>(type: "boolean", nullable: false),
                    fk_products_id_from_order = table.Column<List<int>>(type: "integer[]", nullable: false),
                    fk_user_id_for_basket = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_orders_users_fk_user_id_for_basket",
                        column: x => x.fk_user_id_for_basket,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_name = table.Column<string>(type: "text", nullable: false),
                    product_price = table.Column<int>(type: "integer", nullable: false),
                    product_category = table.Column<string>(type: "text", nullable: false),
                    product_count = table.Column<int>(type: "integer", nullable: false),
                    product_photo = table.Column<string>(type: "text", nullable: false),
                    BasketModelBasketId = table.Column<int>(type: "integer", nullable: true),
                    OrderModelOrderId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_products_baskets_BasketModelBasketId",
                        column: x => x.BasketModelBasketId,
                        principalTable: "baskets",
                        principalColumn: "basket_id");
                    table.ForeignKey(
                        name: "FK_products_orders_OrderModelOrderId",
                        column: x => x.OrderModelOrderId,
                        principalTable: "orders",
                        principalColumn: "order_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_baskets_fk_user_id",
                table: "baskets",
                column: "fk_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_fk_user_id_for_basket",
                table: "orders",
                column: "fk_user_id_for_basket");

            migrationBuilder.CreateIndex(
                name: "IX_products_BasketModelBasketId",
                table: "products",
                column: "BasketModelBasketId");

            migrationBuilder.CreateIndex(
                name: "IX_products_OrderModelOrderId",
                table: "products",
                column: "OrderModelOrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "baskets");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
