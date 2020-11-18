using System.ComponentModel.DataAnnotations;

namespace WebServiceProject.Models.Resources
{
    public class RevokeTokenResource
    {
        [Required]
        public string Token { get; set; }
    }
}