using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Amazon.Migrations
{
    /// <inheritdoc />
    public partial class data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductUser");

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_userId",
                table: "Products",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_userId",
                table: "Products",
                column: "userId",
                principalTable: "Users",
                principalColumn: "User_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_userId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_userId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "ProductUser",
                columns: table => new
                {
                    ProductsProduct_Id = table.Column<int>(type: "int", nullable: false),
                    usersUser_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductUser", x => new { x.ProductsProduct_Id, x.usersUser_Id });
                    table.ForeignKey(
                        name: "FK_ProductUser_Products_ProductsProduct_Id",
                        column: x => x.ProductsProduct_Id,
                        principalTable: "Products",
                        principalColumn: "Product_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductUser_Users_usersUser_Id",
                        column: x => x.usersUser_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductUser_usersUser_Id",
                table: "ProductUser",
                column: "usersUser_Id");
        }
    }
}
