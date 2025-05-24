using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinephileProject.Migrations
{
    /// <inheritdoc />
    public partial class v62 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Showtimes_ShowtimeId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ShowtimeId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ShowtimeId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "Barcode",
                table: "Tickets",
                newName: "Type");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Tickets",
                newName: "Barcode");

            migrationBuilder.AddColumn<int>(
                name: "ShowtimeId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ShowtimeId",
                table: "Tickets",
                column: "ShowtimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Showtimes_ShowtimeId",
                table: "Tickets",
                column: "ShowtimeId",
                principalTable: "Showtimes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
