using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServiceProject.Models;
using WebServiceProject.Persistence;
using WebServiceProject.Services;

namespace WebServiceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IService<MainCategory> categoryService;
        private readonly AppDbContext _context;
        public CategoriesController(AppDbContext context, IService<MainCategory> _categoryService)
        {
            categoryService = _categoryService;
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<MainCategory>> GetAllAsync()
        {
            IEnumerable<MainCategory> categories = await categoryService.ListAsync();
            return categories;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MainCategory>> GetAsync(int id)
        {
            var main = await _context.MainCategories.FindAsync(id);

            if (main == null)
            {
                return NotFound();
            }

            return main;
        }
    }
}