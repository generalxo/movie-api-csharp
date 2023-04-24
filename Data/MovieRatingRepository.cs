using movie_restful_api_csharp.Data.Interfaces;
using movie_system_csharp.Models;

namespace movie_restful_api_csharp.Data
{
    public class MovieRatingRepository : RepositoryBase<MovieRatingModel>, IMovieRatingRepository
    {
        public MovieRatingRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }
    }
}
