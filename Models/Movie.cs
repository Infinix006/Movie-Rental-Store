using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace Movie_Rental_Store.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        public Genre Genres { get; set; }


        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }


        [Display(Name = "Date Added")]
        [Required]
        public DateTime DateAdded { get; set; } = DateTime.Now;

        [Display(Name = "Release Date")]
        [Required]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Required]
        [Range(1, 20)]
        public int NoInStock { get; set; } = 0;

    }
}