using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class Migration1st : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order_status",
                columns: table => new
                {
                    status_id = table.Column<int>(type: "int", nullable: false),
                    status_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Order_st__3683B531D26FAE01", x => x.status_id);
                });

            migrationBuilder.CreateTable(
                name: "Specification",
                columns: table => new
                {
                    spec_id = table.Column<int>(type: "int", nullable: false),
                    spec_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    spec_value = table.Column<int>(type: "int", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Specific__F670C567ADF9717D", x => x.spec_id);
                });

            migrationBuilder.CreateTable(
                name: "User_roles",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false),
                    role_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__User_rol__760965CC51FF79F2", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "Product_category",
                columns: table => new
                {
                    product_category_id = table.Column<int>(type: "int", nullable: false),
                    product_category_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    spec_id = table.Column<int>(type: "int", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_category", x => x.product_category_id);
                    table.ForeignKey(
                        name: "FK_Product_category_Specification",
                        column: x => x.spec_id,
                        principalTable: "Specification",
                        principalColumn: "spec_id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    phone_number = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    addres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_Users_User_roles",
                        column: x => x.role_id,
                        principalTable: "User_roles",
                        principalColumn: "role_id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false),
                    product_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    product_price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    product_count = table.Column<int>(type: "int", nullable: false),
                    product_category_id = table.Column<int>(type: "int", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_Products_Product_category",
                        column: x => x.product_category_id,
                        principalTable: "Product_category",
                        principalColumn: "product_category_id");
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    cart_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    product_count = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.cart_id);
                    table.ForeignKey(
                        name: "FK_Cart_Products",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "product_id");
                    table.ForeignKey(
                        name: "FK_Cart_Users",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    status_id = table.Column<int>(type: "int", nullable: false),
                    product_count = table.Column<int>(type: "int", nullable: false),
                    order_date = table.Column<DateTime>(type: "date", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_Orders_Order_status",
                        column: x => x.status_id,
                        principalTable: "Order_status",
                        principalColumn: "status_id");
                    table.ForeignKey(
                        name: "FK_Orders_Products",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "product_id");
                    table.ForeignKey(
                        name: "FK_Orders_Users",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "Specs_for_product",
                columns: table => new
                {
                    spec_product_id = table.Column<int>(type: "int", nullable: false),
                    spec_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    value = table.Column<int>(type: "int", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specs_for_product", x => x.spec_product_id);
                    table.ForeignKey(
                        name: "FK_Specs_for_product_Products",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "product_id");
                    table.ForeignKey(
                        name: "FK_Specs_for_product_Specification",
                        column: x => x.spec_id,
                        principalTable: "Specification",
                        principalColumn: "spec_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_product_id",
                table: "Cart",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_user_id",
                table: "Cart",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_product_id",
                table: "Orders",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_status_id",
                table: "Orders",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_user_id",
                table: "Orders",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_category_spec_id",
                table: "Product_category",
                column: "spec_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_product_category_id",
                table: "Products",
                column: "product_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Specs_for_product_product_id",
                table: "Specs_for_product",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Specs_for_product_spec_id",
                table: "Specs_for_product",
                column: "spec_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_role_id",
                table: "Users",
                column: "role_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Specs_for_product");

            migrationBuilder.DropTable(
                name: "Order_status");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "User_roles");

            migrationBuilder.DropTable(
                name: "Product_category");

            migrationBuilder.DropTable(
                name: "Specification");
        }
    }
}
