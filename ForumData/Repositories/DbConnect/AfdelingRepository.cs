using System.Threading.Tasks;
using ForumData.Entities;
using ForumData.Repositories.Interface;

namespace ForumData.Repositories.DbConnect
{
    public class AfdelingRepository : IAfdelingRepository
    {
        private GemeenteForumDbContext context;
        public AfdelingRepository(GemeenteForumDbContext context) => this.context = context;

        public async Task<Afdeling> GetAfdelingByIdAsync(int id)
        {
            return
                await context.Afdelingen.FindAsync(id);
        }
    }
}
