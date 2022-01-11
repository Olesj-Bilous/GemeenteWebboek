using System.Threading.Tasks;
using ForumData.Entities;
namespace ForumData.Repositories.Interface
{
    public interface IAdresRepository
    {
        Task<Adres> CheckAdresAsync (string straat, string huisNr, string busNr);
    }
}
