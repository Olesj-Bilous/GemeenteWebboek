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

        public async Task <Persoon> GetPersoonById(int Id)
        {
            return await context.Personen.FindAsync(Id);
        }

        public Persoon GetPersoonByLoginNaamAndPaswoord(string naam, string pas)
        {
            return context.Personen.Where(p => p.LoginNaam == naam && p.LoginPaswoord == pas).FirstOrDefault();
        }
    }
}
