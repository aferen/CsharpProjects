using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WpfProject.Models
{
    public class MainCategory    
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public IList<SubCategory1> SubCategory1List { get; set; } = new List<SubCategory1>();

    }
}
