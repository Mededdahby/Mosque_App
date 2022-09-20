using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MuslimApp.Data.Migrations
{
    public partial class donationstables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donation_mosques_mosqueId",
                table: "Donation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Donation",
                table: "Donation");

            migrationBuilder.RenameTable(
                name: "Donation",
                newName: "donations");

            migrationBuilder.RenameIndex(
                name: "IX_Donation_mosqueId",
                table: "donations",
                newName: "IX_donations_mosqueId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_donations",
                table: "donations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_donations_mosques_mosqueId",
                table: "donations",
                column: "mosqueId",
                principalTable: "mosques",
                principalColumn: "mosqueId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_donations_mosques_mosqueId",
                table: "donations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_donations",
                table: "donations");

            migrationBuilder.RenameTable(
                name: "donations",
                newName: "Donation");

            migrationBuilder.RenameIndex(
                name: "IX_donations_mosqueId",
                table: "Donation",
                newName: "IX_Donation_mosqueId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Donation",
                table: "Donation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Donation_mosques_mosqueId",
                table: "Donation",
                column: "mosqueId",
                principalTable: "mosques",
                principalColumn: "mosqueId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
