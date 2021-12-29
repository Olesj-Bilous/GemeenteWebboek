using System.Collections.Generic;
using System.Threading.Tasks;
using ForumData.Models;
using ForumData.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace ForumData.Repositories.DbConnect
{
    public class TaalRepository : ITaal
    {
        private GemeenteForumDbContext context;
        public TaalRepository(GemeenteForumDbContext context) => this.context = context;

        public async Task<List<Taal>> GetTalenToListAsync()
        {
            return
               await context.Talen.ToListAsync();
        }
    }
}
