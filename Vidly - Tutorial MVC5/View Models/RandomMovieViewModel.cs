using System.Collections.Generic;
using Vidly___Tutorial_MVC5.Models;

namespace Vidly___Tutorial_MVC5.View_Models
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}