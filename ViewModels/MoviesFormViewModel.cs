using Movie_Rental_Store.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movie_Rental_Store.ViewModel
{
    public class MoviesFormViewModel
    {
        public IEnumerable<Genre> Genre { get; set; }

        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }


        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }


        [Display(Name = "Date Added")]
        [Required]
        public DateTime DateAdded { get; set; } = DateTime.Now;

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Required]
        [Range(1, 20)]
        public int? NoInStock { get; set; }



        public MoviesFormViewModel()
        {
            Id = 0;
        }

        public MoviesFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            GenreId = movie.GenreId;
            NoInStock = movie.NoInStock;
            ReleaseDate = movie.ReleaseDate;
            DateAdded = movie.DateAdded;
        }
    }
}