using ASP_MVC4.Models;
using ASP_MVC4.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_MVC4.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = GetCustomers();

            var customerViewModel = new CustomerViewModel()
            {
                Customers = customers
            };
            
            return View(customerViewModel);
        }

        //customer/details/id
        [Route("customers/details/{id}")]
        public ActionResult Details(int? id)
        {
            var customers = GetCustomers();
            if(id.HasValue)
            {
                foreach (var customer in customers)
                {
                    if (customer.Id == id)
                        return View(customer);
                }
            }
            return HttpNotFound();
        }
        private List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();

            customers.AddRange(new Customer[]
                {
                    new Customer {Id = 1, Name = "Josh Smith"},
                    new Customer {Id = 2, Name = "Marry Williams"}
                });
            return customers;
        }
    }
}