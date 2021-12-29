using System.Collections.Generic;
using System.Threading.Tasks;
using ForumData.Models;

namespace ForumData.Repositories.Interface
{
    public interface IProvincie
    {
        Task <List<Provincie>> GetProvinciesByIdToListAsync (int id);
    }
}
