using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumData.Entities;
using ForumData.Repositories.Interface;

namespace ForumData.Repositories.DbConnect
{
    public class BerichtThemaRepository: IBerichtThemaRepository
    {
        private GemeenteForumDbContext context;
        public BerichtThemaRepository(GemeenteForumDbContext context) => this.context = context;

        //async
        public async Task AddBerichtThemaAsync(BerichtThema nieuwBerichtThema)
        {
            await context.BerichtThemas.AddAsync(nieuwBerichtThema);
        }

        public async Task DeleteBerichtThemaAsync(BerichtThema deleteBerichtThema)
        {
           context.BerichtThemas.Remove(deleteBerichtThema);
            await context.SaveChangesAsync();
        }

        public async Task<BerichtThema> GetBerichtThemaByIdAsync(int id)
        {
            return
                await context.BerichtThemas.FindAsync(id);
        }

        //sync
        public List<BerichtThema> GetAll()
        {
            return context.BerichtThemas.ToList();
        }
    }
}
