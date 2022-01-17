using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumData.Entities;
using ForumData.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace ForumData.Repositories.DbConnect
{
    public class AdresRepository : IAdresRepository
    {
        private GemeenteForumDbContext context;
        public AdresRepository(GemeenteForumDbContext context) => this.context = context;

        public void AddAdres(Adres adres)
        {
            context.Adressen.Add(adres);
            context.SaveChanges();
        }
        public async Task<Adres> CheckAdresAsync(Straat straat, string huisNr, string busNr)
        {
            return await context.Adressen
                .Where(f => f.Straat == straat && f.HuisNr == huisNr && f.BusNr == busNr)
                .FirstOrDefaultAsync();
        }

        public Adres CheckAdres(Straat straat, string huisNr, string busNr)
        {
            return context.Adressen
                .Where(f => f.Straat == straat && f.HuisNr == huisNr && f.BusNr == busNr)
                .FirstOrDefault();
        }

        public List<Adres> GetAdressen()
        {
            return context.Adressen.ToList();
        }
    }
}
