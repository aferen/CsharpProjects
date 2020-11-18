using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceProject.Models;
using WebServiceProject.Repository;

namespace WebServiceProject.Services
{
    public class SliderService : IService<Slider>
    {
        private readonly IRepository<Slider> sliderRepository;

        public SliderService(IRepository<Slider> _sliderRepository)
        {
            sliderRepository = _sliderRepository;
        }
        public async Task<IEnumerable<Slider>> ListAsync()
        {
            return await sliderRepository.ListAsync();
        }
    }
}
