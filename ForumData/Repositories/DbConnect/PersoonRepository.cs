using ForumData.Entities;
using ForumData.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumData.Repositories.DbConnect
{
    public class PersoonRepository : IPersoonRepository
    {
        private GemeenteForumDbContext context;
        public PersoonRepository(GemeenteForumDbContext context) => this.context = context;
        public List<Persoon> GetAll()
        {
            return context.Personen.ToList();
        }
    }
}
