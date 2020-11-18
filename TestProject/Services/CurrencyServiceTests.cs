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
    public class CurrencyServiceTests
    {
        private Mock<IRepository<Currency>> _currencyRepository;
        private IService<Currency> _currencyservice;
        private List<Currency> list1;
        private List<Currency> list2;

        public CurrencyServiceTests()
        {
            SetupMocks();
            _currencyservice = new CurrencyService(_currencyRepository.Object);
        }

        private void SetupMocks()
        {
            list1 = new List<Currency>();
            list1.Add(new Currency { Id = 1, Name = "TL", Value = 1, IsActive = true });
            list1.Add(new Currency { Id = 2, Name = "USD", Value = 6.10, IsActive = true });
            list1.Add(new Currency { Id = 3, Name = "EURO", Value = 6.61, IsActive = true });

            _currencyRepository = new Mock<IRepository<Currency>>();
            _currencyRepository.Setup(x => x.ListAsync()).ReturnsAsync(list1);
        }

        [Fact]
        public async Task Should_Return_All_Currencies()
        {
            var response = await _currencyservice.ListAsync();
            Assert.NotNull(response);
            Assert.Equal(response, list1);
        }

    }
}
