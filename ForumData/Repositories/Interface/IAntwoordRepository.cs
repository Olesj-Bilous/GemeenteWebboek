using ForumData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumData.Repositories.Interface
{
    public interface IAntwoordRepository
    {
        Task<Antwoord> GetByIdAsync(int id);
    }
}
