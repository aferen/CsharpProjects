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
    public class SliderServiceTests
    {
        private Mock<IRepository<Slider>> _sliderRepository;
        private IService<Slider> _sliderservice;
        private List<Slider> list1;
        private List<Slider> list2;

        public SliderServiceTests()
        {
            SetupMocks();
            _sliderservice = new SliderService(_sliderRepository.Object);
        }

        private void SetupMocks()
        {
            list1 = new List<Slider>();
            list1.Add(new Slider { Id = 1, Name = "slider 1", ImagePath = "slider1.jpg", IsActive = true });
            list1.Add(new Slider { Id = 2, Name = "slider 2", ImagePath = "slider2.jpg", IsActive = true });
            list1.Add(new Slider { Id = 3, Name = "slider 3", ImagePath = "slider3.jpg", IsActive = true });
            list1.Add(new Slider { Id = 4, Name = "slider 4", ImagePath = "slider4.jpg", IsActive = true });

            _sliderRepository = new Mock<IRepository<Slider>>();
            _sliderRepository.Setup(x => x.ListAsync()).ReturnsAsync(list1);
        }

        [Fact]
        public async Task Should_Return_All_Sliders()
        {
            var response = await _sliderservice.ListAsync();
            Assert.NotNull(response);
            Assert.Equal(response, list1);
        }
    }
}
