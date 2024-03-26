using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkyFlix.Data;
using SkyFlix.Models;

namespace SkyFlix.Controllers
{
    public class CustomersController : Controller
    {
        private AppDbContext _context;

        public CustomersController(AppDbContext context)
        {
            _context = context;
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "Kavindu Samaraweera" },
                new Customer { Id = 2, Name = "Ruzbihan Zaleek" }
            };
        }
    }
}