using ASP_MVC4.Models;
using ASP_MVC4.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ASP_MVC4.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(p => p.MembershipType).ToList();
            var customersViewModel = new CustomerViewModel()
            {
                Customers = customers
            };
            return View(customersViewModel);
        }

        //customer/details/id
        [Route("customers/details/{id}")]
        public ActionResult Details(int? id)
        {
            var customer = _context.Customers.Include(p => p.MembershipType).SingleOrDefault(p => p.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }
    }
}