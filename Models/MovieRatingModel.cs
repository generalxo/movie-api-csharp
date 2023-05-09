using System.ComponentModel.DataAnnotations;

namespace movie_system_csharp.Models
{
    public class MovieRatingModel
    {
        //Primary Key
        [Key]
        public int Id { get; set; }

        //Entity
        public int Rating { get; set; }

        //Foreign Keys
        [Required]
        public int MovieId { get; set; }
        [Required]
        public int UserId { get; set; }

        //Navigation properties
        public virtual MovieModel Movies { get; set; }
        public virtual UserModel Users { get; set; }

    }
}
