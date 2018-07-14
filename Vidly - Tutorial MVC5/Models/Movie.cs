using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly___Tutorial_MVC5.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime DateAdded { get; set; }

        [Required, Range(1, 20)]
        public byte NumberInStock { get; set; }

        [ForeignKey(nameof(Genre))]
        public byte GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}