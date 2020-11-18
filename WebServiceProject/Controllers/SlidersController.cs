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
    public class SlidersController : ControllerBase
    {
        private readonly IService<Slider> sliderService;

        public SlidersController(IService<Slider> _sliderService)
        {
            sliderService = _sliderService;
        }

        [HttpGet]
        public async Task<IEnumerable<Slider>> GetAllAsync()
        {
            IEnumerable<Slider> slider = await sliderService.ListAsync();
            return slider;
        }
    }
}