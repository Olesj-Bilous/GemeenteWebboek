using System.Threading.Tasks;
using ForumData.Models;

namespace ForumData.Repositories.Interface
{
    public interface IAfdeling
    {
        Task<Afdeling> GetAfdelingByIdAsync(int id);
    }
}
