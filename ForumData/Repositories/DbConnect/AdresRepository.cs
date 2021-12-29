using System.Threading.Tasks;
using ForumData.Models;
using ForumData.Repositories.Interface;

namespace ForumData.Repositories.DbConnect
{
    public class AdresRepository : IAfdeling
    {
        private GemeenteForumDbContext context;
        public AdresRepository(GemeenteForumDbContext context) => this.context = context;


        public async Task<Adres> CheckAdresAsync(string straat, string huisNr, string busNr)
        {
            return
                await context.Adressen.AsNoTracking()
                .Where(f => f.Straat.StraatNaam == straat && f.HuisNr == huisnr && f.BusNr == busnr)
                .FirstOrDefault();
        }
    }
}
