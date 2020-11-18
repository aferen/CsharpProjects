using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceProject.Models;
using WebServiceProject.Repository;

namespace WebServiceProject.Services
{
    public class CurrencyService: IService<Currency>
    {
        public readonly IRepository<Currency> currencyRepository;
        public CurrencyService(IRepository<Currency> _currencyRepository)
        {
            currencyRepository = _currencyRepository;
        }
        public async Task<IEnumerable<Currency>> ListAsync()
        {
            return await currencyRepository.ListAsync();
        }
    }
}
