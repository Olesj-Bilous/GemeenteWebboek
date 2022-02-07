using ForumData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumData.Repositories.Interface
{
    public interface IPersoonRepository
    {
        //async
        Task<List<Persoon>> GetAllAsync();
        Task <Persoon> GetPersoonByIdAsync(int Id);
        Task UpdatePersoonAsync(Persoon updatePersoon);

        //sync
        //Persoon GetById(int id);
        public List<Persoon> GetAll();
    }
}
