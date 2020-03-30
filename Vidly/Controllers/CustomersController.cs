﻿using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;


namespace Vidly.Controllers
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

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                customer = new Customer(),
                membershipTypes = membershipTypes

            };
            return View("CustomersForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {

                var viewModel = new CustomerFormViewModel
                {
                    customer = customer,
                    membershipTypes = _context.MembershipTypes.ToList()

                };
                return View("CustomersForm", viewModel);

            }
            if (customer.Id == 0)
                _context.Customers.Add(customer);

            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);


                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscrubedToNewsletter = customer.IsSubscrubedToNewsletter;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }
        public ActionResult Index()
        {


            return View();




        }
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)

                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                customer = customer,
                membershipTypes = _context.MembershipTypes.ToList()

            };
            return View("CustomersForm", viewModel);

        }

    }
}

