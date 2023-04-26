using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movie_system_csharp.Models
{
    public class LikedGenreModel
    {
        //Primary Key
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public virtual UserModel Users { get; set; }

        [Required]
        [ForeignKey("Genres")]
        public int GenreId { get; set; }
        public virtual GenreModel Genres { get; set; }

    }
}
