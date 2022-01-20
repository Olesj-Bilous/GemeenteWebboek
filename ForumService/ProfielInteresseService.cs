using ForumData.Entities;
using ForumData.Repositories.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ForumService
{
    public class ProfielInteresseService
    {
        //INJECTIE
        readonly private IProfielInteresse profielInteresse;
        public ProfielInteresseService(IProfielInteresse profielInteresse) => this.profielInteresse = profielInteresse;

        //METHODS

    }
}
