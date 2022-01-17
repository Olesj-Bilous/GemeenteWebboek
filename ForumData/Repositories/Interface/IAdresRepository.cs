using System.Collections.Generic;
using System.Threading.Tasks;
using ForumData.Entities;
namespace ForumData.Repositories.Interface
{
    public interface IAdresRepository
    {
        Task<Adres> CheckAdresAsync (Straat straat, string huisNr, string busNr);
        void AddAdres(Adres adres);
        Adres CheckAdres(Straat straat, string huisNr, string busNr);
        List<Adres> GetAdressen();
    }
}
