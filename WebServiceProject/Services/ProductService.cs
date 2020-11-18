using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceProject.Models;
using WebServiceProject.Repository;

namespace WebServiceProject.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }

        public async Task<Product> GetAsync(int id)
        {
            return await productRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await productRepository.ListAsync();
        }
        public async Task<IEnumerable<Product>> ListAsync(int? maincat)
        {
            return await productRepository.ListAsync(maincat);
        }
        public async Task<IEnumerable<Product>> ListAsync(int? maincat, int? subcat1)
        {
            return await productRepository.ListAsync(maincat, subcat1);
        }
        public async Task<IEnumerable<Product>> ListAsync(int? maincat, int? subcat1, int? subcat2)
        {
            return await productRepository.ListAsync(maincat, subcat1, subcat2);
        }
        public async Task<IEnumerable<Product>> ListShowcaseAsync()
        {
            return await productRepository.ListShowcaseAsync();
        }
    }
}
