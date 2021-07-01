using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZdravaHranaNinaEntities;
using ZdravaHranaNinaRepositories.ZdravaHranaNinaAPI.Interfaces;
using ZdravaHranaNinaServices.ZdravaHranaNinaAPI.Interfaces;

namespace ZdravaHranaNinaServices.ZdravaHranaNinaAPI
{
    public class ProductServiceAPI : IProductServiceAPI
    {
        private readonly IProductRepositoryAPI _productRepositoryApi;

        public ProductServiceAPI(IProductRepositoryAPI productRepositoryApi)
        {
            _productRepositoryApi = productRepositoryApi;
        }

        public async Task<Product> Add(Product product)
        {
            await _productRepositoryApi.Add(product);
            return product;
        }

        public async Task Delete(int id)
        {
            await _productRepositoryApi.Delete(id);
        }

        public async Task Edit(Product product)
        {
            await _productRepositoryApi.Edit(product);
        }

        public async Task<Product> GetProductById(int id)
        {
            var result = await _productRepositoryApi.GetProductById(id);
            return result;
        }

        public async Task<IEnumerable<Product>> GetProduct()
        {
            var result = await _productRepositoryApi.GetProduct();
            return result;
        }
    }
}
