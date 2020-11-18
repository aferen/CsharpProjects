using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceProject.Models;
using WebServiceProject.Persistence;

namespace WebServiceProject.Repository
{
    public class CategoryRepository : BaseRepository, IRepository<MainCategory>
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<MainCategory>> ListAsync()
        {
            return await context.MainCategories.Select(x => new MainCategory { Id = x.Id, IsActive = x.IsActive, Name = x.Name, SubCategory1List = context.SubCategories1s.Where(k => k.MainCategoryId == x.Id).Select(c => new SubCategory1 { Id = c.Id, IsActive = c.IsActive, Name = c.Name, MainCategoryId = x.Id, SubCategory2List = context.SubCategories2s.Where(r => r.SubCategory1Id == c.Id).ToList() }).ToList() }).ToListAsync();
        }
    }
}
