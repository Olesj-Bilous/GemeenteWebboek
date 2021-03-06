using System.Collections.Generic;
using System.Threading.Tasks;
using ForumData.Entities;
namespace ForumData.Repositories.Interface
{
    public interface IProfielRepository
    {
        //async
        Task<Profiel> GetProfielByPersoonIdAsync(int id);
        Task AddProfielAsync (Profiel nieuwProfiel);
        Task DeleteProfielAsync (Profiel deleteProfiel);
        Task UpdateProfielAsync (Profiel updateProfiel);
        Task <List<Profiel>> GetAllAsync();

        //sync
        void AddProfiel(Profiel profiel);
        Profiel GetProfielById(int id);
    }
}
