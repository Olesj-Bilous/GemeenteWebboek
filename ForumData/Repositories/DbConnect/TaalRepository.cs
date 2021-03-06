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
        readonly private GemeenteForumDbContext context;
        public TaalRepository(GemeenteForumDbContext context) => this.context = context;

        public async Task<List<Taal>> GetTalenAsync()
        {
            return await context.Talen.ToListAsync();
        }

        public Taal GetTaalById(int id)
        {
            return context.Talen.Find(id);
        }

        public List<Taal> GetTalen()
        {
            return context.Talen.ToList();
        }
    }
}
