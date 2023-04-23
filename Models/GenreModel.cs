using System.ComponentModel.DataAnnotations;

namespace movie_restful_api_csharp.Models
{
    public class GenreModel
    {
        // Primary Key
        [Key]
        public int Id { get; set; }

        public int Tmdb_Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? Title { get; set; }
        [Required]
        [StringLength(250)]
        public string? Description { get; set; }

        // Navigation properties
        public List<UserGenreModel> Genre { get; set; }
        public List<MovieGenreModel> Movie { get; set; }
    }
}
