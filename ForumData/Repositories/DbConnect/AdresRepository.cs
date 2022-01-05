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


        public async Task<Adres> CheckAdresAsync(string straat, string huisNr, string busNr)
        {
            return
                await context.Adressen
                .Where(f => f.Straat.StraatNaam == straat && f.HuisNr == huisNr && f.BusNr == busNr)
                .FirstOrDefaultAsync();
        }
    }
}
