using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MuslimApp.Data.Migrations
{
    public partial class relationTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mosques",
                columns: table => new
                {
                    mosqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mosquePicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mosqueName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mosqueLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mosqueInformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    situation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mosques", x => x.mosqueId);
                });

            migrationBuilder.CreateTable(
                name: "members",
                columns: table => new
                {
                    memberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    memberName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<int>(type: "int", nullable: false),
                    mosqueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_members", x => x.memberID);
                    table.ForeignKey(
                        name: "FK_members_mosques_mosqueId",
                        column: x => x.mosqueId,
                        principalTable: "mosques",
                        principalColumn: "mosqueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_members_mosqueId",
                table: "members",
                column: "mosqueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "members");

            migrationBuilder.DropTable(
                name: "mosques");
        }
    }
}
