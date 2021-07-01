using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZdravaHranaNinaEntities;

namespace ZdravaHranaNinaServices.ZdravaHranaNinaAPI.Interfaces
{
    public interface IProductServiceAPI
    {
        Task<Product> Add(Product product);
        Task Delete(int id);
        Task Edit(Product product);
        Task<Product> GetProductById(int id);
        Task<IEnumerable<Product>> GetProduct();
    }
}
