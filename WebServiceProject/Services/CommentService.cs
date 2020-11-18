using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceProject.Models;
using WebServiceProject.Repository;

namespace WebServiceProject.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository commentRepository;

        public CommentService(ICommentRepository _commentRepository)
        {
            commentRepository = _commentRepository;
        }

        public async Task<IEnumerable<Comment>> GetAsync(int id)
        {
            return await commentRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Comment>> ListAsync()
        {
            return await commentRepository.ListAsync();
        }
    }
}
