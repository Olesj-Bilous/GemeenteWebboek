using ForumData.Entities;
using ForumData.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumService
{
    public class BerichtService
    {
        //INJECTION
        readonly private IBerichtRepository berichtRepository;
        readonly private IHoofdBerichtRepository hoofdBerichtRepository;

        public BerichtService(IBerichtRepository berichtRepository,
            IHoofdBerichtRepository hoofdBerichtRepository)
        {
            this.berichtRepository = berichtRepository;
            this.hoofdBerichtRepository = hoofdBerichtRepository;
        }

        //general repo METHODS
        public async Task<Bericht> GetByIdAsync(int Id)
        {
            return await berichtRepository.GetByIdAsync(Id);
        }

        public async Task AddAsync(Bericht bericht)
        {
            await berichtRepository.AddAsync(bericht);
        }

        public async Task DeleteAsync(Bericht bericht)
        {
            await berichtRepository.DeleteAsync(bericht);
        }

        public async Task UpdateAsync(Bericht bericht)
        {
            await berichtRepository.UpdateAsync(bericht);
        }

        //hoofd repo methods
        public async Task<List<HoofdBericht>> GetAllHoofdAsync()
        {
            return await hoofdBerichtRepository.GetAllAsync();
        }

        //eigen methods
        public async Task<List<HoofdBericht>> GetAllHoofdByGemeenteIdAsync(int gemeenteId)
        {
            List<HoofdBericht> all = await GetAllHoofdAsync();
            return all
                .Where(hb => hb.Profiel.Adres.Straat.GemeenteId == gemeenteId)
                .OrderBy(hb => hb.BerichtTijdstip)
                .ToList();
        }
    }
}
