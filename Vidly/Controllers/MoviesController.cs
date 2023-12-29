using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private VidlyContext _context;

        public MoviesController(VidlyContext context)
        {
            _context = context;
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

        public IActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Action = "New",
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel("Edit", movie, genres);

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public IActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateOnly.FromDateTime(DateTime.Now);
                _context.Movies.Add(movie);
            }
            else
            {
                _context.Movies.Update(movie);
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}
