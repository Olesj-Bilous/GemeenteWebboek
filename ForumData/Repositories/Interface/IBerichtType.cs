using System.Threading.Tasks;
using ForumData.Models;

namespace ForumData.Repositories.Interface
{
    public interface IBerichtType
    {
        Task<BerichtType> GetBerichtTypeByIdAsync (int id);
        Task AddBerichtTypeAsync (BerichtType nieuwBerichtType);
        Task DeleteBerichtTypeAsync (BerichtType deleteBerichtType);
    }
}
