using ForumData.Entities;
using ForumData.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumData.Repositories.DbConnect
{
    public class AntwoordRepository : IAntwoordRepository
    {
        readonly private GemeenteForumDbContext context;
        public AntwoordRepository(GemeenteForumDbContext context) => this.context = context;
        public async Task<Antwoord> GetByIdAsync(int id)
        {
            return await context.Antwoorden
                .Include(a => a.Profiel)
                .Include(a => a.HoofdBericht)
                    .ThenInclude(hb => hb.Profiel)
                .Include(a => a.HoofdBericht)
                    .ThenInclude(hb => hb.BerichtThema)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
