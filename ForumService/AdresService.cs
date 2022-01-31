using ForumData.Entities;
using ForumData.Repositories.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumService
{
    public class AdresService
    {
        //INJECTION
        readonly private IAdresRepository adresRepository;
        public AdresService(IAdresRepository adresRepository) => this.adresRepository = adresRepository;

        //METHODS
        public async Task<Adres> CheckAdresAsync(Straat straat, string huisNr, string busNr)
        {
            return await adresRepository.CheckAdresAsync(straat, huisNr, busNr);
        }

        public List<Adres> GetAdressen()
        {
            return adresRepository.GetAdressen();
        }

        public void AddAdres(Adres adres)
        {
            adresRepository.AddAdres(adres);
        }

        public Adres CheckAdres(Straat straat, string huisNr, string busNr)
        {
            return adresRepository.CheckAdres(straat, huisNr, busNr);
        }

        public Adres GetOrCreateAndReturnAdres(Straat straat, string huisNr, string busNr)
        {
            Adres adres = CheckAdres(straat, huisNr, busNr);
            if (adres is null)
            {
                adres = new Adres { Straat = straat, HuisNr = huisNr, BusNr = busNr };
                AddAdres(adres);
            }
            return adres;
        }
    }
}
