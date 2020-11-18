using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebServiceProject.Models;
using WebServiceProject.Persistence;
using WebServiceProject.Repository;
using Xunit;

namespace TestProject.Repository
{
    public class CommentRepositoryTests
    {
        private AppDbContext _context;
        private CommentRepository _commentRepository;
        private List<Comment> list1;
        public CommentRepositoryTests()
        {
            SetupMocks();
            _commentRepository = new CommentRepository(_context);
        }
        private void SetupMocks()
        {
            list1 = new List<Comment>();
            list1.Add(new Comment { Id = 1, ProductId = 1, Description = "Kaliteli Ürün", NoCount = 2, YesCount = 1, Star = 5, Title = "Kaliteli" });
            list1.Add(new Comment { Id = 2, ProductId = 1, Description = "İyi Ürün", NoCount = 1, YesCount = 2, Star = 5, Title = "İyi" });
            list1.Add(new Comment { Id = 3, ProductId = 5, Description = "Eksik Parça", NoCount = 1, YesCount = 3, Star = 1, Title = "Eksik" });
            list1.Add(new Comment { Id = 4, ProductId = 6, Description = "Kötü", NoCount = 2, YesCount = 1, Star = 1, Title = "Kötü" });

            var options = new DbContextOptionsBuilder<AppDbContext>()
               .UseInMemoryDatabase(databaseName: "Test")
               .Options;

            _context = new AppDbContext(options);
            if (_context.Comments.ToListAsync().Result.Count == 0)
            {
                _context.Comments.AddRange(list1);
                _context.SaveChanges();
            }
           
        }

        [Fact]
        public async Task Should_Return_All_Comments()
        {
            var response = await _commentRepository.ListAsync();
            Assert.NotNull(response);
            Assert.Equal(response, list1);
        }

        [Fact]
        public async Task Should_Not_Return_Comment_For_Non_Existing_ProductId()
        {
            IEnumerable<Comment> response = await _commentRepository.GetAsync(50);
            Assert.Empty(response);
        }

        [Fact]
        public async Task Should_Return_Comment_For_ProductId()
        {
            var response = await _commentRepository.GetAsync(1);
            Assert.NotNull(response);
        }
    }
}
