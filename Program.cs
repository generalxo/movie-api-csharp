using movie_restful_api_csharp.Data;

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

            // Get all movies connected to a user

            // Get rating on a movie connected to a user

            // Get movie recomendation connected to a genre

            // Post rating on a movie connected to a user

            // Post new movie connected to a user

            // Post new movie connected to a genre



            app.Run();
        }
    }
}