using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumData.Models;
using ForumData.Repositories.Interface;

namespace ForumData.Repositories.DbConnect
{
    public class GemeenteRepository : IGemeente
    {
        private GemeenteForumDbContext context;
        public GemeenteRepository(GemeenteForumDbContext context) => this.context = context;

        public async Task<Gemeente> GetGemeenteByIdAsync(int id)
        {
            return
                await context.Gemeenten.FindAsync(id);
        }

        public async Task<List<Gemeente>> GetGemeentesMet1FilterToListAsync(string filter)
        {
            return
                await context.Gemeenten
                .Where(f => f.GemeenteNaam.Contains(filter)).ToListAsync();
        }
    }
}
