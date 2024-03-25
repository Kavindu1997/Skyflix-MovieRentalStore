using Microsoft.AspNetCore.Mvc;
using SkyFlix.Models;

namespace SkyFlix.Controllers
{
    public class CustomersController : Controller
    {
        public ViewResult Index()
        {
            var customers = GetCustomers();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

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