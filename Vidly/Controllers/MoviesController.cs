using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private VidlyContext _context;

        public MoviesController(VidlyContext context)
        {
            _context = context;
        }

        //public IActionResult Random()
        //{
        //    var movie = new Movie() { Id = 1, Name = "Shrek!" };
        //    var customers = new List<Customer>
        //    {
        //        new() { Id = 1, Name= "Customer 1" },
        //        new() { Id = 2, Name= "Customer 2" }
        //    };
        //    var viewModel = new RandomMovieViewModel
        //    {
        //        Movie = movie,
        //        Customers = customers
        //    };

        //    return View(viewModel);
        //}

        [Route("movies/released/{year:regex(\\d{{4}})}/{month:range(1, 12)}")]
        public IActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public IActionResult Index()
        {
            return View(_context.Movies.Include(m => m.Genre));
        }

        [Route("movies/details/{id:int}")]
        public IActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre)
                .SingleOrDefault(m => m.Id == id);

            return View(movie);
        }
    }
}
