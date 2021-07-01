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
    public class ProductController : Controller
    {
        private readonly IProductServiceAPI _productServiceApi;

        public ProductController(IProductServiceAPI productServiceApi)
        {
            _productServiceApi = productServiceApi;
        }

        // GET: api/<ProductController>
        [HttpGet("GetProducts")]
        public async Task<IEnumerable<Product>> GetProduct()
        {
            return await _productServiceApi.GetProduct();
        }

        // GET api/<ProductController>/5
        [HttpGet("GetProductsById")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            return await _productServiceApi.GetProductById(id);
        }

        // POST api/<ProductController>
        [HttpPost("PostProducts")]
        public async Task<ActionResult<Product>> Post([FromBody] Product product)
        {
            var newProduct = await _productServiceApi.Add(product);
            return CreatedAtAction(nameof(GetProduct), new { id = newProduct.Id }, newProduct);
        }

        // PUT api/<ProductController>/5
        [HttpPut("PutProducts")]
        public async Task<ActionResult> PutProduct(int id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            await _productServiceApi.Edit(product);
            return NoContent();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("DeleteProducts")]
        public async Task<ActionResult> Delete(int id)
        {
            var productToDelete = await _productServiceApi.GetProductById(id);
            if (productToDelete == null)
                return NotFound();
            await _productServiceApi.Delete(productToDelete.Id);
            return NoContent();
        }
        public async Task<JsonResult> GetProducts()
        {
            ProductData productData = new ProductData();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://opinionated-quotes-api.gigalixirapp.com/v1/quotes"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    productData = JsonConvert.DeserializeObject<ProductData>(apiResponse);

                    foreach (var product in productData.Products)
                    {
                        Product newProduct = new Product()
                        {

                            Name = product.Name,
                            BestBefore = product.BestBefore,
                            DateManifactured = product.DateManifactured,
                            Price = product.Price,
                            Manifacturer = product.Manifacturer,
                            Discription = product.Discription,
                            UserID = product.UserID,
                            CategoryName = product.CategoryName,
                            CategoryID = product.CategoryID,
                            Category = product.Category,
                            Shipping = product.Shipping,
                            PhotoURL = product.PhotoURL,
                            SoldItems = product.SoldItems,
                            Rating = product.Rating,
                            DateAdded = product.DateAdded,
                            CountryOfOrigin = product.CountryOfOrigin,
                            ByWeight = product.ByWeight,
                            ByPeace = product.ByPeace


                        };
                        await _productServiceApi.Add(newProduct);

                    }
                }
            }


            return Json(productData);
        }
    }
}
