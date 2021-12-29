using System.Threading.Tasks;
using ForumData.Models;

namespace ForumData.Repositories.Interface
{
    public interface IAfdeling
    {
        Task<Adres> CheckAdresAsync (string straat, string huisNr, string busNr);

    }
}
