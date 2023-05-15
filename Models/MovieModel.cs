using System.ComponentModel.DataAnnotations;

namespace movie_system_csharp.Models
{
    public class MovieModel
    {
        //Primary Key
        [Key]
        public int Id { get; set; }

        //Entity
        [Required]
        public int Link { get; set; }
        public int Rating { get; set; }

        //Foregin Key
        [Required]
        public int UserId { get; set; }

        //Navigation properties
        public virtual UserModel Users { get; set; }
        public IEnumerable<MovieGenreModel> MovieGenres { get; set; }
    }
}
