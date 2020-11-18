using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceProject.Models;
using WebServiceProject.Repository;

namespace WebServiceProject.Services
{
    public class CategoryService : IService<MainCategory>
    {
        private readonly IRepository<MainCategory> categoryRepository;

        public CategoryService(IRepository<MainCategory> _categoryRepository)
        {
            categoryRepository = _categoryRepository;
        }
        public async Task<IEnumerable<MainCategory>> ListAsync()
        {
            return await categoryRepository.ListAsync();
        }
    }
}
