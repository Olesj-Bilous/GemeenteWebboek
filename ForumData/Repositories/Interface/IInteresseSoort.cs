using System.Collections.Generic;
using System.Threading.Tasks;
using ForumData.Models;

namespace ForumData.Repositories.Interface
{
    public interface IInteresseSoort
    {
        Task <List<InteresseSoort>> GetInteresseSoortenToListAsync();
    }
}
