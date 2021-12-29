using System.Threading.Tasks;
using ForumData.Models;
using ForumData.Repositories.Interface;

namespace ForumData.Repositories.DbConnect
{
    public class BerichtTypeRepository: IBerichtType
    {
        private GemeenteForumDbContext context;
        public BerichtTypeRepository(GemeenteForumDbContext context) => this.context = context;


        public async Task AddBerichtTypeAsync(BerichtType nieuwBerichtType)
        {
            await context.BerichtTypes.AddAsync(nieuwBerichtType);
        }

        public async Task DeleteBerichtTypeAsync(BerichtType deleteBerichtType)
        {
           context.BerichtTypes.Remove(deleteBerichtType);
            await context.SaveChangesAsync();
        }

        public async Task<BerichtType> GetBerichtTypeByIdAsync(int id)
        {
            return
                await context.BerichtTypes.FindAsync(id);
        }
    }
}
