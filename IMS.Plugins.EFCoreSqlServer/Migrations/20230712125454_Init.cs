using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IMS.Plugins.EFCoreSqlServer.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.InventoryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "InventoryTransactions",
                columns: table => new
                {
                    InventoryTransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PONumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InventoryId = table.Column<int>(type: "int", nullable: false),
                    QauntityBefore = table.Column<int>(type: "int", nullable: false),
                    ActivityType = table.Column<int>(type: "int", nullable: false),
                    QauntityAfter = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoneBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryTransactions", x => x.InventoryTransactionId);
                    table.ForeignKey(
                        name: "FK_InventoryTransactions_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "InventoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductInventories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    InventoryId = table.Column<int>(type: "int", nullable: false),
                    InventoryQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInventories", x => new { x.ProductId, x.InventoryId });
                    table.ForeignKey(
                        name: "FK_ProductInventories_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "InventoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductInventories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTransactions",
                columns: table => new
                {
                    ProductTransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SONumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    QauntityBefore = table.Column<int>(type: "int", nullable: false),
                    ActivityType = table.Column<int>(type: "int", nullable: false),
                    QauntityAfter = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoneBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTransactions", x => x.ProductTransactionId);
                    table.ForeignKey(
                        name: "FK_ProductTransactions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "InventoryId", "InventoryName", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, "Case S-49", 129.99000000000001, 12 },
                    { 2, "M/B-X1333", 110.98999999999999, 8 },
                    { 3, "M/B-X1533", 120.98999999999999, 6 },
                    { 4, "M/B-X1933", 199.99000000000001, 4 },
                    { 5, "M/B-X2533", 129.99000000000001, 45 },
                    { 6, "M/B-X2733", 114.98999999999999, 3 },
                    { 7, "M/B-X3033", 129.99000000000001, 4 },
                    { 8, "M/B-X3133", 179.99000000000001, 15 },
                    { 9, "M/B-X3233", 164.99000000000001, 7 },
                    { 10, "M/B-X4333", 229.99000000000001, 15 },
                    { 11, "CPU I-30", 579.99000000000001, 6 },
                    { 12, "CPU I-29", 479.99000000000001, 8 },
                    { 13, "CPU X-400", 879.99000000000001, 7 },
                    { 14, "Case X-10", 100.98999999999999, 4 },
                    { 15, "Case X-21", 129.99000000000001, 20 },
                    { 16, "DDR10 450GB", 129.99000000000001, 68 },
                    { 17, "DDR12 600GB", 159.99000000000001, 50 },
                    { 18, "SSD 150TB", 199.99000000000001, 12 },
                    { 19, "RTX-7090Ti 100GB", 899.99000000000001, 12 },
                    { 20, "P-S 2000 Wat", 159.99000000000001, 46 },
                    { 21, "P-S 2200 Wat", 199.99000000000001, 12 },
                    { 22, "P-S 2500 Wat", 210.99000000000001, 8 },
                    { 23, "SSD 100TB", 60.990000000000002, 6 },
                    { 24, "SSD 200TB", 111.98999999999999, 4 },
                    { 25, "SSD 2500TB", 169.99000000000001, 45 },
                    { 26, "SSD 300TB", 174.99000000000001, 3 },
                    { 27, "SSD 3500TB", 189.99000000000001, 4 },
                    { 28, "RTX-5090Ti 80GB", 579.99000000000001, 15 },
                    { 29, "RTX-5090Ti 90GB", 664.99000000000001, 7 },
                    { 30, "M/B-X4344", 229.99000000000001, 15 },
                    { 31, "CPU Z-30", 579.99000000000001, 6 },
                    { 32, "CPU Z-29", 479.99000000000001, 8 },
                    { 33, "CPU K-410", 879.99000000000001, 7 },
                    { 34, "Case X-14", 100.98999999999999, 4 },
                    { 35, "Case X-26", 129.99000000000001, 20 },
                    { 36, "DDR10 350GB", 129.99000000000001, 68 },
                    { 37, "DDR12 200GB", 159.99000000000001, 50 },
                    { 38, "SSD 400TB", 199.99000000000001, 12 },
                    { 39, "RTX-6090Ti 100GB", 799.99000000000001, 12 },
                    { 40, "P-S 2500 Wat", 159.99000000000001, 46 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Price", "ProductName", "Quantity" },
                values: new object[,]
                {
                    { 1, 2199.0, "Custom PC-CR1000", 1 },
                    { 2, 2299.0, "Custom PC-CR2000", 1 },
                    { 3, 2599.0, "Custom PC-CR3000", 1 },
                    { 4, 2699.0, "Custom PC-CR4000", 1 },
                    { 5, 2799.0, "Custom PC-CR5000", 1 },
                    { 6, 2299.0, "Custom PC-CR6000", 1 }
                });

            migrationBuilder.InsertData(
                table: "ProductInventories",
                columns: new[] { "InventoryId", "ProductId", "InventoryQuantity" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 1 },
                    { 11, 1, 1 },
                    { 16, 1, 1 },
                    { 18, 1, 1 },
                    { 28, 1, 1 },
                    { 40, 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTransactions_InventoryId",
                table: "InventoryTransactions",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInventories_InventoryId",
                table: "ProductInventories",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTransactions_ProductId",
                table: "ProductTransactions",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryTransactions");

            migrationBuilder.DropTable(
                name: "ProductInventories");

            migrationBuilder.DropTable(
                name: "ProductTransactions");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
