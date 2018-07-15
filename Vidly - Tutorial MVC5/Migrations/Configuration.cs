using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
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
                    new Movie(){Name = "Hangover",DateAdded = DateTime.Now,ReleaseDate = new DateTime(2009,06,02),NumberInStock = 5,NumberAvaliable = 5,GenreId = 1},
                    new Movie(){Name = "Die Hard",DateAdded = DateTime.Now,ReleaseDate = new DateTime(1988,07,12),NumberInStock = 3,NumberAvaliable = 3,GenreId = 2},
                    new Movie(){Name = "The Terminator",DateAdded = DateTime.Now,ReleaseDate = new DateTime(1984,10,26),NumberInStock = 5,NumberAvaliable = 5,GenreId = 2},
                    new Movie(){Name = "Toy Story",DateAdded = DateTime.Now,ReleaseDate = new DateTime(1995,11,19),NumberInStock = 5,NumberAvaliable = 5,GenreId = 3},
                    new Movie(){Name = "Titanic",DateAdded = DateTime.Now,ReleaseDate = new DateTime(1997,11,18),NumberInStock = 5,NumberAvaliable = 5,GenreId = 4},
                });
            }

            // Seeding Roles
            if (!context.Roles.Any(r => r.Name == RoleName.CanManageMovies))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = RoleName.CanManageMovies };

                manager.Create(role);
            }

            // Seeding Users
            var password = "!Kurtasak123";
            var emailGuest = "guest@vidly.com";
            var testDrivingLicense = "TestLicense";
            var testPhone = "+389777777777";
            if (!context.Users.Any(u => u.UserName == emailGuest))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = emailGuest,
                    Email = emailGuest,
                    DrivingLicense = testDrivingLicense,
                    Phone = testPhone
                };

                manager.Create(user, password);
            }

            var emailStoreManager = "storemanager@vidly.com";
            if (!context.Users.Any(u => u.UserName == emailStoreManager))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = emailStoreManager,
                    Email = emailStoreManager,
                    DrivingLicense = testDrivingLicense,
                    Phone = testPhone
                };

                manager.Create(user, password);
                manager.AddToRole(user.Id, RoleName.CanManageMovies);
            }
        }
    }
}
