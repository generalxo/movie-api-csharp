using Microsoft.EntityFrameworkCore;
using movie_system_csharp.Models;

namespace movie_restful_api_csharp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<GenreModel> Genres { get; set; }
        public DbSet<LikedGenreModel> LikedGenres { get; set; }
        public DbSet<MovieModel> Moveis { get; set; }
        public DbSet<MovieGenreModel> MovieGenres { get; set; }
        public DbSet<MovieRatingModel> MovieRatings { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Workstation
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-JD35EGR; Initial Catalog=DevMovieDb;Integrated Security=true");

            //Laptop
            //optionsBuilder.UseSqlServer("Data Source=PETERPANDA; Initial Catalog=DevMovieDb;Integrated Security=true");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GenreModel>().HasData(new GenreModel[] {
                new GenreModel{Id= 1,TmdbId=28,Title="Action", Description="Explosions, Guns & Violence"},
                new GenreModel{Id= 2,TmdbId=12,Title="Adventure", Description="Explore new things"},
                new GenreModel{Id= 3,TmdbId=16,Title="Animation", Description="Let ur drawings come to life"},
                new GenreModel{Id= 4,TmdbId=35,Title="Comedy", Description="Jokes & laughter"},
                new GenreModel{Id= 5,TmdbId=80,Title="Crime", Description="Murder mystery's & underground societys"},
                new GenreModel{Id= 6,TmdbId=99,Title="Documentary", Description="Learn about reality & its wonders"},
                new GenreModel{Id= 7,TmdbId=18,Title="Drama", Description="conflict, emotional, social or otherwise"},
                new GenreModel{Id= 8,TmdbId=10751,Title="Family", Description="fun for the whole family"},
                new GenreModel{Id= 9,TmdbId=14,Title="Fantasy", Description="Dragons, Elfs & Magic"},
                new GenreModel{Id= 10,TmdbId=36,Title="History", Description="A look back at our history"},
                new GenreModel{Id= 11,TmdbId=27,Title="Horror", Description="Terror, Schock & everyhing that makes u scream"},
                new GenreModel{Id= 12,TmdbId=10402,Title="Music", Description="Musicals & Melody"},
                new GenreModel{Id= 13,TmdbId=9648,Title="Mystery", Description="What where and how? lets find out"},
                new GenreModel{Id= 14,TmdbId=10749,Title="Romance", Description="a love afair"},
                new GenreModel{Id= 15,TmdbId=878,Title="Science Fiction", Description="futuristic lands & techolegy"},
                new GenreModel{Id= 16,TmdbId=10770,Title="TV Movie", Description="Ur favorit Tv show made a movie"},
                new GenreModel{Id= 17,TmdbId=53,Title="Thriller", Description="Suspense, excitement, surprise, anticipation and anxiety"},
                new GenreModel{Id= 18,TmdbId=10752,Title="War", Description="Warfare & battles"},
                new GenreModel{Id= 19,TmdbId=37,Title="Western", Description="Cowboys, Cowgirls & Bandits"}
            });
        }

    }
}
