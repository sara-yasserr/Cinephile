using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetterboxdProject.Migrations
{
    /// <inheritdoc />
    public partial class initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cast",
                table: "Films");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cast",
                table: "Films",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
