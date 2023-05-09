using System.ComponentModel.DataAnnotations;

namespace movie_system_csharp.Models
{
    public class LikedGenreModel
    {
        //Primary Key
        [Key]
        public int Id { get; set; }

        //Foreign Keys
        [Required]
        public int UserId { get; set; }
        [Required]
        public int GenreId { get; set; }

        //Navigation Properties
        public virtual UserModel Users { get; set; }
        public virtual GenreModel Genres { get; set; }

    }
}
