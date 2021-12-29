using System.Threading.Tasks;
using ForumData.Models;
using ForumData.Repositories.Interface;

namespace ForumData.Repositories.DbConnect
{
    public class BerichtRepository : IBericht
    {
        private GemeenteForumDbContext context;
        public BerichtRepository(GemeenteForumDbContext context) => this.context = context;
   

        public async Task AddBerichtAsync(Bericht newBericht)
        {
            await context.Berichten.Add(newBericht);
        }

        public async Task DeleteBerichtAsync(IBericht deleteBericht)
        {
            await context.Berichten.Remove(deleteBericht);
        }

        public async Task<Bericht> GetBerichtByIdAsync(int id)
        {
            return
                await context.Berichten.FindAsync(id);
        }

        public async Task UpdateBerichtAsync(IBericht aangepastBericht)
        {
            context.Berichten.Update(aangepastBericht);
            await context.SaveChangesAsync();
        }
    }
}
