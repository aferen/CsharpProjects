using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebServiceProject.Models;
using WebServiceProject.Repository;
using WebServiceProject.Services;
using Xunit;

namespace TestProject.Services
{
    public class CategoryServiceTests
    {
        private Mock<IRepository<MainCategory>> _categoryRepository;
        private IService<MainCategory> _categoryservice;
        private List<MainCategory> mainlist;
        private List<SubCategory1> sub1list;
        private List<SubCategory2> sub2list;

        public CategoryServiceTests()
        {
            SetupMocks();
            _categoryservice = new CategoryService(_categoryRepository.Object);
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
            
            _categoryRepository = new Mock<IRepository<MainCategory>>();
            _categoryRepository.Setup(x => x.ListAsync()).ReturnsAsync(mainlist);

        }

        [Fact]
        public async Task Should_Return_All_Categories()
        {
            var response = await _categoryservice.ListAsync();
            Assert.NotNull(response);
            Assert.Equal(response, mainlist);
        }
    }
}
