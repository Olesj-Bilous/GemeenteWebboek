using System.Threading.Tasks;
using ForumData.Models;

namespace ForumData.Repositories.Interface
{
    public interface IMedewerker
    {
        Task<Medewerker> GetMedewerkerOpPersoonIdAsync (int id);
        Task AddMedewerkerAsync (Medewerker nieuwMedewerker);
        Task DeleteMedewerkerAsync (Medewerker deleteMedewerker);
        Task UpdateMedewerkerAsync (Medewerker updateMedewerker);
    }
}
