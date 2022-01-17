using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumData.Entities;
using ForumData.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace ForumData.Repositories.DbConnect
{
    public class StraatRepository : IStraatRepository
    {
        private GemeenteForumDbContext context;
        public StraatRepository(GemeenteForumDbContext context) => this.context = context;

        public async Task<List<Straat>> GetStratenMet2FiltersToListAsync(string filter1, string filter2)
        {
            return
                await context.Straten
                .Where(f => f.Gemeente.GemeenteNaam.Contains(filter1) && f.StraatNaam.Contains(filter2))
                .ToListAsync();
        }

        public Straat GetStraatById(int id)
        {
            return context.Straten.Find(id);
        }

        public List<Straat> GetStraten()
        {
            return context.Straten.ToList();
        }
    }
}
