using System.Threading.Tasks;
using WebServiceProject.Models;
using WebServiceProject.Services.Communication;

namespace WebServiceProject.Services
{
    public interface IUserService
    {
         Task<CreateUserResponse> CreateUserAsync(User user, params ERole[] userRoles);
         Task<User> FindByEmailAsync(string email);
    }
}