using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly___Tutorial_MVC5.Models;

namespace Vidly___Tutorial_MVC5.Controllers
{
    public class CustomersController : Controller
    {
        private IList<Customer> customers;

        public CustomersController()
        {
            this.customers = new List<Customer>()
            {
                new Customer(){Id = 1, Name = "John Smith"},
                new Customer(){Id = 2, Name = "Mary Williams"}
            };
        }

        // GET: Customers
        public ActionResult Index()
        {
            return View(customers.ToList());
        }

        public ActionResult Details(int id)
        {
            var customer = customers.FirstOrDefault(x => x.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }

}