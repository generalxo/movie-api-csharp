using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace movie_restful_api_csharp.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TmdbId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LikedGenres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikedGenres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LikedGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LikedGenres_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Moveis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Link = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moveis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moveis_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MovieGenres_Moveis_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Moveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Description", "Title", "TmdbId" },
                values: new object[,]
                {
                    { 1, "Explosions, Guns & Violence", "Action", 28 },
                    { 2, "Explore new things", "Adventure", 12 },
                    { 3, "Let ur drawings come to life", "Animation", 16 },
                    { 4, "Jokes & laughter", "Comedy", 35 },
                    { 5, "Murder mystery's & underground societys", "Crime", 80 },
                    { 6, "Learn about reality & its wonders", "Documentary", 99 },
                    { 7, "conflict, emotional, social or otherwise", "Drama", 18 },
                    { 8, "fun for the whole family", "Family", 10751 },
                    { 9, "Dragons, Elfs & Magic", "Fantasy", 14 },
                    { 10, "A look back at our history", "History", 36 },
                    { 11, "Terror, Schock & everyhing that makes u scream", "Horror", 27 },
                    { 12, "Musicals & Melody", "Music", 10402 },
                    { 13, "What where and how? lets find out", "Mystery", 9648 },
                    { 14, "a love afair", "Romance", 10749 },
                    { 15, "futuristic lands & techolegy", "Science Fiction", 878 },
                    { 16, "Ur favorit Tv show made a movie", "TV Movie", 10770 },
                    { 17, "Suspense, excitement, surprise, anticipation and anxiety", "Thriller", 53 },
                    { 18, "Warfare & battles", "War", 10752 },
                    { 19, "Cowboys, Cowgirls & Bandits", "Western", 37 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Jhon@Doe.com", "John", "Doe" },
                    { 2, "Elon@Tusk.com", "Elon", "Tusk" },
                    { 3, "Peter@Panda.com", "Peter", "Panda" },
                    { 4, "Sara@Smith.com", "Sara", "Smith" },
                    { 5, "Harry@Pilsner.com", "Harry", "Pilsner" }
                });

            migrationBuilder.InsertData(
                table: "LikedGenres",
                columns: new[] { "Id", "GenreId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 2 },
                    { 4, 4, 3 },
                    { 5, 5, 3 },
                    { 6, 6, 3 },
                    { 7, 7, 4 },
                    { 8, 8, 4 },
                    { 9, 9, 4 },
                    { 10, 10, 4 },
                    { 11, 11, 5 },
                    { 12, 12, 5 },
                    { 13, 13, 5 },
                    { 14, 14, 5 },
                    { 15, 15, 5 }
                });

            migrationBuilder.InsertData(
                table: "Moveis",
                columns: new[] { "Id", "Link", "Rating", "UserId" },
                values: new object[,]
                {
                    { 1, 128, 10, 1 },
                    { 2, 128, 5, 2 },
                    { 3, 26587, 7, 2 },
                    { 4, 128, 3, 3 },
                    { 5, 26587, 9, 3 },
                    { 6, 101, 5, 3 },
                    { 7, 128, 6, 4 },
                    { 8, 128, 9, 5 }
                });

            migrationBuilder.InsertData(
                table: "MovieGenres",
                columns: new[] { "Id", "GenreId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 4, 2 },
                    { 5, 5, 2 },
                    { 6, 6, 2 },
                    { 7, 7, 3 },
                    { 8, 8, 3 },
                    { 9, 9, 3 },
                    { 10, 10, 4 },
                    { 11, 11, 4 },
                    { 12, 12, 4 },
                    { 13, 13, 5 },
                    { 14, 14, 5 },
                    { 15, 15, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LikedGenres_GenreId",
                table: "LikedGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_LikedGenres_UserId",
                table: "LikedGenres",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Moveis_UserId",
                table: "Moveis",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenres_GenreId",
                table: "MovieGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenres_MovieId",
                table: "MovieGenres",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LikedGenres");

            migrationBuilder.DropTable(
                name: "MovieGenres");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Moveis");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
