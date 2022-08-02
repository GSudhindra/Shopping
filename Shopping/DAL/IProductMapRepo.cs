using Shopping.Models;
using System;
using System.Collections.Generic;

namespace Shopping.DAL
{
    public interface IProductMapRepo:IDisposable
    {
        
        IEnumerable<ProductMap> GetProductMapList();
        ProductMap GetProductMapById(string id);

        void InsertProductMap(ProductMap productMap);
        void Save();

    }
}
