using ForumData.Entities;
using ForumData.Repositories.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ForumService
{
    public class ProfielInteresseService
    {
        //INJECTIE
        private IProfielInteresseRepository piRepo;
        public ProfielInteresseService(IProfielInteresseRepository piRepo) => this.piRepo = piRepo;

        //sync repo METHODS
        public List<ProfielInteresse> GetAll()
        {
            return piRepo.GetAll();
        }

        public ProfielInteresse GetById(int id)
        {
            return piRepo.GetById(id);
        }

        public void Delete(ProfielInteresse pi)
        {
            piRepo.Delete(pi);
        }

        public void AddRange(List<ProfielInteresse> profielInteresses)
        {
            piRepo.AddRange(profielInteresses);
        }

        public void UpdateRange(List<ProfielInteresse> profielInteresses)
        {
            piRepo.UpdateRange(profielInteresses);
        }

        //sync services
        public void DeleteById(int id)
        {
            Delete(GetById(id));
        }

        public ProfielInteresse GetByProfielIdAndInteresseId(int profielId, int interesseId)
        {
            return GetAll().Where(pi => pi.ProfielId == profielId && pi.InteresseId == interesseId).FirstOrDefault();
        }
    }
}
