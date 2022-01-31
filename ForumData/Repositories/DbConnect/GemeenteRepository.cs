using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumData.Entities;
using ForumData.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace ForumData.Repositories.DbConnect
{
    public class GemeenteRepository : IGemeenteRepository
    {
        readonly private GemeenteForumDbContext context;
        public GemeenteRepository(GemeenteForumDbContext context) => this.context = context;

        public List<Gemeente> GetGemeenten()
        {
            return context.Gemeenten.ToList();
        }

        public Gemeente GetGemeenteById(int id)
        {
            return context.Gemeenten.Find(id);
        }

        public async Task<Gemeente> GetGemeenteByIdAsync(int id)
        {
            return
                await context.Gemeenten.FindAsync(id);
        }

        public async Task<List<Gemeente>> GetGemeentesMet1FilterToListAsync(string filter)
        {
            return
                await context.Gemeenten.Where(f => f.GemeenteNaam.Contains(filter)).ToListAsync();
        }
    }
}
