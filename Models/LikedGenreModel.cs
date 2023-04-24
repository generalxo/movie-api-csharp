using System.ComponentModel.DataAnnotations;

namespace movie_system_csharp.Models
{
    public class LikedGenreModel
    {
        //Primary Key
        [Key]
        public int Id { get; set; }
        //Foregin Key
        public int? UserId { get; set; }
        public int? GenreId { get; set; }

        //Navigation properties
        public virtual UserModel Users { get; set; }
        public virtual GenreModel Genres { get; set; }

    }
}
