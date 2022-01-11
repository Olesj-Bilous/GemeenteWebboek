using System.Threading.Tasks;
using ForumData.Entities;
namespace ForumData.Repositories.Interface
{
    public interface IProfielRepository
    {
<<<<<<< HEAD
        Task<Profiel> GetProfielByPersoonAsync(int id);
        Task AddProfielAsync(Profiel nieuwProfiel);
        void AddProfiel(Profiel profiel);
=======
        Task<Profiel> GetProfielByPersoonIdAsync(int id);
        Task AddProfielAsync (Profiel nieuwProfiel);
>>>>>>> development
        Task DeleteProfielAsync (Profiel deleteProfiel);
        Task UpdateProfielAsync (Profiel updateProfiel);
    }
}
