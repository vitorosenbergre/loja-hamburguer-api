using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyEFProject.Migrations
{
    /// <inheritdoc />
    public partial class MudancaRelacionamentos : Migration
    {
        /// <inheritdoc />
protected override void Up(MigrationBuilder migrationBuilder)
{
    // Remover as chaves estrangeiras
    migrationBuilder.DropForeignKey(
        name: "FK_OrderProducts_Orders_OrderId",
        table: "OrderProducts");

    migrationBuilder.DropForeignKey(
        name: "FK_OrderProducts_Products_ProductId",
        table: "OrderProducts");

    // Remover a chave primária
    migrationBuilder.DropPrimaryKey(
        name: "PK_OrderProducts",
        table: "OrderProducts");

    // Realizar a modificação desejada (por exemplo, adicionar uma nova chave primária)
    // Exemplificando um novo comando para adicionar a chave primária
    migrationBuilder.AddPrimaryKey(
        name: "PK_OrderProducts",
        table: "OrderProducts",
        columns: new[] { "ProductId", "OrderId" });
    
    // Restaurar as chaves estrangeiras
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
}


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderProducts",
                table: "OrderProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrderProducts_OrderId",
                table: "OrderProducts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderProducts",
                table: "OrderProducts",
                columns: new[] { "OrderId", "ProductId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrderProducts",
                column: "ProductId");
        }
    }
}
