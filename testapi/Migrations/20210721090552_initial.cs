using Microsoft.EntityFrameworkCore.Migrations;

namespace testapi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    IdCountry = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Language = table.Column<string>(unicode: false, maxLength: 2, nullable: false),
                    Acronym = table.Column<string>(unicode: false, maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.IdCountry);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    IdStatus = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.IdStatus);
                });

            migrationBuilder.CreateTable(
                name: "Tipe",
                columns: table => new
                {
                    IdType = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipe", x => x.IdType);
                });

            migrationBuilder.CreateTable(
                name: "Tariff",
                columns: table => new
                {
                    IdTariff = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Initial = table.Column<string>(unicode: false, maxLength: 6, nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    IdCountry = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tariff", x => x.IdTariff);
                    table.ForeignKey(
                        name: "FK_Tariff_Country",
                        column: x => x.IdCountry,
                        principalTable: "Country",
                        principalColumn: "IdCountry",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shop",
                columns: table => new
                {
                    IdShop = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RFC = table.Column<string>(unicode: false, maxLength: 13, nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 300, nullable: false),
                    Alias = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Zip = table.Column<string>(unicode: false, maxLength: 5, nullable: false),
                    TagLine = table.Column<string>(unicode: false, maxLength: 150, nullable: false),
                    IdCountry = table.Column<short>(nullable: false),
                    IdType = table.Column<short>(nullable: false),
                    IdStatus = table.Column<short>(nullable: false),
                    TipeIdType = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop", x => x.IdShop);
                    table.ForeignKey(
                        name: "FK_Shop_Country",
                        column: x => x.IdCountry,
                        principalTable: "Country",
                        principalColumn: "IdCountry",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shop_Status",
                        column: x => x.IdStatus,
                        principalTable: "Status",
                        principalColumn: "IdStatus",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shop_Tipe_TipeIdType",
                        column: x => x.TipeIdType,
                        principalTable: "Tipe",
                        principalColumn: "IdType",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shop_IdCountry",
                table: "Shop",
                column: "IdCountry");

            migrationBuilder.CreateIndex(
                name: "IX_Shop_IdStatus",
                table: "Shop",
                column: "IdStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Shop_TipeIdType",
                table: "Shop",
                column: "TipeIdType");

            migrationBuilder.CreateIndex(
                name: "IX_Tariff_IdCountry",
                table: "Tariff",
                column: "IdCountry");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shop");

            migrationBuilder.DropTable(
                name: "Tariff");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Tipe");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
