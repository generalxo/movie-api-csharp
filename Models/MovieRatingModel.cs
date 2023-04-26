using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movie_system_csharp.Models
{
    public class MovieRatingModel
    {
        //Primary Key
        [Key]
        public int Id { get; set; }

        public int Rating { get; set; }
        [Required]
        [ForeignKey("Movies")]
        public int MovieId { get; set; }
        [Required]
        [ForeignKey("Users")]
        public int UserId { get; set; }

        //Navigation properties
        public virtual MovieModel Movies { get; set; }
        public virtual UserModel Users { get; set; }

    }
}
