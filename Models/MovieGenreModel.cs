using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movie_restful_api_csharp.Models
{
    public class MovieGenreModel
    {
        // Primary Key
        [Key]
        public int Id { get; set; }

        // Foregin Key
        [ForeignKey("Movie")]
        public int? Movie_Id { get; set; }
        [ForeignKey("Genre")]
        public int? Genre_Id { get; set; }

        // Navigation properties
        public virtual MovieModel Movie { get; set; }
        public virtual GenreModel Genre { get; set; }
    }
}
