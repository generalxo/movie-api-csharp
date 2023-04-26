using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movie_system_csharp.Models
{
    public class MovieGenreModel
    {
        //Primary Key
        [Key]
        public int Id { get; set; }

        //Foregin Key
        [Required]
        [ForeignKey("Movies")]
        public int MovieId { get; set; }
        public virtual MovieModel Movies { get; set; }

        [Required]
        [ForeignKey("Genres")]
        public int GenreId { get; set; }
        public virtual GenreModel Genres { get; set; }

    }
}
