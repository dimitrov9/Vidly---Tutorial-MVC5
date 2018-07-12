using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly___Tutorial_MVC5.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required,MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        public byte NumberInStock { get; set; }

        [ForeignKey(nameof(Genre)),Required]
        public byte GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}