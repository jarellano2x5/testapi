using Microsoft.EntityFrameworkCore.Migrations;

namespace testapi.Migrations
{
    public partial class quitaliga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tariff_Country",
                table: "Tariff");

            migrationBuilder.DropIndex(
                name: "IX_Tariff_IdCountry",
                table: "Tariff");

            migrationBuilder.AddColumn<short>(
                name: "CountryIdCountry",
                table: "Tariff",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tariff_CountryIdCountry",
                table: "Tariff",
                column: "CountryIdCountry");

            migrationBuilder.AddForeignKey(
                name: "FK_Tariff_Country_CountryIdCountry",
                table: "Tariff",
                column: "CountryIdCountry",
                principalTable: "Country",
                principalColumn: "IdCountry",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tariff_Country_CountryIdCountry",
                table: "Tariff");

            migrationBuilder.DropIndex(
                name: "IX_Tariff_CountryIdCountry",
                table: "Tariff");

            migrationBuilder.DropColumn(
                name: "CountryIdCountry",
                table: "Tariff");

            migrationBuilder.CreateIndex(
                name: "IX_Tariff_IdCountry",
                table: "Tariff",
                column: "IdCountry");

            migrationBuilder.AddForeignKey(
                name: "FK_Tariff_Country",
                table: "Tariff",
                column: "IdCountry",
                principalTable: "Country",
                principalColumn: "IdCountry",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
