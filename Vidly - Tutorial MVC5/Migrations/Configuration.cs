using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Vidly___Tutorial_MVC5.Models;

namespace Vidly___Tutorial_MVC5.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            if (!context.Customers.Any())
            {
                context.Customers.AddRange(new List<Customer>()
                {
                    new Customer()
                    {
                        Name = "John Smith",
                        Birthdate = new DateTime(1995, 09, 23),
                        IsSubscribedToNewsletter = true,
                        MembershipTypeId = 1
                    },
                    new Customer() {Name = "Mary Williams", IsSubscribedToNewsletter = false, MembershipTypeId = 2}
                });
            }


            if (!context.Genres.Any())
            {
                context.Genres.AddRange(new List<Genre>()
                {
                    new Genre() {Name = "Comedy"},
                    new Genre() {Name = "Action"},
                    new Genre() {Name = "Family"},
                    new Genre() {Name = "Romance"},
                });
            }

            if (!context.Movies.Any())
            {
                context.Movies.AddRange(new List<Movie>()
                {
                    new Movie(){Name = "Hangover",DateAdded = DateTime.Now,ReleaseDate = new DateTime(2009,06,02),NumberInStock = 5,GenreId = 1},
                    new Movie(){Name = "Die Hard",DateAdded = DateTime.Now,ReleaseDate = new DateTime(1988,07,12),NumberInStock = 3,GenreId = 2},
                    new Movie(){Name = "The Terminator",DateAdded = DateTime.Now,ReleaseDate = new DateTime(1984,10,26),NumberInStock = 5,GenreId = 2},
                    new Movie(){Name = "Toy Story",DateAdded = DateTime.Now,ReleaseDate = new DateTime(1995,11,19),NumberInStock = 5,GenreId = 3},
                    new Movie(){Name = "Titanic",DateAdded = DateTime.Now,ReleaseDate = new DateTime(1997,11,18),NumberInStock = 5,GenreId = 4},
                });
            }
        }
    }
}
