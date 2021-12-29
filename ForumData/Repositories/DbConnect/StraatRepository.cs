using System.Collections.Generic;
using System.Threading.Tasks;
using ForumData.Models;
using ForumData.Repositories.Interface;

namespace ForumData.Repositories.DbConnect
{
    public class StraatRepository : IStraat
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
    }
}
