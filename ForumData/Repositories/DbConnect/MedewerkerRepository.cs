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
            await context.Personen.Add(nieuwMedewerker);
        }

        public async Task DeleteMedewerkerAsync(Medewerker deleteMedewerker)
        {
            await context.Personen.Remove(deleteMedewerker);
        }

        public async Task<Medewerker> GetMedewerkerOpPersoonIdAsync(int id)
        {
            return
                 await context.Personen.FindAsync(id);
        }

        public async Task UpdateMedewerkerAsync(Medewerker updateMedewerker)
        {
            return
                context.Personen.Update(updateMedewerker);
                await context.SaveChangesAsync();

        }
    }
}
