using System.Collections.Generic;
using System.Threading.Tasks;
using ForumData.Entities;
namespace ForumData.Repositories.Interface
{
    public interface IGemeenteRepository
    {
        List<Gemeente> GetGemeenten();
        Gemeente GetGemeenteById(int id);
        Task<List<Gemeente>> GetGemeentesMet1FilterToListAsync(string filter);
        Task<Gemeente> GetGemeenteByIdAsync (int id);
    }
}
