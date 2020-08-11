using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Remove_Fiscal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_DDVs_DDVId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_FiscalReceipt_FiscalReceiptId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "FiscalReceipt");

            migrationBuilder.DropIndex(
                name: "IX_Products_FiscalReceiptId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FiscalReceiptId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "DDVId",
                table: "Products",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaxPayerId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_TaxPayerId",
                table: "Products",
                column: "TaxPayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_DDVs_DDVId",
                table: "Products",
                column: "DDVId",
                principalTable: "DDVs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_TaxPayers_TaxPayerId",
                table: "Products",
                column: "TaxPayerId",
                principalTable: "TaxPayers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_DDVs_DDVId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_TaxPayers_TaxPayerId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_TaxPayerId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TaxPayerId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "DDVId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "FiscalReceiptId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FiscalReceipt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxPayerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiscalReceipt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FiscalReceipt_TaxPayers_TaxPayerId",
                        column: x => x.TaxPayerId,
                        principalTable: "TaxPayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_FiscalReceiptId",
                table: "Products",
                column: "FiscalReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_FiscalReceipt_TaxPayerId",
                table: "FiscalReceipt",
                column: "TaxPayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_DDVs_DDVId",
                table: "Products",
                column: "DDVId",
                principalTable: "DDVs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_FiscalReceipt_FiscalReceiptId",
                table: "Products",
                column: "FiscalReceiptId",
                principalTable: "FiscalReceipt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
