using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebServiceProject.Models;
using WebServiceProject.Repository;
using WebServiceProject.Services;
using Xunit;

namespace TestProject.Services
{
    public class CommentServiceTests
    {
        private Mock<ICommentRepository> _commentRepository;
        private ICommentService _commentservice;
        private List<Comment> list1;
        private List<Comment> list2;

        public CommentServiceTests()
        {
            SetupMocks();
            _commentservice = new CommentService(_commentRepository.Object);
        }

        private void SetupMocks()
        {
            list1 = new List<Comment>();
            list1.Add(new Comment { Id = 1, ProductId = 1, Description = "Kaliteli Ürün", NoCount = 2, YesCount = 1, Star = 5, Title = "Kaliteli" });
            list1.Add(new Comment { Id = 2, ProductId = 1, Description = "İyi Ürün", NoCount = 1, YesCount = 2, Star = 5, Title = "İyi" });
            list1.Add(new Comment { Id = 3, ProductId = 5, Description = "Eksik Parça", NoCount = 1, YesCount = 3, Star = 1, Title = "Eksik" });
            list1.Add(new Comment { Id = 4, ProductId = 6, Description = "Kötü", NoCount = 2, YesCount = 1, Star = 1, Title = "Kötü" });

            list2 = new List<Comment>();
            list2.Add(new Comment { Id = 1, ProductId = 1, Description = "Kaliteli Ürün", NoCount = 2, YesCount = 1, Star = 5, Title = "Kaliteli" });
            list2.Add(new Comment { Id = 2, ProductId = 1, Description = "İyi Ürün", NoCount = 1, YesCount = 2, Star = 5, Title = "İyi" });

            _commentRepository = new Mock<ICommentRepository>();
            _commentRepository.Setup(x => x.ListAsync()).ReturnsAsync(list1);

            _commentRepository.Setup(x => x.GetAsync(1)).ReturnsAsync(list2);

        }

        [Fact]
        public async Task Should_Return_All_Comments()
        {
            var response = await _commentservice.ListAsync();
            Assert.NotNull(response);
            Assert.Equal(response, list1);
        }

        [Fact]
        public async Task Should_Return_Comment_For_ProductId()
        {
            var response = await _commentservice.GetAsync(1);
            Assert.NotNull(response);
            Assert.Equal(response, list2);
        }

        [Fact]
        public async Task Should_Not_Return_Comment_For_Non_Existing_ProductId()
        {
            var response = await _commentservice.GetAsync(50);
            Assert.Empty(response);
        }
    }
}
