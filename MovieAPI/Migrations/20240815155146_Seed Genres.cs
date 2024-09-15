using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedGenres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO genres(Title) VALUES('Action'),('Drama'),('Crime'),('Biography'),('Adventure'),('Horror'),('Romance'),('Comedy'),('War'),('Fantasy'),('Historical'),('Science Fiction'),('Thriller')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM genres");
        }
    }
}
