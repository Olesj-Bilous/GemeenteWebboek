using System.Collections.Generic;
using System.Threading.Tasks;
using ForumData.Models;

namespace ForumData.Repositories.Interface
{
    public interface ITaal
    {
        Task<List<Taal>> GetTalenToListAsync();
    }
}
