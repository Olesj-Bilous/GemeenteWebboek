using System.Collections.Generic;
using System.Threading.Tasks;
using ForumData.Models;
using ForumData.Repositories.Interface;

namespace ForumData.Repositories.DbConnect
{
    public class ProvincieRepository :IProvincie
    {
        private GemeenteForumDbContext context;
        public ProvincieRepository(GemeenteForumDbContext context) => this.context = context;

        public async Task<List<Provincie>> GetProvinciesToListAsync(int id)
        {
            return
                await context.Provincies.ToListAsync();
        }
    }
}
