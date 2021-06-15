using System;
using System.Collections.Generic;
using System.Text;
using ZdravaHranaNinaEntities;

namespace ZdravaHranaNinaRepositories.Interfaces
{
    public interface IProductRepository 
    {
        void AddProduct(Product product);
        void EditProduct(Product product);
        void DeleteProduct(int productId);
        Product GetProductById(int id);
        IEnumerable<Product> GetAllProducts();
    }
}
