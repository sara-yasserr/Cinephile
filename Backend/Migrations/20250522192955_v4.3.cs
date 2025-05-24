using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinephileProject.Migrations
{
    /// <inheritdoc />
    public partial class v43 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenreMovie_Genres_GenresId",
                table: "GenreMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreMovie_Movies_MoviesId",
                table: "GenreMovie");

            migrationBuilder.RenameColumn(
                name: "MoviesId",
                table: "GenreMovie",
                newName: "MovieId");

            migrationBuilder.RenameColumn(
                name: "GenresId",
                table: "GenreMovie",
                newName: "GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_GenreMovie_MoviesId",
                table: "GenreMovie",
                newName: "IX_GenreMovie_MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreMovie_Genres_GenreId",
                table: "GenreMovie",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreMovie_Movies_MovieId",
                table: "GenreMovie",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenreMovie_Genres_GenreId",
                table: "GenreMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreMovie_Movies_MovieId",
                table: "GenreMovie");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "GenreMovie",
                newName: "MoviesId");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "GenreMovie",
                newName: "GenresId");

            migrationBuilder.RenameIndex(
                name: "IX_GenreMovie_MovieId",
                table: "GenreMovie",
                newName: "IX_GenreMovie_MoviesId");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreMovie_Genres_GenresId",
                table: "GenreMovie",
                column: "GenresId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreMovie_Movies_MoviesId",
                table: "GenreMovie",
                column: "MoviesId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
