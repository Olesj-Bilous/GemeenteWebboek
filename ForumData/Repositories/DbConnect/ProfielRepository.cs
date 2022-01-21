using System.Collections.Generic;
using System.Threading.Tasks;
using ForumData.Entities;
using ForumData.Repositories.Interface;

namespace ForumData.Repositories.DbConnect
{
    public class ProfielRepository : IProfielRepository
    {
        private GemeenteForumDbContext context;
        public ProfielRepository(GemeenteForumDbContext context) => this.context = context;

        //async
        public async Task AddProfielAsync(Profiel nieuwProfiel)
        {
            await context.Profielen.AddAsync(nieuwProfiel);
        }


        public async Task DeleteProfielAsync(Profiel deleteProfiel)
        {
            context.Profielen.Remove(deleteProfiel);
            await context.SaveChangesAsync();
        }

        public async Task<Profiel> GetProfielByPersoonIdAsync(int id)
        {
            return
                await context.Profielen.FindAsync(id);
        }

        public async Task UpdateProfielAsync(Profiel updateProfiel)
        {
                context.Profielen.Update(updateProfiel);
                await context.SaveChangesAsync();
        }

        //sync
        public void AddProfiel(Profiel profiel)
        {
            context.Profielen.Add(profiel);
            context.SaveChanges();
        }
        public Profiel GetProfielById(int id)
        {
            return context.Profielen.Find(id);
        }
    }
}
