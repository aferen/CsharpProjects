using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServiceProject.Models;
using WebServiceProject.Persistence;
using WebServiceProject.Services;

namespace WebServiceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly AppDbContext _context;

        public ProductsController(IProductService _productService)
        {
            productService = _productService;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            IEnumerable<Product> products = await productService.ListAsync();
            return products;
        }

        [HttpGet("Maincategory/{maincat}")]
        public async Task<IEnumerable<Product>> GetAllAsync(int maincat)
        {
            return await productService.ListAsync(maincat);
        }

        [HttpGet("{maincat}/{subcat1}")]
        public async Task<IEnumerable<Product>> GetAllAsync(int maincat, int subcat1)
        {
            return await productService.ListAsync(maincat, subcat1);
        }
        [HttpGet("{maincat}/{subcat1}/{subcat2}")]
        public async Task<IEnumerable<Product>> GetAllAsync(int maincat, int subcat1, int subcat2)
        {
            return await productService.ListAsync(maincat, subcat1, subcat2);
        }

        [HttpGet("{id}")]
        public async Task<Product> GetAsync(int id)
        {
            Product products = await productService.GetAsync(id);
            return products;
        }

        [HttpGet]
        [Route("ShowcaseProduct")]
        public async Task<IEnumerable<Product>> GetShowcaseProductAsync()
        {
            IEnumerable<Product> products = await productService.ListShowcaseAsync();
            return products;
        }

        //[HttpPost]
        //public async Task<ActionResult<Product>> PostProduct(Product @product)
        //{
        //    _context.Products.Add(@product);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetAsync", new { id = @product.Id }, @product);
        //}
    }
}