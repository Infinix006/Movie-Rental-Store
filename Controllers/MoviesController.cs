using Movie_Rental_Store.Data;
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
        ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult MovieForm()
        {
            MoviesFormViewModel viewModel = new MoviesFormViewModel()
            {
                Genre = _context.Genres.ToList()
            };
            return View(viewModel);
        }

        // GET: Movies
        public ActionResult Index()
        {
            var movie = _context.Movies.Include(c => c.Genres).ToList();
            
            return View(movie);
        }

        public ActionResult Detail(int id)
        {
            var movie = _context.Movies.Include(m => m.Genres).FirstOrDefault(m => m.Id == id);

            if (movie == null) { return HttpNotFound(); }

            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(MoviesFormViewModel ViewModel)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MoviesFormViewModel()
                {
                    Movie = ViewModel.Movie,
                    Genre = _context.Genres.ToList()
                };
                return View("MovieForm",viewModel);
            }
            if (ViewModel.Movie.Id == 0)
            {
                _context.Movies.Add(ViewModel.Movie);
            }
            else
            {
                var MoviesInDB = _context.Movies.SingleOrDefault(m => m.Id == ViewModel.Movie.Id);

                MoviesInDB.Name = ViewModel.Movie.Name;
                MoviesInDB.ReleaseDate = ViewModel.Movie.ReleaseDate;
                MoviesInDB.GenreId = ViewModel.Movie.GenreId;
                MoviesInDB.NoInStock = ViewModel.Movie.NoInStock;
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            var movies = _context.Movies.FirstOrDefault(m=> m.Id == id);

            MoviesFormViewModel moviesFormViewModel = new MoviesFormViewModel()
            {
                Movie = movies,
                Genre = _context.Genres.ToList()
            };
            return View("MovieForm", moviesFormViewModel);
        }

    }
}