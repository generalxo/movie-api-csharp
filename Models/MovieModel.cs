using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movie_restful_api_csharp.Models
{
    public class MovieModel
    {
        // Primary Key
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string? Link { get; set; }

        // Foreign Key
        [ForeignKey("User")]
        public int? User_Id { get; set; }

        // Navigation properties
        public virtual UserModel User { get; set; }
    }
}
