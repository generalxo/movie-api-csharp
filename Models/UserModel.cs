using System.ComponentModel.DataAnnotations;

namespace movie_restful_api_csharp.Models
{
    public class UserModel
    {
        // Primary Key
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
        [Required]
        [StringLength(100)]
        public string? Email { get; set; }

        // Navigation properties
        public List<UserGenreModel> UserGenre { get; set; }
        public List<MovieModel> Movie { get; set; }
        public List<MovieRatingModel> MovieRating { get; set; }
    }
}
