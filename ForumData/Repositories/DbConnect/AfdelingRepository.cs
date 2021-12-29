using System.Threading.Tasks;
using ForumData.Models;
using ForumData.Repositories.Interface;

namespace ForumData.Repositories.DbConnect
{
    public class AfdelingRepository : IAfdeling
    {
        private GemeenteForumDbContext context;
        public AfdelingRepository(GemeenteForumDbContext context) => this.context = context;

        public Task<Afdeling> GetAfdelingByIdAsync(int id)
        {
            return
                await context.Afdelingen.FindAsync(id);
        }
    }
}
