using System.Collections.Generic;
using System.Threading.Tasks;
using ForumData.Entities;

namespace ForumData.Repositories.Interface
{
    public interface ITaalRepository
    {
        Task<List<Taal>> GetTalenAsync();

        List<Taal> GetTalen();
    }
}
