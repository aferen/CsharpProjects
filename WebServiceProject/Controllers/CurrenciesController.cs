using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServiceProject.Models;
using WebServiceProject.Services;

namespace WebServiceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        public readonly IService<Currency> currencyService;

        public CurrenciesController(IService<Currency> _currencyService)
        {
            currencyService = _currencyService;
        }

        [HttpGet]
        public async Task<IEnumerable<Currency>> GetAllAsync()
        {
            IEnumerable<Currency> currency = await currencyService.ListAsync();
            return currency;
        }
    }
}