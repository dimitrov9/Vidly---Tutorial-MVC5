using System.Collections.Generic;
using Vidly___Tutorial_MVC5.Models;

namespace Vidly___Tutorial_MVC5.View_Models
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
    }
}