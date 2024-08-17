using Movie_Rental_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Movie_Rental_Store.ViewModel;

namespace Movie_Rental_Store.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var movie = _context.Movies.Include(c => c.Genres).ToList();

            if(User.IsInRole(RoleName.CanManageMovies))
                return View("List",movie);

            return View("ReadOnlyList",movie);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult MovieForm()
        {
            MoviesFormViewModel viewModel = new MoviesFormViewModel()
            {
                Genre = _context.Genres.ToList()
            };
            return View(viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPost]
        [ValidateAntiForgeryToken]        
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MoviesFormViewModel(movie)
                {
                    Genre = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var MoviesInDB = _context.Movies.SingleOrDefault(m => m.Id == movie.Id);

                MoviesInDB.Name = movie.Name;
                MoviesInDB.ReleaseDate = movie.ReleaseDate;
                MoviesInDB.GenreId = movie.GenreId;
                MoviesInDB.NoInStock = movie.NoInStock;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movies = _context.Movies.FirstOrDefault(m => m.Id == id);

            MoviesFormViewModel moviesFormViewModel = new MoviesFormViewModel(movies)
            {
                Genre = _context.Genres.ToList()
            };
            return View("MovieForm", moviesFormViewModel);
        }
    }
}