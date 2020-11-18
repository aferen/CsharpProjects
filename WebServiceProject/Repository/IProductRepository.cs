using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceProject.Models;

namespace WebServiceProject.Repository
{
   public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListAsync();
        Task<IEnumerable<Product>> ListAsync(int? maincat);
        Task<IEnumerable<Product>> ListAsync(int? maincat, int? subcat1);
        Task<IEnumerable<Product>> ListAsync(int? maincat, int? subcat1, int? subcat2);
        Task<Product> GetAsync(int id);
        Task<IEnumerable<Product>> ListShowcaseAsync();
    }
}
