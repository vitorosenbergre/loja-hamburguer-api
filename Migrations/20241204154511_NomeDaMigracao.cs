using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyEFProject.Migrations
{
    /// <inheritdoc />
    public partial class NomeDaMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersProducts_Orders_OrderId",
                table: "OrdersProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersProducts_Products_ProductId",
                table: "OrdersProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersOrders_Orders_OrderId",
                table: "UsersOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersOrders_Users_UserId",
                table: "UsersOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersOrders",
                table: "UsersOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdersProducts",
                table: "OrdersProducts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UsersOrders");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrdersProducts");

            migrationBuilder.RenameTable(
                name: "UsersOrders",
                newName: "UserOrders");

            migrationBuilder.RenameTable(
                name: "OrdersProducts",
                newName: "OrderProducts");

            migrationBuilder.RenameIndex(
                name: "IX_UsersOrders_OrderId",
                table: "UserOrders",
                newName: "IX_UserOrders_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrdersProducts_ProductId",
                table: "OrderProducts",
                newName: "IX_OrderProducts_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserOrders",
                table: "UserOrders",
                columns: new[] { "UserId", "OrderId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderProducts",
                table: "OrderProducts",
                columns: new[] { "OrderId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Orders_OrderId",
                table: "OrderProducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Products_ProductId",
                table: "OrderProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOrders_Orders_OrderId",
                table: "UserOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOrders_Users_UserId",
                table: "UserOrders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Orders_OrderId",
                table: "OrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Products_ProductId",
                table: "OrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOrders_Orders_OrderId",
                table: "UserOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOrders_Users_UserId",
                table: "UserOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserOrders",
                table: "UserOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderProducts",
                table: "OrderProducts");

            migrationBuilder.RenameTable(
                name: "UserOrders",
                newName: "UsersOrders");

            migrationBuilder.RenameTable(
                name: "OrderProducts",
                newName: "OrdersProducts");

            migrationBuilder.RenameIndex(
                name: "IX_UserOrders_OrderId",
                table: "UsersOrders",
                newName: "IX_UsersOrders_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrdersProducts",
                newName: "IX_OrdersProducts_ProductId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UsersOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "OrdersProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersOrders",
                table: "UsersOrders",
                columns: new[] { "UserId", "OrderId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdersProducts",
                table: "OrdersProducts",
                columns: new[] { "OrderId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersProducts_Orders_OrderId",
                table: "OrdersProducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersProducts_Products_ProductId",
                table: "OrdersProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersOrders_Orders_OrderId",
                table: "UsersOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersOrders_Users_UserId",
                table: "UsersOrders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
