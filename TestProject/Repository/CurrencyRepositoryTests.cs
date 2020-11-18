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
    public class CurrencyRepositoryTests
    {
        private AppDbContext _context;
        private CurrencyRepository _currencyRepository;
        private List<Currency> list1;
        public CurrencyRepositoryTests()
        {
            SetupMocks();
            _currencyRepository = new CurrencyRepository(_context);
        }
        private void SetupMocks()
        {
            list1 = new List<Currency>();
            list1.Add(new Currency { Id = 1, Name = "TL", Value = 1, IsActive = true });
            list1.Add(new Currency { Id = 2, Name = "USD", Value = 6.10, IsActive = true });
            list1.Add(new Currency { Id = 3, Name = "EURO", Value = 6.61, IsActive = true });

            var options = new DbContextOptionsBuilder<AppDbContext>()
               .UseInMemoryDatabase(databaseName: "Test")
               .Options;

            _context = new AppDbContext(options);
            if (_context.Currencies.ToListAsync().Result.Count == 0)
            {
                _context.Currencies.AddRange(list1);
                _context.SaveChanges();
            }

        }

        [Fact]
        public async Task Should_Return_All_Currencies()
        {
            var response = await _currencyRepository.ListAsync();
            Assert.NotNull(response);
            Assert.Equal(response, list1);
        }

    }
}
