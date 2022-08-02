using Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping.DAL
{
    public class ProductMapRepo : IProductMapRepo
    {
        private shopContext _shopContext;
        public ProductMapRepo(shopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ProductMap GetProductMapById(string id)
        {
             
            return _shopContext.ProductMap.Find(id);
        }


        public IEnumerable<ProductMap> GetProductMapList()
        {
            return _shopContext.ProductMap.ToList();
        }

        public void InsertProductMap(ProductMap productMap)
        {
            _shopContext.ProductMap.Add(productMap);
        }

        public void Save()
        {
            _shopContext.SaveChanges(true);
        }

       
    }
}
