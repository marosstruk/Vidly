using Microsoft.AspNetCore.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private IList<Movie> _movies =
        [
            new() { Id = 1, Name = "Shrek!" },
            new() { Id = 2, Name = "Matrix" }
        ];

        public IActionResult Random()
        {
            var movie = new Movie() { Id = 1, Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new() { Id = 1, Name= "Customer 1" },
                new() { Id = 2, Name= "Customer 2" }
            };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        [Route("movies/released/{year:regex(\\d{{4}})}/{month:range(1, 12)}")]
        public IActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public IActionResult Index()
        {
            return View(_movies);
        }
    }
}
