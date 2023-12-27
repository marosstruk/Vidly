using Microsoft.AspNetCore.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private List<Customer> _customers =
        [
            new() { Id = 1, Name = "John Smith" },
            new() { Id = 2, Name = "Marry Williams" }
        ];

        public IActionResult Index()
        {
            return View(_customers);
        }

        [Route("customers/details/{id:int}")]
        public IActionResult Details(int id)
        {
            var customer = _customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return View(customer);
        }
    }
}
