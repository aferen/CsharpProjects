using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XamarinProject.Models
{
    public class SubCategory1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int MainCategoryId { get; set; }
        public MainCategory MainCategory { get; set; }
        public IList<SubCategory2> SubCategory2List { get; set; } = new List<SubCategory2>();
    }
}
