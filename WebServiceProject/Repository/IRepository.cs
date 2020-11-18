using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceProject.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> ListAsync();
    }
}
