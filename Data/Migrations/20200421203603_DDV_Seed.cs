using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class DDV_Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DDVs",
                columns: new[] { "Id", "Tax" },
                values: new object[] { 1, 0.0 });

            migrationBuilder.InsertData(
                table: "DDVs",
                columns: new[] { "Id", "Tax" },
                values: new object[] { 2, 0.050000000000000003 });

            migrationBuilder.InsertData(
                table: "DDVs",
                columns: new[] { "Id", "Tax" },
                values: new object[] { 3, 0.17999999999999999 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DDVs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DDVs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DDVs",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
