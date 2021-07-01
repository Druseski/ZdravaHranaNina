using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZdravaHranaNinaEntities;
using ZdravaHranaNinaRepositories.ZdravaHranaNinaAPI.Interfaces;
using ZdravaHranaNinaServices.ZdravaHranaNinaAPI.Interfaces;

namespace ZdravaHranaNinaServices.ZdravaHranaNinaAPI
{
    public class CategoryServiceAPI : ICategoryServiceAPI
    {
        private readonly ICategoryRepositoryAPI _categoryRepositoryApi;

        public CategoryServiceAPI(ICategoryRepositoryAPI categoryRepositoryApi)
        {
            _categoryRepositoryApi = categoryRepositoryApi;
        }

        public async Task<Category> Add(Category category)
        {
            await _categoryRepositoryApi.Add(category);
            return category;
        }

        public async Task Delete(int id)
        {
            await _categoryRepositoryApi.Delete(id);
        }

        public async Task Edit(Category category)
        {
            await _categoryRepositoryApi.Edit(category);
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var result = await _categoryRepositoryApi.GetCategoryById(id);
            return result;
        }

        public async Task<IEnumerable<Category>> GetCategory()
        {
            var result = await _categoryRepositoryApi.GetCategory();
            return result;
        }


    }
}
