using System.Web.Mvc;
using Vidly___Tutorial_MVC5.Models;

namespace Vidly___Tutorial_MVC5.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };

            return View(movie);
        }
    }
}