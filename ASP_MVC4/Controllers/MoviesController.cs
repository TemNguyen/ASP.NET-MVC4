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
        public ActionResult Edit(int id)
        {
            return Content("id: " + id);
        }
        //movie
        public ActionResult Index(int? pageIndex, string SortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(SortBy))
                SortBy = "Name";
            return Content(String.Format("pageIndex = " + pageIndex + "&sortBy = " + SortBy));
        }
        public ActionResult DisplayAllMovies()
        {
            var movies = _context.Movies.Include(p => p.Genre).ToList();
            var moviesViewModel = new MovieViewModel()
            {
                Movies = movies
            };
            return View(moviesViewModel);
        }
        [Route("movies/details/{id}")]
        public ActionResult Details(int? id)
        {
            var movie = _context.Movies.Include(p => p.Genre).SingleOrDefault(p => p.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }
        public List<Movie> GetMovies()
        {
            return new List<Movie>()
            {
                new Movie {Id = 1, Name = "Wall-e"},
                new Movie {Id = 2, Name = "Shrek!"}
            };
        }
    }
}