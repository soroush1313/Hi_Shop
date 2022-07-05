using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hi_Shop.Persistence.Migrations
{
    public partial class Order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 13, 10, 27, 41, 516, DateTimeKind.Local).AddTicks(452),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 8, 15, 35, 29, 891, DateTimeKind.Local).AddTicks(766));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 13, 10, 27, 41, 515, DateTimeKind.Local).AddTicks(8228),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 8, 15, 35, 29, 890, DateTimeKind.Local).AddTicks(8691));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 13, 10, 27, 41, 515, DateTimeKind.Local).AddTicks(776),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 8, 15, 35, 29, 890, DateTimeKind.Local).AddTicks(1940));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 13, 10, 27, 41, 515, DateTimeKind.Local).AddTicks(6178),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 8, 15, 35, 29, 890, DateTimeKind.Local).AddTicks(6677));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 13, 10, 27, 41, 515, DateTimeKind.Local).AddTicks(3892),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 8, 15, 35, 29, 890, DateTimeKind.Local).AddTicks(4819));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 13, 10, 27, 41, 514, DateTimeKind.Local).AddTicks(8624),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 8, 15, 35, 29, 889, DateTimeKind.Local).AddTicks(9814));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 13, 10, 27, 41, 514, DateTimeKind.Local).AddTicks(4479),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 8, 15, 35, 29, 889, DateTimeKind.Local).AddTicks(5665));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 13, 10, 27, 41, 514, DateTimeKind.Local).AddTicks(6566),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 8, 15, 35, 29, 889, DateTimeKind.Local).AddTicks(7702));

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address_State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_PostalAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_ReciverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatalogItemId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureUri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<int>(type: "int", nullable: false),
                    Units = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 8, 15, 35, 29, 891, DateTimeKind.Local).AddTicks(766),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 13, 10, 27, 41, 516, DateTimeKind.Local).AddTicks(452));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 8, 15, 35, 29, 890, DateTimeKind.Local).AddTicks(8691),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 13, 10, 27, 41, 515, DateTimeKind.Local).AddTicks(8228));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 8, 15, 35, 29, 890, DateTimeKind.Local).AddTicks(1940),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 13, 10, 27, 41, 515, DateTimeKind.Local).AddTicks(776));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 8, 15, 35, 29, 890, DateTimeKind.Local).AddTicks(6677),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 13, 10, 27, 41, 515, DateTimeKind.Local).AddTicks(6178));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 8, 15, 35, 29, 890, DateTimeKind.Local).AddTicks(4819),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 13, 10, 27, 41, 515, DateTimeKind.Local).AddTicks(3892));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 8, 15, 35, 29, 889, DateTimeKind.Local).AddTicks(9814),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 13, 10, 27, 41, 514, DateTimeKind.Local).AddTicks(8624));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 8, 15, 35, 29, 889, DateTimeKind.Local).AddTicks(5665),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 13, 10, 27, 41, 514, DateTimeKind.Local).AddTicks(4479));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 8, 15, 35, 29, 889, DateTimeKind.Local).AddTicks(7702),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 13, 10, 27, 41, 514, DateTimeKind.Local).AddTicks(6566));
        }
    }
}
