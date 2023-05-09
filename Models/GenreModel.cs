using System.ComponentModel.DataAnnotations;

namespace movie_system_csharp.Models
{
    public class GenreModel
    {
        // Primary Key
        [Key]
        public int Id { get; set; }

        [Required]
        public int TmdbId { get; set; }
        [Required]
        [StringLength(50)]
        public string? Title { get; set; }
        [Required]
        [StringLength(250)]
        public string? Description { get; set; }

        // Navigation Properties
        public IEnumerable<LikedGenreModel> LikedGenres { get; set; }
        public IEnumerable<MovieGenreModel> MovieGenres { get; set; }


    }
}
