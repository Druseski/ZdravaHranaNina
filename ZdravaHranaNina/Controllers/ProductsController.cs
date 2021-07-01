using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZdravaHranaNina.Models;
using ZdravaHranaNinaData;
using ZdravaHranaNinaEntities;
using ZdravaHranaNinaServices.Interfaces;

namespace ZdravaHranaNina.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DataContext _context;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductsController(DataContext context,
        IProductService productService,
        ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Products.Include(p => p.Category);
            return View(await dataContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpGet]
        
        public JsonResult GetAllBooksAJAX()
        {
            var allProducts = _productService.GetAllProducts();
            return Json(new { productData = allProducts});
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            var categories = _categoryService.GetAllCategoryes();
            var dropdowns = _productService.FillDropdowns(categories);
            
            ViewBag.CategoryList = dropdowns.Item1;
            
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,BestBefore,DateManifactured,Price,Manifacturer,Discription,UserID,CategoryName,CategoryID,Shipping,PhotoURL,SoldItems,Rating,DateAdded,CountryOFOrigin,Popularity,ByWeight,ByPeace,CategoryNameDTO")] ProductViewModel model)
        {
            var product = new Product();
            product.BestBefore = model.BestBefore;
            product.ByPeace = model.ByPeace;
            product.ByWeight = model.ByWeight;
            product.Category = model.Category;
            product.CategoryID = model.CategoryID;
            product.CategoryName = model.CategoryNameDTO;
            product.CountryOfOrigin = model.CountryOfOrigin;
            product.DateAdded = model.DateAdded;
            product.DateManifactured = model.DateManifactured;
            product.Discription = model.Discription;
            product.Manifacturer = model.Manifacturer;
            product.Name = model.Name;
            product.UserID = model.UserID;
            product.PhotoURL = model.PhotoURL;
            product.Popularity = model.Popularity;
            product.Price = model.Price;
            product.Rating = model.Rating;
            product.Shipping = model.Shipping;
            product.SoldItems = model.SoldItems;

            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryID);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,BestBefore,DateManifactured,Price,Manifacturer,Discription,UserID,CategoryName,CategoryID,Shipping,PhotoURL,SoldItems,Rating,DateAdded,CountryOFOrigin,Popularity,ByWeight,ByPeace,CategoryNameDTO")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryID);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        [HttpPost]
        public IActionResult UploadPhoto()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("wwwroot", "photos");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = fileName;

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal Server Error" + ex);
            }

        }
    }
}
