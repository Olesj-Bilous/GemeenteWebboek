using System.Threading.Tasks;
using ForumData.Entities;
namespace ForumData.Repositories.Interface
{
    public interface IAfdelingRepository
    {
        Task<Afdeling> GetAfdelingByIdAsync(int id);
    }
}
