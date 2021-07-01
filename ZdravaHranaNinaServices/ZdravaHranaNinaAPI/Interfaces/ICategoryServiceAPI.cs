using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZdravaHranaNinaEntities;

namespace ZdravaHranaNinaServices.ZdravaHranaNinaAPI.Interfaces
{
    public interface ICategoryServiceAPI
    {
        Task<Category> Add(Category category);
        Task Delete(int id);
        Task Edit(Category category);
        Task<Category> GetCategoryById(int id);
        Task<IEnumerable<Category>> GetCategory();
    }
}
