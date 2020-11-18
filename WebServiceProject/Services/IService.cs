using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceProject.Services
{
    public interface IService<T>
    {
        Task<IEnumerable<T>> ListAsync();
    }
}
