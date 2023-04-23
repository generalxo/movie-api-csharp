using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movie_restful_api_csharp.Models
{
    public class MovieRatingModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Rating { get; set; }

        // Foregin Key
        [ForeignKey("Movie")]
        public int? Movie_Id { get; set; }
        [ForeignKey("User")]
        public int? User_Id { get; set; }

        // Navigation properties
        public virtual MovieModel Movie { get; set; }
        public virtual UserModel User { get; set; }

    }
}
