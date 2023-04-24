using movie_restful_api_csharp.Data.Interfaces;
using movie_system_csharp.Models;

namespace movie_restful_api_csharp.Data
{
    public class LikedGenreRepository : RepositoryBase<LikedGenreModel>, ILikedGenreRepository
    {
        public LikedGenreRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }
    }
}
