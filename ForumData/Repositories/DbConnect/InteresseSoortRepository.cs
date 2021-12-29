using System.Collections.Generic;
using System.Threading.Tasks;
using ForumData.Models;
using ForumData.Repositories.Interface;

namespace ForumData.Repositories.DbConnect
{
    public class InteresseSoortRepository : IInteresseSoort
    {
        private GemeenteForumDbContext context;
        public InteresseSoortRepository(GemeenteForumDbContext context) => this.context = context;

        public async Task<List<InteresseSoort>> GetInteresseSoortenToListAsync()
        {
            return
                 await context.InteresseSoorten.ToListAsync();
        }
    }
}
