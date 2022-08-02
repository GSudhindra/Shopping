using Microsoft.EntityFrameworkCore;
using Shopping.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.DAL
{
    public class CustomerRepo : ICustomerRepo
    {
    //    CustomerRepo obj = new CustomerRepo();
        private readonly shopContext _context;
        public CustomerRepo(shopContext db)
        {
            _context = db;

        }
        public void AddCustomer(Customer customer)
        {
            _context.Add(customer);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomer(string cid)
        {
           return await _context.Customers
                .FirstOrDefaultAsync(m => m.Customer_id == cid);
        }

        public async void RemoveCustomer(string cid)
        {
            Customer customer = await _context.Customers.FindAsync(cid);
            _context.Customers.Remove(customer);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCustomer(Customer customer)
        {
              _context.Update(customer); 
        }
        

       
    }
}
