using System.Collections.Generic;
using System.Threading.Tasks;
using ForumData.Models;

namespace ForumData.Repositories.Interface
{
    public interface IStraat
    {
        Task<List<Straat>> GetStratenMet2FiltersToListAsync(string filter1, string filter2);

    }
}
