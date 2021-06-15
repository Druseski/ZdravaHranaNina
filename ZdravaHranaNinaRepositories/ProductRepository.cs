using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZdravaHranaNinaData;
using ZdravaHranaNinaEntities;
using ZdravaHranaNinaRepositories.Interfaces;

namespace ZdravaHranaNinaRepositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dataContext;

        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void AddProduct(Product product)
        {
            _dataContext.Products.Add(product);
            _dataContext.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            Product product = GetProductById(productId);
            _dataContext.Products.Remove(product);
            _dataContext.SaveChanges();
        }

        public void EditProduct(Product product)
        {
            _dataContext.Products.Update(product);
            _dataContext.SaveChanges();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var result = _dataContext.Products.AsEnumerable();
            return result;
        }

        public Product GetProductById(int id)
        {
            var result = _dataContext.Products.FirstOrDefault(x => x.Id == id);
            return result;
        }
    }
}
