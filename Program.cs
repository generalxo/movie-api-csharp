using movie_restful_api_csharp.Data;
using movie_system_csharp.Models;

namespace movie_restful_api_csharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            #region Get Methods
            // Get All Users
            app.MapGet("/user", (HttpContext httpContext) =>
            {
                ApplicationDbContext applicationDbContext = new();
                UserRepository userRepository = new UserRepository(applicationDbContext);

                return userRepository.GetAll();
            })
                .WithName("GetAllUsers");

            // Get all genres connected to a user
            app.MapGet("/getlikedgenre/{id}", (HttpContext httpContext, int id) =>
            {
                ApplicationDbContext applicationDbContext = new();
                LikedGenreRepository likedGenre = new LikedGenreRepository(applicationDbContext);
                UserRepository userRepository = new UserRepository(applicationDbContext);
                GenreRepository genreRepository = new GenreRepository(applicationDbContext);

                var query = likedGenre.GetByCondition(q => q.UserId == id).Join(genreRepository.GetAll(),
                likedGenre => likedGenre.GenreId,
                genre => genre.Id,
                (likedGenre, genre) => genre).ToList();

                return query;
            })
                .WithName("GetGenresByUser");

            //Get all movies by movie.user_id
            app.MapGet("/getmoviesbyuser/{id}", (HttpContext httpContext, int id) =>
            {
                ApplicationDbContext applicationDbContext = new();
                MovieRepository movieRepository = new MovieRepository(applicationDbContext);
                return movieRepository.GetByCondition(q => q.UserId == id);
            })
                .WithName("/GetMoviesByUser");

            //Get all movieRatings by movie.user_id
            app.MapGet("/getmovieratingsbyuser/{id}", (HttpContext httpContext, int id) =>
            {
                ApplicationDbContext applicationDbContext = new();
                MovieRatingRepository movieRatingRepository = new MovieRatingRepository(applicationDbContext);
                return movieRatingRepository.GetByCondition(q => q.UserId == id);
            })
                .WithName("/GetMovieRatingsByUser");

            //Discover New movies with local db id
            app.MapGet("/getmoviesbygenre/{id}", (HttpContext httpContext, int id) =>
            {
                ApplicationDbContext applicationDbContext = new();
                GenreRepository genreRepository = new GenreRepository(applicationDbContext);
                var genre = genreRepository.GetByCondition(q => q.Id == id).ToList();
                int tmdb_id = genre[0].TmdbId;

                //Edit api_key to your own key from TMDB
                var api_key = "Your api key";
                var client = new HttpClient();
                var response = client.GetAsync($"https://api.themoviedb.org/3/discover/movie?api_key={api_key}&with_genres={tmdb_id}").Result;
                var content = response.Content.ReadAsStringAsync().Result;
                return content;
            })
                .WithName("GetMoviesByGenre");

            //Discover New movies with tmbd id
            app.MapGet("getmoviesbygenre/tmdb/{id}", (HttpContext httpContext, int id) =>
            {
                //Edit api_key to your own key from TMDB
                var api_key = "Your api key";
                var client = new HttpClient();
                var response = client.GetAsync($"https://api.themoviedb.org/3/discover/movie?api_key={api_key}&with_genres={id}").Result;
                var content = response.Content.ReadAsStringAsync().Result;
                return content;
            })
                .WithName("GetMoviesByGenreTmdb");

            #endregion

            #region Post Methods
            //Post a new movierating
            app.MapPost("/postmovierating", (HttpContext httpContext, MovieRatingModel movieRatingModel) =>
            {
                ApplicationDbContext applicationDbContext = new();
                MovieRatingRepository movieRatingRepository = new MovieRatingRepository(applicationDbContext);
                movieRatingRepository.Create(movieRatingModel);
                applicationDbContext.SaveChanges();
                return movieRatingModel;
            })
                .WithName("PostMovieRating");

            //Post a new likedgenre
            app.MapPost("/postlikedgenre", (HttpContext httpContext, LikedGenreModel likedGenreModel) =>
            {
                ApplicationDbContext applicationDbContext = new();
                LikedGenreRepository likedGenreRepository = new LikedGenreRepository(applicationDbContext);
                likedGenreRepository.Create(likedGenreModel);
                applicationDbContext.SaveChanges();
                return likedGenreModel;
            })
                .WithName("PostLikedGenre");

            //Post a new movie
            app.MapPost("/postmovie", (HttpContext httpContext, MovieModel movieModel) =>
            {
                ApplicationDbContext applicationDbContext = new();
                MovieRepository movieRepository = new MovieRepository(applicationDbContext);
                movieRepository.Create(movieModel);
                applicationDbContext.SaveChanges();
                return movieModel;
            })
                .WithName("PostMovie");
            #endregion

            app.Run();

        }
    }
}