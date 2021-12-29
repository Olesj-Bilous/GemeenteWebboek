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
            await context.BerichtTypes.Add(nieuwBerichtType);
        }

        public async Task DeleteBerichtTypeAsync(BerichtType deleteBerichtType)
        {
            await context.BerichtTypes.Remove(deleteBerichtType);
        }

        public async Task<BerichtType> GetBerichtTypeByIdAsync(int id)
        {
            return
                await context.BerichtTypes.FindAsync(id);
        }
    }
}
