using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XamarinProject.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Star { get; set; }
        public int YesCount { get; set; }
        public int NoCount { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }

    }
}
