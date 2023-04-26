using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movie_system_csharp.Models
{
    public class MovieModel
    {
        //Primary Key
        [Key]
        public int Id { get; set; }

        public int Link { get; set; }

        //Foregin Key
        [Required]
        [ForeignKey("Users")]
        public int UserId { get; set; }

        //Navigation properties
        public virtual UserModel Users { get; set; }
    }
}
