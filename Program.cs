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

            //Post a new movierating
            app.MapPost("/postmovierating", (HttpContext httpContext, MovieRatingModel movieRatingModel) =>
            {
                ApplicationDbContext applicationDbContext = new();
                MovieRatingRepository movieRatingRepository = new MovieRatingRepository(applicationDbContext);
                movieRatingRepository.Create(movieRatingModel);
                applicationDbContext.SaveChanges();
                return movieRatingRepository;
            })
                .WithName("PostMovieRating");

            //Post a new likedgenre
            app.MapPost("/postlikedgenre", (HttpContext httpContext, LikedGenreModel likedGenreModel) =>
            {
                ApplicationDbContext applicationDbContext = new();
                LikedGenreRepository likedGenreRepository = new LikedGenreRepository(applicationDbContext);
                likedGenreRepository.Create(likedGenreModel);
                applicationDbContext.SaveChanges();
                return likedGenreRepository;
            })
                .WithName("PostLikedGenre");

            //Post a new movie
            app.MapPost("/postmovie", (HttpContext httpContext, MovieModel movieModel) =>
            {
                ApplicationDbContext applicationDbContext = new();
                MovieRepository movieRepository = new MovieRepository(applicationDbContext);
                movieRepository.Create(movieModel);
                applicationDbContext.SaveChanges();
                return movieRepository;
            })
                .WithName("PostMovie");

            // GET movies related to a genre from an external api tmdb the url should look like this : https://api.themoviedb.org/3/discover/movie?api_key=<<api_key>>&with_genres=<<id>> with httpclient
            app.MapGet("/getmoviesbygenre/{id}", (HttpContext httpContext, int id) =>
            {
                var api_key = "b5ced27703b7b4556f41ed1063214729";
                var client = new HttpClient();
                var response = client.GetAsync($"https://api.themoviedb.org/3/discover/movie?api_key={api_key}&with_genres={id}").Result;
                var content = response.Content.ReadAsStringAsync().Result;
                return content;
            })
                .WithName("GetMoviesByGenre");


            app.Run();
        }
    }
}