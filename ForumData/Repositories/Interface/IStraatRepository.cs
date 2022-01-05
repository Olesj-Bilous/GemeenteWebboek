using System.Collections.Generic;
using System.Threading.Tasks;
using ForumData.Entities;

namespace ForumData.Repositories.Interface
{
    public interface IStraatRepository
    {
        Task<List<Straat>> GetStratenMet2FiltersToListAsync(string filter1, string filter2);

    }
}
