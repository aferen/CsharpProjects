using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceProject.Models;

namespace WebServiceProject.Services
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> ListAsync();
        Task<IEnumerable<Comment>> GetAsync(int id);

    }
}
