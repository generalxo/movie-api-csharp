using System.ComponentModel.DataAnnotations;
namespace movie_system_csharp.Models
{
    public class UserModel
    {
        //Primary Key
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Email { get; set; }

        //Navigation properties
        //public List<LikedGenreModel> LikedGenres { get; set; }
        //public List<MovieModel> Movies { get; set; }
        //public List<MovieRatingModel> MovieRatings { get; set; }
    }
}
