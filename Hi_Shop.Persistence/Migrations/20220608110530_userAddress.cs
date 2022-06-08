using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hi_Shop.Persistence.Migrations
{
    public partial class userAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 8, 15, 35, 29, 890, DateTimeKind.Local).AddTicks(8691),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 11, 55, 682, DateTimeKind.Local).AddTicks(1501));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 8, 15, 35, 29, 890, DateTimeKind.Local).AddTicks(1940),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 11, 55, 681, DateTimeKind.Local).AddTicks(4854));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 8, 15, 35, 29, 890, DateTimeKind.Local).AddTicks(6677),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 11, 55, 681, DateTimeKind.Local).AddTicks(9481));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 8, 15, 35, 29, 890, DateTimeKind.Local).AddTicks(4819),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 11, 55, 681, DateTimeKind.Local).AddTicks(7658));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 8, 15, 35, 29, 889, DateTimeKind.Local).AddTicks(9814),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 11, 55, 681, DateTimeKind.Local).AddTicks(2678));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 8, 15, 35, 29, 889, DateTimeKind.Local).AddTicks(5665),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 11, 55, 680, DateTimeKind.Local).AddTicks(8201));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 8, 15, 35, 29, 889, DateTimeKind.Local).AddTicks(7702),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 6, 10, 11, 55, 681, DateTimeKind.Local).AddTicks(213));

            migrationBuilder.CreateTable(
                name: "UserAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReciverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 6, 8, 15, 35, 29, 891, DateTimeKind.Local).AddTicks(766)),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddresses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAddresses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 6, 10, 11, 55, 682, DateTimeKind.Local).AddTicks(1501),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 8, 15, 35, 29, 890, DateTimeKind.Local).AddTicks(8691));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 6, 10, 11, 55, 681, DateTimeKind.Local).AddTicks(4854),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 8, 15, 35, 29, 890, DateTimeKind.Local).AddTicks(1940));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 6, 10, 11, 55, 681, DateTimeKind.Local).AddTicks(9481),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 8, 15, 35, 29, 890, DateTimeKind.Local).AddTicks(6677));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 6, 10, 11, 55, 681, DateTimeKind.Local).AddTicks(7658),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 8, 15, 35, 29, 890, DateTimeKind.Local).AddTicks(4819));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 6, 10, 11, 55, 681, DateTimeKind.Local).AddTicks(2678),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 8, 15, 35, 29, 889, DateTimeKind.Local).AddTicks(9814));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 6, 10, 11, 55, 680, DateTimeKind.Local).AddTicks(8201),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 8, 15, 35, 29, 889, DateTimeKind.Local).AddTicks(5665));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 6, 10, 11, 55, 681, DateTimeKind.Local).AddTicks(213),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 8, 15, 35, 29, 889, DateTimeKind.Local).AddTicks(7702));
        }
    }
}
