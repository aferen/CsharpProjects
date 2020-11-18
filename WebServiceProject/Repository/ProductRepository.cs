using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceProject.Models;
using WebServiceProject.Persistence;

namespace WebServiceProject.Repository
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Product> GetAsync(int id)
        {
            return await context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await context.Products.ToListAsync();
        }
        public async Task<IEnumerable<Product>> ListAsync(int? maincat)
        {
            return await context.Products.Where(x => x.CategoryId == maincat).Select(x => new Product { Id = x.Id, Title = x.Title, Price = x.Price, Image = x.Image }).ToListAsync();
        }
        public async Task<IEnumerable<Product>> ListAsync(int? maincat, int? subcat1)
        {
            return await context.Products.Where(x => x.CategoryId == maincat && x.SubCategory1Id == subcat1).Select(x => new Product { Id = x.Id, Title = x.Title, Price = x.Price, Image = x.Image }).ToListAsync();
        }
        public async Task<IEnumerable<Product>> ListAsync(int? maincat, int? subcat1, int? subcat2)
        {
            return await context.Products.Where(x => x.SubCategory1Id == subcat1 && x.SubCategory2Id == subcat2).Select(x => new Product { Id = x.Id, Title = x.Title, Price = x.Price, Image = x.Image }).ToListAsync();
        }

        public async Task<IEnumerable<Product>> ListShowcaseAsync()
        {
            return await context.Products.Where(x => x.IsShowcaseProduct == true).Select(x => new Product { Id = x.Id, Title = x.Title, Price = x.Price, Image = x.Image }).ToListAsync();
        }


    }
}
