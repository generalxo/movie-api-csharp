using movie_restful_api_csharp.Data.Interfaces;
using movie_system_csharp.Models;

namespace movie_restful_api_csharp.Data
{
    public class MovieGenreRepository : RepositoryBase<MovieGenreModel>, IMovieGenreRepository
    {
        public MovieGenreRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }
    }
}
