using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceProject.Models;
using WebServiceProject.Persistence;

namespace WebServiceProject.Repository
{
    public class CommentRepository : BaseRepository, ICommentRepository
    {
        public CommentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Comment>> GetAsync(int id)
        {
            return await context.Comments.Where(x => x.ProductId == id).ToListAsync();
        }

        public async Task<IEnumerable<Comment>> ListAsync()
        {
            return await context.Comments.ToListAsync();
        }
    }
}
