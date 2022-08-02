using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shopping.DAL;
using Shopping.Models;

namespace Shopping.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerRepo _customerRepo;

        public CustomersController()
        {
            _customerRepo=new CustomerRepo(new shopContext());
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            return View(await _customerRepo.GetAllCustomers());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerRepo.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Customer_id,Customer_name,Password,age,gender,phoneNumber")] Customer customer)
        {

                _customerRepo.AddCustomer(customer);
                 await _customerRepo.Save();

                return RedirectToAction("Index");
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerRepo.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Customer_id,Customer_name,Password,age,gender,phoneNumber")] Customer customer)
        {
            if (id != customer.Customer_id)
            {
                return NotFound();
            }

          
                    await _customerRepo.UpdateCustomer(customer);
                    await _customerRepo.Save();
           
            return RedirectToAction("Index");
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerRepo.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
           
            _customerRepo.RemoveCustomer(id);
           
            await _customerRepo.Save();
            return RedirectToAction(nameof(Index));
        }

        //private bool CustomerExists(string id)
        //{
        //    return _context.Customers.Any(e => e.Customer_id == id);
        //}
       
    }
}
