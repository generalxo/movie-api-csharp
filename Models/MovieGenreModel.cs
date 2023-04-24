using System.ComponentModel.DataAnnotations;

namespace movie_system_csharp.Models
{
    public class MovieGenreModel
    {
        //Primary Key
        [Key]
        public int Id { get; set; }

        //Foregin Key
        public int? MovieId { get; set; }
        public int? GenreId { get; set; }

        //Navigation properties
        public virtual GenreModel Genres { get; set; }
        public virtual MovieModel Movies { get; set; }
    }
}
