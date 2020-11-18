using System.Threading.Tasks;

namespace WebServiceProject.Repositories
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}