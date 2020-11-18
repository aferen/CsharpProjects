using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceProject.Models;
using WebServiceProject.Persistence;

namespace WebServiceProject.Repository
{
    public class SliderRepository: BaseRepository,IRepository<Slider>
    {
        public SliderRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Slider>> ListAsync()
        {
            return await context.Sliders.ToListAsync();                
        }
    }
}
