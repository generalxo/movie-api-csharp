using System.ComponentModel.DataAnnotations;

namespace movie_system_csharp.Models
{
    public class MovieRatingModel
    {
        //Primary Key
        [Key]
        public int Id { get; set; }

        public int Rating { get; set; }

        //Foregin Key
        public int? MovieId { get; set; }
        public int? UserId { get; set; }

        //Navigation properties
        public virtual MovieModel Movies { get; set; }
        public virtual UserModel Users { get; set; }

    }
}
