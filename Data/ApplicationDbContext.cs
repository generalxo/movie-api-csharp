using Microsoft.EntityFrameworkCore;
using movie_restful_api_csharp.Models;

namespace movie_restful_api_csharp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserModel> User { get; set; }
        public DbSet<GenreModel> Genre { get; set; }
        public DbSet<MovieModel> Movie { get; set; }
        public DbSet<UserGenreModel> UserGener { get; set; }
        public DbSet<MovieGenreModel> MovieGenre { get; set; }
        public DbSet<MovieRatingModel> MovieRating { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-JD35EGR; Initial Catalog=DevMovieDb;Integrated Security=true");
        }

    }
}
