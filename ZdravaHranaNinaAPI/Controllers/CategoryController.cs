using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ZdravaHranaNinaEntities;
using ZdravaHranaNinaServices.ZdravaHranaNinaAPI.Interfaces;

namespace ZdravaHranaNinaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryServiceAPI _categoryServiceApi;

        public CategoryController(ICategoryServiceAPI categoryServiceApi)
        {
            _categoryServiceApi = categoryServiceApi;
        }

        // GET: api/<CategoryController>
        [HttpGet("GetCategories")]
        public async Task<IEnumerable<Category>> GetCategory()
        {
            return await _categoryServiceApi.GetCategory();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            return await _categoryServiceApi.GetCategoryById(id);
        }

        // POST api/<CategoryController>
        [HttpPost("PostCategory")]
        public async Task<ActionResult<Category>> Post([FromBody] Category category)
        {
            var newCategory = await _categoryServiceApi.Add(category);
            return CreatedAtAction(nameof(GetCategory), new { id = newCategory.Id }, newCategory);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutCategory(int id, [FromBody] Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }
            await _categoryServiceApi.Edit(category);
            return NoContent();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var categoryToDelete = await _categoryServiceApi.GetCategoryById(id);
            if (categoryToDelete == null)
                return NotFound();
            await _categoryServiceApi.Delete(categoryToDelete.Id);
            return NoContent();
        }
        public async Task<JsonResult> GetCategories()
        {
            CategoryData categoryData = new CategoryData();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://opinionated-quotes-api.gigalixirapp.com/v1/quotes"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    categoryData = JsonConvert.DeserializeObject<CategoryData>(apiResponse);

                    foreach (var category in categoryData.Categories)
                    {
                        Category newCategory = new Category()
                        {
                            Name = category.Name

                        };
                        await _categoryServiceApi.Add(newCategory);

                    }
                }
            }

            return Json(categoryData);
        }
    }
}
