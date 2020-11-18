using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceProject.Models;
using WebServiceProject.Persistence;

namespace WebServiceProject.Repository
{
    public class CurrencyRepository : BaseRepository,IRepository<Currency>
    {
        public CurrencyRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Currency>> ListAsync()
    {
        return await context.Currencies.ToListAsync();
    }
}
}
