
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shopping.Models;

namespace Shopping.DAL
{
    public interface IProductRepo:IDisposable
    {
        // Two Read Methods: Total List and separate Product By Id
        Task<IEnumerable<Product>> GetProductList();
        Task<Product> GetProductById(string id);

        Task InsertProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(string id);
        Task Save();
        
    }
}
