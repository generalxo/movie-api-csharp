using movie_restful_api_csharp.Data;
using movie_system_csharp.Models;

namespace movie_restful_api_csharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
            {
                builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));

            builder.Services.AddScoped<ApplicationDbContext>();
            builder.Services.AddScoped<UserRepository>();
            builder.Services.AddScoped<GenreRepository>();
            builder.Services.AddScoped<LikedGenreRepository>();
            builder.Services.AddScoped<MovieRepository>();
            builder.Services.AddScoped<MovieGenreRepository>();
            builder.Services.AddScoped<MovieRatingRepository>();

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();
            app.UseCors("corsapp");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            #region Get Methods
            // Get All Users
            app.MapGet("/user", (UserRepository userRepository) =>
            {
                var query = userRepository.GetAll().AsQueryable().Select(u => new { u.Id, u.FirstName, u.LastName, u.Email });
                return query.ToList();
            })
                .WithName("GetAllUsers");

            app.MapGet("/user/{id}", (UserRepository userRepository, int id) =>
            {
                var query = userRepository.GetByCondition(q => q.Id == id).AsQueryable().Select(u => new { u.FirstName, u.LastName, u.Email });
                return query;
            })
                .WithName("GetUserById");

            // Get all genres connected to a user
            app.MapGet("/getlikedgenre/{id}", (LikedGenreRepository likedGenreRepository, UserRepository userRepository, GenreRepository genreRepository, int id) =>
            {
                var query = likedGenreRepository.GetByCondition(q => q.UserId == id).Join(genreRepository.GetAll(),
                    likedGenre => likedGenre.GenreId,
                    genre => genre.Id,
                    (likedGenre, genre) => genre).Select(g => new
                    {
                        id = g.Id,
                        tmdbId = g.TmdbId,
                        title = g.Title,
                        description = g.Description
                    })
                        .ToList();

                return query;
            })
                .WithName("GetGenresByUser");

            //Get all movies by movie.user_id
            app.MapGet("/getmoviesbyuser/{id}", (MovieRepository movieRepository, int id) =>
            {
                var query = movieRepository.GetByCondition(q => q.UserId == id).AsQueryable().Select(m => new { m.Id, m.UserId, m.Link });

                return query.ToList();
            })
                .WithName("/GetMoviesByUser");

            ////Get all movieRatings by movie.user_id
            app.MapGet("/getmovieratingsbyuser/{id}", (MovieRatingRepository movieRatingRepository, int id) =>
            {
                var query = movieRatingRepository.GetByCondition(q => q.UserId == id).AsQueryable().Select(m => new { m.Id, m.UserId, m.MovieId, m.Rating });

                return query.ToList();
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
                var api_key = "UR_API_KEY_HERE";
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
                var api_key = "UR_API_KEY_HERE";
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