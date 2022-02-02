using ForumData.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForumData.Repositories.Interface
{
    public interface IBerichtRepository
    {
        Task<List<Bericht>> GetAllAsync();
        Task<Bericht> GetByIdAsync(int id);
        Task AddAsync(Bericht bericht);
        Task DeleteAsync (Bericht bericht);
        Task UpdateAsync (Bericht bericht);
    }
}
