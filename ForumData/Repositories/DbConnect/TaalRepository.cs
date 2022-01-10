using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumData.Entities;
using ForumData.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace ForumData.Repositories.DbConnect
{
    public class TaalRepository : ITaalRepository
    {
        private GemeenteForumDbContext context;
        public TaalRepository(GemeenteForumDbContext context) => this.context = context;

        public async Task<List<Taal>> GetTalenAsync()
        {
            return await context.Talen.ToListAsync();
        }

        public List<Taal> GetTalen()
        {
            return context.Talen.ToList();
        }
    }
}
