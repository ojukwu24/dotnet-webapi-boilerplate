using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.PostgreSQL.Migrations.Application
{
    public partial class ctegory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Category_CategoryId",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_UnitOfMeasurement_UnitOfMeasurementId",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitOfMeasurement",
                schema: "Catalog",
                table: "UnitOfMeasurement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                schema: "Catalog",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "UnitOfMeasurement",
                schema: "Catalog",
                newName: "UnitOfMeasurements",
                newSchema: "Catalog");

            migrationBuilder.RenameTable(
                name: "Category",
                schema: "Catalog",
                newName: "Categories",
                newSchema: "Catalog");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitOfMeasurements",
                schema: "Catalog",
                table: "UnitOfMeasurements",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                schema: "Catalog",
                table: "Categories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Suppliers",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ContactPerson = table.Column<string>(type: "text", nullable: false),
                    ContactEmail = table.Column<string>(type: "text", nullable: false),
                    ContactPhoneNumber = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UoMConversions",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ToUoMId = table.Column<Guid>(type: "uuid", nullable: false),
                    FromUoMId = table.Column<Guid>(type: "uuid", nullable: false),
                    Multiplier = table.Column<decimal>(type: "numeric", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UoMConversions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UoMConversions_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UoMConversions_UnitOfMeasurements_FromUoMId",
                        column: x => x.FromUoMId,
                        principalSchema: "Catalog",
                        principalTable: "UnitOfMeasurements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UoMConversions_UnitOfMeasurements_ToUoMId",
                        column: x => x.ToUoMId,
                        principalSchema: "Catalog",
                        principalTable: "UnitOfMeasurements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderHeaders",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uuid", nullable: false),
                    PurchaseOrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderHeaders_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "Catalog",
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PurchaseOrderHeaderId = table.Column<Guid>(type: "uuid", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_PurchaseOrderHeaders_PurchaseOrderHeaderId",
                        column: x => x.PurchaseOrderHeaderId,
                        principalSchema: "Catalog",
                        principalTable: "PurchaseOrderHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderHeaders_SupplierId",
                schema: "Catalog",
                table: "PurchaseOrderHeaders",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_ProductId",
                schema: "Catalog",
                table: "PurchaseOrders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_PurchaseOrderHeaderId",
                schema: "Catalog",
                table: "PurchaseOrders",
                column: "PurchaseOrderHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_UoMConversions_FromUoMId",
                schema: "Catalog",
                table: "UoMConversions",
                column: "FromUoMId");

            migrationBuilder.CreateIndex(
                name: "IX_UoMConversions_ProductId",
                schema: "Catalog",
                table: "UoMConversions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UoMConversions_ToUoMId",
                schema: "Catalog",
                table: "UoMConversions",
                column: "ToUoMId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                schema: "Catalog",
                table: "Products",
                column: "CategoryId",
                principalSchema: "Catalog",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_UnitOfMeasurements_UnitOfMeasurementId",
                schema: "Catalog",
                table: "Products",
                column: "UnitOfMeasurementId",
                principalSchema: "Catalog",
                principalTable: "UnitOfMeasurements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_UnitOfMeasurements_UnitOfMeasurementId",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropTable(
                name: "PurchaseOrders",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "UoMConversions",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "PurchaseOrderHeaders",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Suppliers",
                schema: "Catalog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitOfMeasurements",
                schema: "Catalog",
                table: "UnitOfMeasurements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                schema: "Catalog",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "UnitOfMeasurements",
                schema: "Catalog",
                newName: "UnitOfMeasurement",
                newSchema: "Catalog");

            migrationBuilder.RenameTable(
                name: "Categories",
                schema: "Catalog",
                newName: "Category",
                newSchema: "Catalog");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitOfMeasurement",
                schema: "Catalog",
                table: "UnitOfMeasurement",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                schema: "Catalog",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Category_CategoryId",
                schema: "Catalog",
                table: "Products",
                column: "CategoryId",
                principalSchema: "Catalog",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_UnitOfMeasurement_UnitOfMeasurementId",
                schema: "Catalog",
                table: "Products",
                column: "UnitOfMeasurementId",
                principalSchema: "Catalog",
                principalTable: "UnitOfMeasurement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
