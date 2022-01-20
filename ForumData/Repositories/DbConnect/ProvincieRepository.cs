using System.Collections.Generic;
using System.Threading.Tasks;
using ForumData.Entities;
using ForumData.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace ForumData.Repositories.DbConnect
{
    public class ProvincieRepository :IProvincieRepository
    {
        readonly private GemeenteForumDbContext context;
        public ProvincieRepository(GemeenteForumDbContext context) => this.context = context;

        public async Task<List<Provincie>> GetProvinciesToListAsync()
        {
            return
                await context.Provincies.ToListAsync();
        }
    }
}
