using System.ComponentModel.DataAnnotations;
namespace movie_system_csharp.Models
{
    public class UserModel
    {
        //Primary Key
        [Key]
        public int Id { get; set; }

        //Entity
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }

        //Navigation Properties

        public IEnumerable<MovieRatingModel> MovieRatings { get; set; }
        public IEnumerable<LikedGenreModel> LikedGenres { get; set; }
        public IEnumerable<MovieModel> Movies { get; set; }

    }
}
