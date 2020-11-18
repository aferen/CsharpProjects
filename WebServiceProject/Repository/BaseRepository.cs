using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceProject.Persistence;

namespace WebServiceProject.Repository
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext context;

        public BaseRepository(AppDbContext _context)
        {
            context = _context;
        }
    }
}
