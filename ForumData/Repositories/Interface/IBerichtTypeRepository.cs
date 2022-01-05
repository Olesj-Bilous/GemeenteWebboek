using System.Threading.Tasks;
using ForumData.Entities;
namespace ForumData.Repositories.Interface
{
    public interface IBerichtTypeRepository
    {
        Task<BerichtType> GetBerichtTypeByIdAsync (int id);
        Task AddBerichtTypeAsync (BerichtType nieuwBerichtType);
        Task DeleteBerichtTypeAsync (BerichtType deleteBerichtType);
    }
}
