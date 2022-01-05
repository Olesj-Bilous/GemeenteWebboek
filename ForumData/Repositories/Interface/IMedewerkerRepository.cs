using System.Threading.Tasks;
using ForumData.Entities;
namespace ForumData.Repositories.Interface
{
    public interface IMedewerkerRepository
    {
        Task<Medewerker> GetMedewerkerOpPersoonIdAsync (int id);
        Task AddMedewerkerAsync (Medewerker nieuwMedewerker);
        Task DeleteMedewerkerAsync (Medewerker deleteMedewerker);
        Task UpdateMedewerkerAsync (Medewerker updateMedewerker);
    }
}
