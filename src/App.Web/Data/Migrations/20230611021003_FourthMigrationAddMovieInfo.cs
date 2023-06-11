using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class FourthMigrationAddMovieInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OriginalLanguage",
                table: "MovieLikes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Overview",
                table: "MovieLikes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PosterPath",
                table: "MovieLikes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReleaseDate",
                table: "MovieLikes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "MovieLikes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "VoteAverage",
                table: "MovieLikes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OriginalLanguage",
                table: "MovieLikes");

            migrationBuilder.DropColumn(
                name: "Overview",
                table: "MovieLikes");

            migrationBuilder.DropColumn(
                name: "PosterPath",
                table: "MovieLikes");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "MovieLikes");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "MovieLikes");

            migrationBuilder.DropColumn(
                name: "VoteAverage",
                table: "MovieLikes");
        }
    }
}
