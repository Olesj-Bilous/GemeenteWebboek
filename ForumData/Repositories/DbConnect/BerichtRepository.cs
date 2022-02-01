using System.Threading.Tasks;
using ForumData.Entities;
using ForumData.Repositories.Interface;

namespace ForumData.Repositories.DbConnect
{
    public class BerichtRepository : IBerichtRepository
    {
        readonly private GemeenteForumDbContext context;
        public BerichtRepository(GemeenteForumDbContext context) => this.context = context;

        public async Task AddBerichtAsync(Bericht newBericht)
        {
            await context.Berichten.AddAsync(newBericht);
            await context.SaveChangesAsync();
        }

        public async Task DeleteBerichtAsync(Bericht deleteBericht)
        {
            context.Berichten.Remove(deleteBericht);
            await context.SaveChangesAsync();
        }

        public async Task<Bericht> GetBerichtByIdAsync(int id)
        {
            return await context.Berichten.FindAsync(id);
        }

        public async Task UpdateBerichtAsync(Bericht aangepastBericht)
        {
            context.Berichten.Update(aangepastBericht);
            await context.SaveChangesAsync();
        }
    }
}
