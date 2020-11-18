using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WpfProject.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public decimal NewPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int? CountProduct { get; set; }
        public string  Title { get; set; }
        public string Origin { get; set; }
        public string Description { get; set; }
        public string Property { get; set; }
        public string StockCode { get; set; }
        public int CategoryId { get; set; }
        public int SubCategory1Id { get; set; }
        public int SubCategory2Id { get; set; }
        public string Image { get; set; }
        public bool IsShowcaseProduct { get; set; }
        public bool IsActive { get; set; }
        public int? CommentCount { get; set; }
    }
}
