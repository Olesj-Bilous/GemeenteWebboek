using ForumData.Entities;
using ForumData.Repositories.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ForumService
{
    public class ProfielInteresseService
    {
        //INJECTIE
        private IProfielInteresseRepository piRepo;
        public ProfielInteresseService(IProfielInteresseRepository piRepo) => this.piRepo = piRepo;

        //METHODS

    }
}
