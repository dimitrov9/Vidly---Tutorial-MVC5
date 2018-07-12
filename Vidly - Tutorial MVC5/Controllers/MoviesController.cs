using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Vidly___Tutorial_MVC5.Models;
using Vidly___Tutorial_MVC5.View_Models;

namespace Vidly___Tutorial_MVC5.Controllers
{
    public class MoviesController : Controller
    {

        public List<Movie> Movies { get; set; }

        public MoviesController()
        {
            Movies = new List<Movie>()
            {
                new Movie(1,"Shrek"),
                new Movie(2,"Wall-e")
            };
        }
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };

            var customers = new List<Customer>
            {
                new Customer() {Name = "Customer 1"},
                new Customer() {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            
            return View(viewModel);

        }

        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content($"{year}/{month}");
        }

        public ActionResult Index()
        {
            return View(Movies);
        }
    }
}