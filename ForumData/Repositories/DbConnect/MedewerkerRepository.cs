using System.Collections.Generic;
using System.Threading.Tasks;
using ForumData.Entities;
using ForumData.Repositories.Interface;

namespace ForumData.Repositories.DbConnect
{
    public class MedewerkerRepository: IMedewerkerRepository
    {
        readonly private GemeenteForumDbContext context;
        public MedewerkerRepository(GemeenteForumDbContext context) => this.context = context;

        public async Task AddMedewerkerAsync(Medewerker nieuwMedewerker)
        {
            await context.Medewerkers.AddAsync(nieuwMedewerker);
        }

        public async Task DeleteMedewerkerAsync(Medewerker deleteMedewerker)
        {
            context.Medewerkers.Remove(deleteMedewerker);
            await context.SaveChangesAsync();
        }

        public async Task<Medewerker> GetMedewerkerOpPersoonIdAsync(int id)
        {
            return await context.Medewerkers.FindAsync(id);
        }

        public async Task UpdateMedewerkerAsync(Medewerker updateMedewerker)
        {
                context.Medewerkers.Update(updateMedewerker);
                await context.SaveChangesAsync();

        }
    }
}
