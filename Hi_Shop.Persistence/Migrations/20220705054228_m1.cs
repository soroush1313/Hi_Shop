using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hi_Shop.Persistence.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 10, 12, 27, 937, DateTimeKind.Local).AddTicks(4925),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 13, 10, 27, 41, 516, DateTimeKind.Local).AddTicks(452));

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 10, 12, 27, 936, DateTimeKind.Local).AddTicks(9676));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 10, 12, 27, 937, DateTimeKind.Local).AddTicks(2621));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "OrderItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 10, 12, 27, 936, DateTimeKind.Local).AddTicks(6521),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 13, 10, 27, 41, 515, DateTimeKind.Local).AddTicks(8228));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 10, 12, 27, 935, DateTimeKind.Local).AddTicks(7583),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 13, 10, 27, 41, 515, DateTimeKind.Local).AddTicks(776));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 10, 12, 27, 936, DateTimeKind.Local).AddTicks(3852),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 13, 10, 27, 41, 515, DateTimeKind.Local).AddTicks(6178));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 10, 12, 27, 936, DateTimeKind.Local).AddTicks(1279),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 13, 10, 27, 41, 515, DateTimeKind.Local).AddTicks(3892));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 10, 12, 27, 935, DateTimeKind.Local).AddTicks(4769),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 13, 10, 27, 41, 514, DateTimeKind.Local).AddTicks(8624));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 10, 12, 27, 934, DateTimeKind.Local).AddTicks(9502),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 13, 10, 27, 41, 514, DateTimeKind.Local).AddTicks(4479));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 10, 12, 27, 935, DateTimeKind.Local).AddTicks(2023),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 13, 10, 27, 41, 514, DateTimeKind.Local).AddTicks(6566));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "OrderItems");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 13, 10, 27, 41, 516, DateTimeKind.Local).AddTicks(452),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 5, 10, 12, 27, 937, DateTimeKind.Local).AddTicks(4925));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 13, 10, 27, 41, 515, DateTimeKind.Local).AddTicks(8228),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 5, 10, 12, 27, 936, DateTimeKind.Local).AddTicks(6521));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 13, 10, 27, 41, 515, DateTimeKind.Local).AddTicks(776),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 5, 10, 12, 27, 935, DateTimeKind.Local).AddTicks(7583));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 13, 10, 27, 41, 515, DateTimeKind.Local).AddTicks(6178),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 5, 10, 12, 27, 936, DateTimeKind.Local).AddTicks(3852));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 13, 10, 27, 41, 515, DateTimeKind.Local).AddTicks(3892),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 5, 10, 12, 27, 936, DateTimeKind.Local).AddTicks(1279));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 13, 10, 27, 41, 514, DateTimeKind.Local).AddTicks(8624),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 5, 10, 12, 27, 935, DateTimeKind.Local).AddTicks(4769));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 13, 10, 27, 41, 514, DateTimeKind.Local).AddTicks(4479),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 5, 10, 12, 27, 934, DateTimeKind.Local).AddTicks(9502));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 13, 10, 27, 41, 514, DateTimeKind.Local).AddTicks(6566),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 5, 10, 12, 27, 935, DateTimeKind.Local).AddTicks(2023));
        }
    }
}
