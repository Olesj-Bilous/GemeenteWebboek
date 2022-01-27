using System.Collections.Generic;
using System.Threading.Tasks;
using ForumData.Entities;
namespace ForumData.Repositories.Interface
{
    public interface IBerichtThemaRepository
    {
        //async
        Task<BerichtThema> GetBerichtThemaByIdAsync (int id);
        Task AddBerichtThemaAsync (BerichtThema nieuwBerichtThema);
        Task DeleteBerichtThemaAsync (BerichtThema deleteBerichtThema);

        //sync
        List<BerichtThema> GetAll();
    }
}
