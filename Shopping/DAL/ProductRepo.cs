using Microsoft.EntityFrameworkCore;
using Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.DAL
{
    public class ProductRepo : IProductRepo
    {
        private readonly shopContext _shopContext;
        public ProductRepo(shopContext db)
        {
            _shopContext = db;
            
        }
       

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Product> GetProductById(string id)
        {
           return await _shopContext.Products
                .FirstOrDefaultAsync(m => m.Product_id == id);
        }

        public async Task DeleteProduct(string id)
        {
            var product = await GetProductById(id);
            _shopContext.Products.Remove(product);
        }

        public async Task InsertProduct(Product product)
        {
            await _shopContext.Products.AddAsync(product);
        }
        public async Task<IEnumerable<Product>> GetProductList()
        {
            return await _shopContext.Products.ToListAsync();
        }

        public async Task Save()
        {
            await _shopContext.SaveChangesAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            _shopContext.Products.Update(product);
        }
        
        
    }
}
