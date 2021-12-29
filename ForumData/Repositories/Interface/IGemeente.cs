using System.Collections.Generic;
using System.Threading.Tasks;
using ForumData.Models;

namespace ForumData.Repositories.Interface
{
    public interface IGemeente
    {
        Task <List<Gemeente>> GetGemeentesMet1FilterToListAsync(string filter);
        Task <Gemeente> GetGemeenteByIdAsync (int id);
    }
}
