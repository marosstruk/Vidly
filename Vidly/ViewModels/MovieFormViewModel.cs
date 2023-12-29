using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public string? Action { get; set; }

        public int Id { get; set; }

        public string? Name { get; set; }

        [Display(Name = "Release Date")]
        public DateOnly? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        public int NumberInStock { get; set; }

        [Display(Name = "Genre")]
        public short GenreId { get; set; }

        public IEnumerable<Genre>? Genres { get; set; }
    }
}
