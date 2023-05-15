using Microsoft.EntityFrameworkCore;
using movie_system_csharp.Models;

namespace movie_restful_api_csharp.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Database tables
        public DbSet<UserModel> Users { get; set; }
        public DbSet<GenreModel> Genres { get; set; }
        public DbSet<LikedGenreModel> LikedGenres { get; set; }
        public DbSet<MovieModel> Moveis { get; set; }
        public DbSet<MovieGenreModel> MovieGenres { get; set; }

        // Database connection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Connection string
            //Edit the Data Source to your own SQL Server
            optionsBuilder.UseSqlServer("Data Source=CHANGE_ME; Initial Catalog=DevMovieDb;Integrated Security=true");
        }

        // Database seeding
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Mapping Foreign Keys

            //LikedGenreModel Users
            modelBuilder.Entity<LikedGenreModel>()
                .HasOne(x => x.Users)
                .WithMany(x => x.LikedGenres)
                .HasForeignKey(x => x.UserId);
            modelBuilder.Entity<LikedGenreModel>()
                .HasOne(x => x.Genres)
                .WithMany(x => x.LikedGenres)
                .HasForeignKey(x => x.GenreId);

            //MovieModel Movies
            modelBuilder.Entity<MovieModel>()
                .HasOne(y => y.Users)
                .WithMany(y => y.Movies)
                .HasForeignKey(y => y.UserId);

            //MovieGenreModel MovieGenres
            modelBuilder.Entity<MovieGenreModel>()
                .HasOne(x => x.Genres)
                .WithMany(x => x.MovieGenres)
                .HasForeignKey(x => x.GenreId);
            modelBuilder.Entity<MovieGenreModel>()
                .HasOne(x => x.Movies)
                .WithMany(x => x.MovieGenres)
                .HasForeignKey(x => x.MovieId);


            //TestData Change or Remove if u want
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

            modelBuilder.Entity<UserModel>().HasData(new UserModel[]
            {
                new UserModel{Id= 1, FirstName="John", LastName="Doe", Email="Jhon@Doe.com"},
                new UserModel{Id= 2, FirstName="Elon", LastName="Tusk", Email="Elon@Tusk.com"},
                new UserModel{Id= 3, FirstName="Peter", LastName="Panda", Email="Peter@Panda.com"},
                new UserModel{Id= 4, FirstName="Sara", LastName="Smith", Email="Sara@Smith.com"},
                new UserModel{Id= 5, FirstName="Harry", LastName="Pilsner", Email="Harry@Pilsner.com"}
            });

            modelBuilder.Entity<LikedGenreModel>().HasData(new LikedGenreModel[]
            {
                new LikedGenreModel{Id= 1, UserId=1, GenreId=1},
                new LikedGenreModel{Id= 2, UserId=2, GenreId=2},
                new LikedGenreModel{Id= 3, UserId=2, GenreId=3},
                new LikedGenreModel{Id= 4, UserId=3, GenreId=4},
                new LikedGenreModel{Id= 5, UserId=3, GenreId=5},
                new LikedGenreModel{Id= 6, UserId=3, GenreId=6},
                new LikedGenreModel{Id= 7, UserId=4, GenreId=7},
                new LikedGenreModel{Id= 8, UserId=4, GenreId=8},
                new LikedGenreModel{Id= 9, UserId=4, GenreId=9},
                new LikedGenreModel{Id= 10, UserId=4, GenreId=10},
                new LikedGenreModel{Id= 11, UserId=5, GenreId=11},
                new LikedGenreModel{Id= 12, UserId=5, GenreId=12},
                new LikedGenreModel{Id= 13, UserId=5, GenreId=13},
                new LikedGenreModel{Id= 14, UserId=5, GenreId=14},
                new LikedGenreModel{Id= 15, UserId=5, GenreId=15},
            });

            modelBuilder.Entity<MovieModel>().HasData(new MovieModel[]
            {
                new MovieModel{Id= 1, Rating=10, Link=128, UserId=1},
                new MovieModel{Id= 2, Rating=5, Link=128, UserId=2},
                new MovieModel{Id= 3, Rating=7, Link=26587, UserId=2},
                new MovieModel{Id= 4, Rating=3, Link=128, UserId=3},
                new MovieModel{Id= 5, Rating=9, Link=26587, UserId=3},
                new MovieModel{Id= 6, Rating=5, Link=101, UserId=3},
                new MovieModel{Id= 7, Rating=6, Link=128, UserId=4},
                new MovieModel{Id= 8, Rating=9, Link=128, UserId=5}
            });

            modelBuilder.Entity<MovieGenreModel>().HasData(new MovieGenreModel[]
            {
                new MovieGenreModel{Id= 1, MovieId=1, GenreId=1},
                new MovieGenreModel{Id= 2, MovieId=1, GenreId=2},
                new MovieGenreModel{Id= 3, MovieId=1, GenreId=3},
                new MovieGenreModel{Id= 4, MovieId=2, GenreId=4},
                new MovieGenreModel{Id= 5, MovieId=2, GenreId=5},
                new MovieGenreModel{Id= 6, MovieId=2, GenreId=6},
                new MovieGenreModel{Id= 7, MovieId=3, GenreId=7},
                new MovieGenreModel{Id= 8, MovieId=3, GenreId=8},
                new MovieGenreModel{Id= 9, MovieId=3, GenreId=9},
                new MovieGenreModel{Id= 10, MovieId=4, GenreId=10},
                new MovieGenreModel{Id= 11, MovieId=4, GenreId=11},
                new MovieGenreModel{Id= 12, MovieId=4, GenreId=12},
                new MovieGenreModel{Id= 13, MovieId=5, GenreId=13},
                new MovieGenreModel{Id= 14, MovieId=5, GenreId=14},
                new MovieGenreModel{Id= 15, MovieId=5, GenreId=15},
            });

        }

    }
}
