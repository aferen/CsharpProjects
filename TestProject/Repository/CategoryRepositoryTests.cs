using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebServiceProject.Models;
using WebServiceProject.Persistence;
using WebServiceProject.Repository;
using Xunit;

namespace TestProject.Repository
{
    public class CategoryRepositoryTests
    {
        private AppDbContext _context;
        private CategoryRepository _categoryRepository;
        private List<MainCategory> mainlist;
        private List<SubCategory1> sub1list;
        private List<SubCategory2> sub2list;
        public CategoryRepositoryTests()
        {
            SetupMocks();
            _categoryRepository = new CategoryRepository(_context);
        }
        private void SetupMocks()
        {
            sub2list = new List<SubCategory2>();
            sub2list.Add(new SubCategory2 { Id = 1, Name = "Arduino Modüller", SubCategory1Id = 5, IsActive = true });
            sub2list.Add(new SubCategory2 { Id = 2, Name = "Kablosuz Haberleşme", SubCategory1Id = 5, IsActive = true });

            sub1list = new List<SubCategory1>();
            sub1list.Add(new SubCategory1 { Id = 1, Name = "Orijinal Arduino", MainCategoryId = 4, IsActive = true });
            sub1list.Add(new SubCategory1 { Id = 5, Name = "Arduino Sensör ve Modüller", MainCategoryId = 4, IsActive = true, SubCategory2List = sub2list });

            mainlist = new List<MainCategory>();
            mainlist.Add(new MainCategory { Id = 1, Name = "Mikrodenetleyiciler", IsActive = true });
            mainlist.Add(new MainCategory { Id = 2, Name = "Entegreler", IsActive = true });
            mainlist.Add(new MainCategory { Id = 3, Name = "Yarı İletkenler", IsActive = true });
            mainlist.Add(new MainCategory { Id = 4, Name = "Arduino", IsActive = true, SubCategory1List = sub1list });

            var options = new DbContextOptionsBuilder<AppDbContext>()
               .UseInMemoryDatabase(databaseName: "Test")
               .Options;

            _context = new AppDbContext(options);
            if (_context.MainCategories.ToListAsync().Result.Count == 0)
            {
                _context.MainCategories.AddRange(mainlist);
                _context.SaveChanges();
            }

        }

        [Fact]
        public async Task Should_Return_All_Categories()
        {
            var response = await _categoryRepository.ListAsync();
            Assert.NotNull(response);
        }
    }
}
