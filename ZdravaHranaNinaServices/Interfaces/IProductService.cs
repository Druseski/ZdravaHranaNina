using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using ZdravaHranaNinaEntities;

namespace ZdravaHranaNinaServices.Interfaces
{
    public interface IProductService
    {
        void Add(Product product);
        void Edit(Product product);
        void Delete(int productId);
        Product GetProductById(int id);
        IEnumerable<Product> GetAllProducts();
        Tuple<List<SelectListItem>> FillDropdowns(
            IEnumerable<Category> categories);
    }
}
