using Shopping.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.DAL
{
    public interface ICustomerRepo
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        void AddCustomer(Customer customer);
        void RemoveCustomer(string cid);
        Task<Customer> GetCustomer(string cid);
        Task UpdateCustomer(Customer customer);

        Task Save();
    }

}
