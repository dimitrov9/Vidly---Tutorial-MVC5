using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly___Tutorial_MVC5.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }


        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

        [Range(1, 20)]
        public byte NumberInStock { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public GenreDto Genre { get; set; }

    }
}