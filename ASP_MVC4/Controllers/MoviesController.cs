using ASP_MVC4.Models;
using ASP_MVC4.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ASP_MVC4.Controllers
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
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie()
            {
                Id = 1,
                Name = "Shrek"
            };

            var customers = new List<Customer>
            {
                new Customer {Id = 1, Name = "Customer 1"},
                new Customer {Id = 2, Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Customers = customers,
                Movie = movie
            };
            return View(viewModel);
        }
        [Route("movies/released/{year}/{month:regex(//d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
        //public ActionResult Edit(int id)
        //{
        //    return Content("id: " + id);
        //}
        public ActionResult Index()
        {
            //var movies = _context.Movies.Include(p => p.Genre).ToList();
            //var moviesViewModel = new MovieViewModel()
            //{
            //    Movies = movies
            //};
            return View();
        }
        [Route("movies/details/{id}")]
        public ActionResult Details(int? id)
        {
            var movie = _context.Movies.Include(p => p.Genre).SingleOrDefault(p => p.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }
        public ActionResult New()
        {
            var genres = _context.Genre.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(p => p.Genre).SingleOrDefault(p => p.Id == id);
            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = _context.Genre.ToList()
            };

            return View("MovieForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid && movie.Id != 0)
            {
                var viewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    Genres = _context.Genre.ToList()
                };

                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.FirstOrDefault(p => p.Id == movie.Id);
                if (movieInDb == null)
                    return HttpNotFound();
                else
                {
                    movieInDb.Name = movie.Name;
                    movieInDb.ReleaseDate = movie.ReleaseDate;
                    movieInDb.GenreId = movie.GenreId;
                    movieInDb.NumberInStock = movie.NumberInStock;
                }
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
    }
}