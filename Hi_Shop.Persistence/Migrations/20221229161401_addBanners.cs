using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hi_Shop.Persistence.Migrations
{
    public partial class addBanners : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 29, 19, 44, 1, 124, DateTimeKind.Local).AddTicks(4951),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 27, 14, 4, 10, 593, DateTimeKind.Local).AddTicks(5521));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 29, 19, 44, 1, 123, DateTimeKind.Local).AddTicks(9200),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 27, 14, 4, 10, 593, DateTimeKind.Local).AddTicks(1274));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 29, 19, 44, 1, 123, DateTimeKind.Local).AddTicks(570),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 27, 14, 4, 10, 592, DateTimeKind.Local).AddTicks(2510));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 29, 19, 44, 1, 125, DateTimeKind.Local).AddTicks(5980),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 27, 14, 4, 10, 593, DateTimeKind.Local).AddTicks(9136));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 29, 19, 44, 1, 121, DateTimeKind.Local).AddTicks(4902),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 27, 14, 4, 10, 591, DateTimeKind.Local).AddTicks(3014));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 29, 19, 44, 1, 118, DateTimeKind.Local).AddTicks(9148),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 27, 14, 4, 10, 590, DateTimeKind.Local).AddTicks(6060));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 29, 19, 44, 1, 116, DateTimeKind.Local).AddTicks(3164),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 27, 14, 4, 10, 587, DateTimeKind.Local).AddTicks(8714));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 29, 19, 44, 1, 118, DateTimeKind.Local).AddTicks(4687),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 27, 14, 4, 10, 589, DateTimeKind.Local).AddTicks(9248));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 29, 19, 44, 1, 118, DateTimeKind.Local).AddTicks(360),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 27, 14, 4, 10, 589, DateTimeKind.Local).AddTicks(4401));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFavourites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 29, 19, 44, 1, 117, DateTimeKind.Local).AddTicks(6627),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 27, 14, 4, 10, 589, DateTimeKind.Local).AddTicks(133));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 29, 19, 44, 1, 115, DateTimeKind.Local).AddTicks(7888),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 27, 14, 4, 10, 587, DateTimeKind.Local).AddTicks(2179));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 29, 19, 44, 1, 114, DateTimeKind.Local).AddTicks(7857),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 27, 14, 4, 10, 585, DateTimeKind.Local).AddTicks(1499));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 29, 19, 44, 1, 115, DateTimeKind.Local).AddTicks(3391),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 27, 14, 4, 10, 586, DateTimeKind.Local).AddTicks(5996));

            migrationBuilder.CreateTable(
                name: "Banners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banners", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banners");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 27, 14, 4, 10, 593, DateTimeKind.Local).AddTicks(5521),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 29, 19, 44, 1, 124, DateTimeKind.Local).AddTicks(4951));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 27, 14, 4, 10, 593, DateTimeKind.Local).AddTicks(1274),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 29, 19, 44, 1, 123, DateTimeKind.Local).AddTicks(9200));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 27, 14, 4, 10, 592, DateTimeKind.Local).AddTicks(2510),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 29, 19, 44, 1, 123, DateTimeKind.Local).AddTicks(570));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 27, 14, 4, 10, 593, DateTimeKind.Local).AddTicks(9136),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 29, 19, 44, 1, 125, DateTimeKind.Local).AddTicks(5980));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 27, 14, 4, 10, 591, DateTimeKind.Local).AddTicks(3014),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 29, 19, 44, 1, 121, DateTimeKind.Local).AddTicks(4902));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 27, 14, 4, 10, 590, DateTimeKind.Local).AddTicks(6060),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 29, 19, 44, 1, 118, DateTimeKind.Local).AddTicks(9148));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 27, 14, 4, 10, 587, DateTimeKind.Local).AddTicks(8714),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 29, 19, 44, 1, 116, DateTimeKind.Local).AddTicks(3164));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 27, 14, 4, 10, 589, DateTimeKind.Local).AddTicks(9248),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 29, 19, 44, 1, 118, DateTimeKind.Local).AddTicks(4687));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 27, 14, 4, 10, 589, DateTimeKind.Local).AddTicks(4401),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 29, 19, 44, 1, 118, DateTimeKind.Local).AddTicks(360));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFavourites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 27, 14, 4, 10, 589, DateTimeKind.Local).AddTicks(133),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 29, 19, 44, 1, 117, DateTimeKind.Local).AddTicks(6627));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 27, 14, 4, 10, 587, DateTimeKind.Local).AddTicks(2179),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 29, 19, 44, 1, 115, DateTimeKind.Local).AddTicks(7888));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 27, 14, 4, 10, 585, DateTimeKind.Local).AddTicks(1499),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 29, 19, 44, 1, 114, DateTimeKind.Local).AddTicks(7857));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 27, 14, 4, 10, 586, DateTimeKind.Local).AddTicks(5996),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 29, 19, 44, 1, 115, DateTimeKind.Local).AddTicks(3391));
        }
    }
}
