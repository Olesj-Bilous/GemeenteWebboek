using System.Threading.Tasks;
using ForumData.Models;

namespace ForumData.Repositories.Interface
{
    public interface IProfiel
    {
        Task<Profiel> GetProfielByPersoonAsync(int id);
        Task AddProfielAsync (Profiel nieuwProfiel);
        Task DeleteProfielAsync (Profiel deleteProfiel);
        Task UpdateProfielAsync (Profiel updateProfiell);
    }
}
