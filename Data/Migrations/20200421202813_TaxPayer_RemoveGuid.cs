using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class TaxPayer_RemoveGuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UniqueNumber",
                table: "TaxPayers");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "TaxPayers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "TaxPayers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "TaxReturnPolicy" },
                values: new object[] { 1, "Macedonia", 0.14999999999999999 });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "TaxReturnPolicy" },
                values: new object[] { 2, "USA", 0.050000000000000003 });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "TaxReturnPolicy" },
                values: new object[] { 3, "Great Britain", 0.0050000000000000001 });

            migrationBuilder.InsertData(
                table: "TaxPayers",
                columns: new[] { "Id", "CountryId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, 1, "Petar", "Petrevski" },
                    { 2, 1, "Igor", "Igorovski" },
                    { 3, 1, "Kire", "Kocev" },
                    { 4, 1, "ALeksandar", "Aleksandrovski" },
                    { 5, 2, "Franklin", "Short" },
                    { 6, 2, "George", "Wilkerson" },
                    { 7, 2, "Kyle", "McBride" },
                    { 8, 2, "Joseph", "Hudkins" },
                    { 9, 3, "Ben", "Duncan" },
                    { 10, 3, "Anthony", "Marshall" },
                    { 11, 3, "Jordan", "Murray" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TaxPayers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TaxPayers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TaxPayers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TaxPayers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TaxPayers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TaxPayers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TaxPayers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TaxPayers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TaxPayers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TaxPayers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TaxPayers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "TaxPayers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "TaxPayers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UniqueNumber",
                table: "TaxPayers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
