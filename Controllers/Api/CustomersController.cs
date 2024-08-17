using Movie_Rental_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Movie_Rental_Store.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //Get Api/Customers
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        //Get Api/Customers/1 
        public IHttpActionResult GetCustomer(int id)
        {
            var customers = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customers == null)
                return NotFound();

            return Ok(customers);
        }

        //Post Api/Customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customer);
        }


        //PUT /Api/Customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, Customer customer)
        {
            if (ModelState.IsValid)
            {
                return BadRequest();
            }

            var customerInDb = _context.Customers.Single(m => m.Id == id);

            if (customerInDb == null)
                return NotFound();

            customerInDb.Name = customer.Name;
            customerInDb.BirthDate = customer.BirthDate;
            customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;

            _context.SaveChanges();

            return Ok(customerInDb);
        }

        //Delete /Api/Customers/1

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.Single(m => m.Id == id);

            if (customerInDb == null)
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok(customerInDb);
        }
    }
}
