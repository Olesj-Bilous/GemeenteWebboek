using ForumData.Models;
using System.Threading.Tasks;

namespace ForumData.Repositories.Interface
{
    public interface IBericht
    {
        Task<Bericht> GetBerichtByIdAsync(int id);
        Task AddBerichtAsync(Bericht newBericht);
        Task DeleteBerichtAsync (IBericht deleteBericht);
        Task UpdateBerichtAsync (IBericht aangepastBericht);

    }
}
