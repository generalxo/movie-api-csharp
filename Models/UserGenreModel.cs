using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movie_restful_api_csharp.Models
{
    public class UserGenreModel
    {
        // Primary Key
        [Key]
        public int Id { get; set; }

        // Foregin Key
        [ForeignKey("User")]
        public int? User_Id { get; set; }
        [ForeignKey("Genre")]
        public int? Genre_Id { get; set; }

        // Navigation properties
        public virtual UserModel User { get; set; }
        public virtual GenreModel Genre { get; set; }
    }
}
