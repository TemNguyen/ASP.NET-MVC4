using ASP_MVC4.Models;
using ASP_MVC4.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_MVC4.Controllers
{
    public class MoviesController : Controller
    {
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
            var movies = new MovieViewModel()
            {
                Movies = GetMovies()
            };
            return View(movies);
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