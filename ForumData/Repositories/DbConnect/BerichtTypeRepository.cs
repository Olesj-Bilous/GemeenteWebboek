using System.Threading.Tasks;
using ForumData.Entities;
using ForumData.Repositories.Interface;

namespace ForumData.Repositories.DbConnect
{
    public class BerichtTypeRepository: IBerichtTypeRepository
    {
        private GemeenteForumDbContext context;
        public BerichtTypeRepository(GemeenteForumDbContext context) => this.context = context;


        public async Task AddBerichtTypeAsync(BerichtThema nieuwBerichtType)
        {
            await context.BerichtTypes.AddAsync(nieuwBerichtType);
        }

        public async Task DeleteBerichtTypeAsync(BerichtThema deleteBerichtType)
        {
           context.BerichtTypes.Remove(deleteBerichtType);
            await context.SaveChangesAsync();
        }

        public async Task<BerichtThema> GetBerichtTypeByIdAsync(int id)
        {
            return
                await context.BerichtTypes.FindAsync(id);
        }
    }
}
