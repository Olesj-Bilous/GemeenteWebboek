using System.Collections.Generic;
using System.Threading.Tasks;
using ForumData.Entities;
namespace ForumData.Repositories.Interface
{
    public interface IProvincieRepository
    {
        Task <List<Provincie>> GetProvinciesToListAsync ();
    }
}
