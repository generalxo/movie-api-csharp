﻿using System.ComponentModel.DataAnnotations;

namespace movie_system_csharp.Models
{
    public class MovieModel
    {
        //Primary Key
        [Key]
        public int Id { get; set; }

        public int Link { get; set; }

        //Foregin Key
        public int? UserId { get; set; }

        //Navigation properties
        public virtual UserModel Users { get; set; }
        public List<MovieRatingModel> MovieRatings { get; set; }
        public List<MovieGenreModel> MovieGenres { get; set; }
    }
}
