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
    public class HoofdBerichtRepository : IHoofdBerichtRepository
    {
        readonly private GemeenteForumDbContext context;
        public HoofdBerichtRepository(GemeenteForumDbContext context) => this.context = context;

        public async Task<List<HoofdBericht>> GetAllAsync()
        {
            return await context.HoofdBerichten
                .Include(hb => hb.Profiel)
                //.ThenInclude(p => p.Adres)
                //    .ThenInclude(a => a.Straat)
                //        .ThenInclude(s => s.Gemeente)
                .Include(hb => hb.BerichtThema)
                .Include(hb => hb.ChildAntwoorden)
                .ToListAsync();
        }

        public async Task<HoofdBericht> GetByIdAsync(int id)
        {
            return await context.HoofdBerichten
                .Include(hb => hb.Profiel)
                //.ThenInclude(p => p.Adres)
                //    .ThenInclude(a => a.Straat)
                //        .ThenInclude(s => s.Gemeente)
                .Include(hb => hb.BerichtThema)
                //.Include(hb => hb.ChildAntwoorden)
                .FirstOrDefaultAsync(hb => hb.Id == id);
        }
    }
}
