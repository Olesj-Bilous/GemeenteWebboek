using System.Collections.Generic;
using System.Threading.Tasks;
using ForumData.Models;
using ForumData.Repositories.Interface;

namespace ForumData.Repositories.DbConnect
{
    public class MedewerkerRepository: IMedewerker
    {
        private GemeenteForumDbContext context;
        public MedewerkerRepository(GemeenteForumDbContext context) => this.context = context;

        public async Task AddMedewerkerAsync(Medewerker nieuwMedewerker)
        {
            await context.Personen.AddAsync(nieuwMedewerker);
        }

        public async Task DeleteMedewerkerAsync(Medewerker deleteMedewerker)
        {
            context.Personen.Remove(deleteMedewerker);
            await context.SaveChangesAsync();
        }

        public async Task<Medewerker> GetMedewerkerOpPersoonIdAsync(int id)
        {
            return
                 await context.Personen.FindAsync(id);
        }

        public async Task UpdateMedewerkerAsync(Medewerker updateMedewerker)
        {
                context.Personen.Update(updateMedewerker);
                await context.SaveChangesAsync();

        }
    }
}
