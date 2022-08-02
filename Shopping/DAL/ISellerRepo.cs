using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shopping.Models;

namespace Shopping.DAL
{
    public interface ISellerRepo : IDisposable
    {
        Task<Seller> GetSellerById(string id);
        Task<IEnumerable<Seller>> GetSellerList();
        Task AddSeller(Seller seller);
        Task UpdateSeller(Seller seller);
        Task DeleteSeller(string id);
        Task Save();

        
    }
}
