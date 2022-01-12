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
        public async Task<Persoon> GetPersoonById(int Id)
        {
            return await persoonRepository.GetPersoonById(Id);
        }
    }
}
