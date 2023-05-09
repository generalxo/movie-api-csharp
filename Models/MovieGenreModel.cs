using System.ComponentModel.DataAnnotations;

namespace movie_system_csharp.Models
{
    public class MovieGenreModel
    {
        //Primary Key
        [Key]
        public int Id { get; set; }

        //Foregin Key
        [Required]
        public int MovieId { get; set; }
        [Required]
        public int GenreId { get; set; }

        //Navigation Properties
        public virtual GenreModel Genres { get; set; }
        public virtual MovieModel Movies { get; set; }


    }
}
