using Movie_Rental_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Movie_Rental_Store.ViewModel;

namespace Movie_Rental_Store.Controllers
{
    public class CustomersController : Controller
    {
        ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var customer = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customer);
        }

        public ActionResult CustomerForm()
        {
            var MembershipType = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel()
            {
                Customers = new Customer(),
                MembershipTypes = MembershipType,
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CustomerFormViewModel ViewModel)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel()
                {
                    Customers = ViewModel.Customers,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if (ViewModel.Customers.Id == 0)
            {
                _context.Customers.Add(ViewModel.Customers);
            }
            else
            {
                var customerInDb = _context.Customers.Single(x => x.Id == ViewModel.Customers.Id);

                customerInDb.Name = ViewModel.Customers.Name;
                customerInDb.BirthDate = ViewModel.Customers.BirthDate;
                customerInDb.MembershipTypeId = ViewModel.Customers.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = ViewModel.Customers.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }


        public ActionResult Edit(int id)
        {
            var customers = _context.Customers.SingleOrDefault(e => e.Id == id);

            if (customers == null)
                return HttpNotFound();

            var ViewModel = new CustomerFormViewModel()
            {
                Customers = customers,
                MembershipTypes = _context.MembershipTypes.ToList(),

            };

            return View("CustomerForm", ViewModel);
        }
    }
}