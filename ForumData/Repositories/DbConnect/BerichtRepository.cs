using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumData.Entities;
using ForumData.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace ForumData.Repositories.DbConnect
{
    public class BerichtRepository : IBerichtRepository
    {
        readonly private GemeenteForumDbContext context;
        public BerichtRepository(GemeenteForumDbContext context) => this.context = context;

        public async Task<List<Bericht>> GetAllAsync() 
        {
            return await context.Berichten
                //.Include(b => b.Profiel)
                .ToListAsync();
        }

        public async Task<Bericht> GetByIdAsync(int id)
        {
            return await context.Berichten
                .Include(b => b.Profiel)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task AddAsync(Bericht bericht)
        {
            await context.Berichten.AddAsync(bericht);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Bericht bericht)
        {
            context.Berichten.Remove(bericht);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Bericht bericht)
        {
            context.Berichten.Update(bericht);
            await context.SaveChangesAsync();
        }
    }
}
