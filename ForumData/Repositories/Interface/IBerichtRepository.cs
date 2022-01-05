using ForumData.Entities;
using System.Threading.Tasks;

namespace ForumData.Repositories.Interface
{
    public interface IBerichtRepository
    {
        Task<Bericht> GetBerichtByIdAsync(int id);
        Task AddBerichtAsync(Bericht newBericht);
        Task DeleteBerichtAsync (Bericht deleteBericht);
        Task UpdateBerichtAsync (Bericht aangepastBericht);

    }
}
