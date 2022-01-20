using ForumData.Entities;
using ForumData.Repositories.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForumService
{
    public class AdresService
    {
        //INJECTION
        readonly private IAdresRepository adresRepository;
        public AdresService(IAdresRepository adresRepository) => this.adresRepository = adresRepository;

        //METHODS
        public async Task<Adres> CheckAdresAsync(string straat, string huisNr, string busNr)
        {
            return await adresRepository.CheckAdresAsync(straat, huisNr, busNr);
        }
    }
}
