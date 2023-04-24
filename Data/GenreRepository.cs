using movie_restful_api_csharp.Data.Interfaces;
using movie_system_csharp.Models;

namespace movie_restful_api_csharp.Data
{
    public class GenreRepository : RepositoryBase<GenreModel>, IGenreRepository
    {
        public GenreRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }
    }
}
