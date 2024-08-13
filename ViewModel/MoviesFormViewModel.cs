using Movie_Rental_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movie_Rental_Store.ViewModel
{
    public class MoviesFormViewModel
    {
        public IEnumerable<Genre> Genre { get; set; }

        public Movie Movie { get; set; }
    }
}