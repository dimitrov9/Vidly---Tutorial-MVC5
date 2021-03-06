﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Vidly___Tutorial_MVC5.Dtos;
using Vidly___Tutorial_MVC5.Models;

namespace Vidly___Tutorial_MVC5.Controllers.Api
{
    public class MoviesController : ApiController
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

        // GET /api/movies
        public IHttpActionResult GetMovies(string query = null)
        {
            var moviesQuery = _context.Movies
                .Include(x => x.Genre)
                .Where(x => x.NumberAvaliable > 0);

            if (!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(x => x.Name.Contains(query));

            var moviesDtos = moviesQuery
            .ToList()
            .Select(Mapper.Map<Movie, MovieDto>);

            return Ok(moviesDtos);
        }

        // GET /api/Movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        // POST /api/Movies
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            movie.DateAdded = DateTime.Now;

            _context.Movies.Add(movie);
            _context.SaveChanges();

            Mapper.Map(movie, movieDto);

            return Created(new Uri($"{Request.RequestUri}/{movie.Id}"), movieDto);
        }

        // PUT /api/Movies/1
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = _context.Movies.SingleOrDefault(x => x.Id == id);
            if (movie == null)
                return NotFound();

            Mapper.Map(movieDto, movie);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/Movies/1
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == id);
            if (movie == null)
                return NotFound();

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return Ok();
        }
    }
}
