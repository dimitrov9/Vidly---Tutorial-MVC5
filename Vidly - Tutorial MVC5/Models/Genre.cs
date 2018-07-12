using System.ComponentModel.DataAnnotations;

namespace Vidly___Tutorial_MVC5.Models
{
    public class Genre
    {
        public byte Id { get; set; }
        [Required,MaxLength(255)]
        public string Name { get; set; }
    }
}