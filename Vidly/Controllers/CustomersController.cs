using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly VidlyContext _context;

        public CustomersController(VidlyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType);
            return View(customers);
        }

        [Route("customers/details/{id:int}")]
        public IActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType)
                .SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return View(customer);
        }

        public IActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Action = "New",
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        public IActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel("Edit", customer, membershipTypes);

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var action = customer.Id == 0 ? "New" : "Edit";
                var membershipTypes = _context.MembershipTypes.ToList();
                var viewModel = new CustomerFormViewModel(action, customer, membershipTypes);
                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
                _context.Customers.Update(customer);

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }
    }
}
