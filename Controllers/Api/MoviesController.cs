using Movie_Rental_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Movie_Rental_Store.Controllers.Api
{
    public class MoviesController : ApiController
    {
        
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        //GET /Api/Movies
        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.ToList();
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        //GET /Api/Movies/1
        public IHttpActionResult GetMovies(int id)
        {
            var movie = _context.Movies.Single(x => x.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(movie);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        //POST /Api/Movies
        [HttpPost]
        public IHttpActionResult CreateMovies(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _context.Movies.Add(movie);
            _context.SaveChanges();
            return Created(Request.RequestUri + "/" + movie.Id, movie);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        //PUT /Api/Movies/1
        [HttpPut]
        public IHttpActionResult UpdateMovies(int id, Movie movie)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var moviesInDb = _context.Movies.Single(m => m.Id == id);

            if (moviesInDb == null)
                return NotFound();

            moviesInDb.Name = movie.Name;
            moviesInDb.GenreId = movie.GenreId;
            moviesInDb.ReleaseDate = movie.ReleaseDate;
            moviesInDb.NoInStock = movie.NoInStock;

            _context.SaveChanges();

            return Ok(moviesInDb);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        //DELETE /Api/Movies/1
        [HttpDelete]
        public IHttpActionResult DeleteMovies(int id)
        {
            var movieInDb = _context.Movies.Single(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok(movieInDb);
        }
        
    }
}
