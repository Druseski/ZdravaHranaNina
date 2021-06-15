using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using ZdravaHranaNinaEntities;
using ZdravaHranaNinaRepositories.Interfaces;
using ZdravaHranaNinaServices.Interfaces;

namespace ZdravaHranaNinaServices
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Add(Product product)
        {
            _productRepository.AddProduct(product);
        }

        public void Delete(int productId)
        {
            _productRepository.DeleteProduct(productId);
        }
        public void Edit(Product product)
        {
            _productRepository.EditProduct(product);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var result = _productRepository.GetAllProducts();
            return result;
        }

        public Product GetProductById(int id)
        {
            var result = _productRepository.GetProductById(id);
            return result;
        }


        #region Helper Function
        public Tuple<List<SelectListItem>> FillDropdowns(
            IEnumerable<Category> categories)
        {
            List<SelectListItem> Categories = new List<SelectListItem>
            {
                new SelectListItem {Value= "0" , Text = "Select Category..."}
            };
            foreach (var category in categories)
            {

                Categories.Add(new SelectListItem { Value = category.Id.ToString(), Text = category.Name });

            }
            return Tuple.Create(Categories);
        }


        #endregion
    }
}
