using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceProject.Models
{
    public class SubCategory2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int SubCategory1Id { get; set; }
        public SubCategory1 SubCategory1 { get; set; }
    }
}
