using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel : FormViewModel<Movie>
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateOnly? ReleaseDate { get; set; }

        [Required]
        [Range(0, 1000)]
        [Display(Name = "Number in Stock")]
        public int NumberInStock { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public short GenreId { get; set; }

        public IEnumerable<Genre>? Genres { get; set; }

        public MovieFormViewModel() : base()
        {
        }

        public MovieFormViewModel(string action, Movie movie, IEnumerable<Genre> genres)
            : base(action, movie)
        {
            Genres = genres;
        }
    }
}
