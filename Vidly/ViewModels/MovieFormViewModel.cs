using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel : FormViewModel<Movie>
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        [Display(Name = "Release Date")]
        public DateOnly? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        public int NumberInStock { get; set; }

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
