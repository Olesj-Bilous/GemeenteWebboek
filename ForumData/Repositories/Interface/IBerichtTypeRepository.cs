using System.Threading.Tasks;
using ForumData.Entities;
namespace ForumData.Repositories.Interface
{
    public interface IBerichtTypeRepository
    {
        Task<BerichtThema> GetBerichtTypeByIdAsync (int id);
        Task AddBerichtTypeAsync (BerichtThema nieuwBerichtType);
        Task DeleteBerichtTypeAsync (BerichtThema deleteBerichtType);
    }
}
