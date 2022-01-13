using ForumData.Entities;
using ForumData.Repositories.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ForumService
{
    public class PersoonService
    {
        //INJECTIE
        private IPersoonRepository persoonRepository;
        public PersoonService(IPersoonRepository persoonRepository) => this.persoonRepository = persoonRepository;

        //METHODS
        public async Task<Persoon> GetPersoonByIdAsync(int Id)
        {
            return await persoonRepository.GetPersoonByIdAsync(Id);
        }

        public async Task UpdatePersoonAsync(Persoon updatePersoon)
        {
            await persoonRepository.UpdatePersoonAsync(updatePersoon);
        }

       public Persoon GetPersoonByLoginNaamAndPaswoord(string naam, string pas)
        {
            return persoonRepository.GetPersoonByLoginNaamAndPaswoord(naam, pas);
        }
    }
}
