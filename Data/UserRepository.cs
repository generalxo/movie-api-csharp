using movie_restful_api_csharp.Data.Interfaces;
using movie_system_csharp.Models;

namespace movie_restful_api_csharp.Data
{
    public class UserRepository : RepositoryBase<UserModel>, IUserRepository
    {
        public UserRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }
    }
}