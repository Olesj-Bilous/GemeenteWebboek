using ForumData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumData.Repositories.Interface
{
    public interface IHoofdBerichtRepository
    {
        Task<List<HoofdBericht>> GetAllAsync();
    }
}
