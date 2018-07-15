using System;
using System.Linq;
using System.Web.Http;
using Vidly___Tutorial_MVC5.Dtos;
using Vidly___Tutorial_MVC5.Models;

namespace Vidly___Tutorial_MVC5.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalsDto newRentalsDto)
        {
            // To have all this conditions is a defensive approach and it's usually used for public APIs
            // For internal APIs is recomended to use the optimistic approach 
            // For optimistic remove validation for customerId and movieIds, but leave avaliability check to maintain the logic
            if (newRentalsDto == null || !newRentalsDto.MovieIds.Any())
                return BadRequest("No MovieIds have been given.");

            var customer = _context.Customers.SingleOrDefault(x => x.Id == newRentalsDto.CustomerId);

            if (customer == null)
                return BadRequest("CustomerId is not valid.");

            var movies = _context.Movies.Where(x => newRentalsDto.MovieIds.Contains(x.Id)).ToList();

            if (movies.Count != newRentalsDto.MovieIds.Count)
                return BadRequest("One or more movieIds are invalid.");

            foreach (var movie in movies)
            {
                if (movie.NumberAvaliable == 0)
                    return BadRequest($"Movie with id {movie.Id} is not avaliable");

                movie.NumberAvaliable--;

                _context.Rentals.Add(new Rental()
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                });

            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
