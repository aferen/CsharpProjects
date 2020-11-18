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
    public class SliderRepositoryTests
    {
        private AppDbContext _context;
        private SliderRepository _sliderRepository;
        private List<Slider> list1;
        public SliderRepositoryTests()
        {
            SetupMocks();
            _sliderRepository = new SliderRepository(_context);
        }
        private void SetupMocks()
        {
            list1 = new List<Slider>();
            list1.Add(new Slider { Id = 1, Name = "slider 1", ImagePath = "slider1.jpg", IsActive = true });
            list1.Add(new Slider { Id = 2, Name = "slider 2", ImagePath = "slider2.jpg", IsActive = true });
            list1.Add(new Slider { Id = 3, Name = "slider 3", ImagePath = "slider3.jpg", IsActive = true });
            list1.Add(new Slider { Id = 4, Name = "slider 4", ImagePath = "slider4.jpg", IsActive = true });

            var options = new DbContextOptionsBuilder<AppDbContext>()
               .UseInMemoryDatabase(databaseName: "Test")
               .Options;

            _context = new AppDbContext(options);
            if (_context.Sliders.ToListAsync().Result.Count == 0)
            {
                _context.Sliders.AddRange(list1);
                _context.SaveChanges();
            }

        }

        [Fact]
        public async Task Should_Return_All_Sliders()
        {
            var response = await _sliderRepository.ListAsync();
            Assert.NotNull(response);
            Assert.Equal(response, list1);
        }

    }
}
