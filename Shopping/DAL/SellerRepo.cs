using Microsoft.EntityFrameworkCore;
using Shopping.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.DAL
{
    public class SellerRepo : ISellerRepo
    {
        private readonly shopContext _shopContext;

        public SellerRepo()
        {
        }

        public SellerRepo(shopContext shopcontext)
        {
            _shopContext = shopcontext;
        }

        public async Task AddSeller(Seller seller)
        {
            await _shopContext.AddAsync(seller);
        }

        public async Task DeleteSeller(string id)
        {
            Seller seller=await GetSellerById(id);
            _shopContext.Remove(seller);
            
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Seller> GetSellerById(string id)
        {
            return await _shopContext.Sellers.FindAsync(id);
        }

        public async Task<IEnumerable<Seller>> GetSellerList()
        {
            return await _shopContext.Sellers.ToListAsync();
        }

        public async Task Save()
        {
            await _shopContext.SaveChangesAsync();
        }

        public async Task UpdateSeller(Seller seller)
        {
             _shopContext.Update(seller);
        }

      

    }
}
