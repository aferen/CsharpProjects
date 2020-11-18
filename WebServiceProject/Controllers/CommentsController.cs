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
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService commentService;

        public CommentsController(ICommentService _commentService)
        {
            commentService = _commentService;
        }

        [HttpGet]
        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            IEnumerable<Comment> comments = await commentService.ListAsync();
            return comments;
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<Comment>> GetAsync(int id)
        {
            try
            {
                IEnumerable<Comment> comments = await commentService.GetAsync(id);
                return comments;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}