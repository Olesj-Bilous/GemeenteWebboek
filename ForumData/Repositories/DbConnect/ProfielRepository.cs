using System.Collections.Generic;
using System.Threading.Tasks;
using ForumData.Models;
using ForumData.Repositories.Interface;

namespace ForumData.Repositories.DbConnect
{
    public class ProfielRepository : IProfiel
    {
        private GemeenteForumDbContext context;
        public ProfielRepository(GemeenteForumDbContext context) => this.context = context;

        public async Task AddProfielAsync(Profiel nieuwProfiel)
        {
            await context.Personen.Add(nieuwProfiel);
        }

        public async Task DeleteProfielAsync(Profiel deleteProfiel)
        {
            await context.Personen.Remove(deleteProfiel);
        }

        public async Task<Profiel> GetProfielByPersoonAsync(int id)
        {
            return
                await context.Personen.FindAsync(id);
        }

        public async Task UpdateProfielAsync(Profiel updateProfiel)
        {
            return
                context.Personen.Update(updateProfiel);
                context.SaveChangesAsync();
        }
    }
}
