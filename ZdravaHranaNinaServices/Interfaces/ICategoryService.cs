using System;
using System.Collections.Generic;
using System.Text;
using ZdravaHranaNinaEntities;

namespace ZdravaHranaNinaServices.Interfaces
{
    public interface ICategoryService
    {
        void Add(Category category);
        void Edit(Category category);
        void Delete(int categoryId);
        Category GetCategoryById(int id);
        IEnumerable<Category> GetAllCategoryes();
    }
}
