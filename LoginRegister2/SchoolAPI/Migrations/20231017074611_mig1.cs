using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolAPI.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bölümler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bölümler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fakülteler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FakülteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BolumId = table.Column<int>(type: "int", nullable: false),
                    BölümId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fakülteler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fakülteler_Bölümler_BölümId",
                        column: x => x.BölümId,
                        principalTable: "Bölümler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fakülteler_BölümId",
                table: "Fakülteler",
                column: "BölümId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fakülteler");

            migrationBuilder.DropTable(
                name: "Bölümler");
        }
    }
}
