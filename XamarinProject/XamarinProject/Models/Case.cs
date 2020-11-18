using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XamarinProject.Models
{
    public class Case
    {
        public int Id { get; set; }
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }
        public int ProductId { get; set; }
        public int Piece { get; set; }
    }
}
