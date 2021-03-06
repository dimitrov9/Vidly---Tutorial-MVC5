﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Vidly___Tutorial_MVC5.Models;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Caching;
using Vidly___Tutorial_MVC5.View_Models;

namespace Vidly___Tutorial_MVC5.Controllers
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

        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");

            return View("ReadOnlyList");
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(x => x.Genre).SingleOrDefault(x => x.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genresName = nameof(_context.Genres);

            if (MemoryCache.Default[genresName] == null)
            {
                MemoryCache.Default[genresName] = _context.Genres.ToList();
            }

            var genres = MemoryCache.Default[genresName] as IEnumerable<Genre>;

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            ViewBag.Title = "New Movie";

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                movie.NumberAvaliable = movie.NumberInStock;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(x => x.Id == movie.Id);

                movieInDb.GenreId = movie.GenreId;
                movieInDb.Name = movie.Name;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == id);

            if (movie == null)
                return HttpNotFound();

            var genresName = nameof(_context.Genres);

            if (MemoryCache.Default[genresName] == null)
            {
                MemoryCache.Default[genresName] = _context.Genres.ToList();
            }

            var genres = MemoryCache.Default[genresName] as IEnumerable<Genre>;

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = genres
            };
            ViewBag.Title = "Edit Movie";
            return View("MovieForm", viewModel);
        }
    }
}