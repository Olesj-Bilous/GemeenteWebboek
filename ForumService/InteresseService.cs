using ForumData.Entities;
using ForumData.Repositories.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForumService
{
    public class InteresseService
    {
        //INJECTIE
        readonly private IInteresseRepository interesseRepository;
        public InteresseService(IInteresseRepository interesseRepository) => this.interesseRepository = interesseRepository;

        //METHODS
        public async Task <List<Interesse>> GetInteressesToListAsync()
        {
            return await interesseRepository.GetInteressesToListAsync();
        }

        public Interesse GetById(int id)
        {
            return interesseRepository.GetById(id);
        }

        public List<Interesse> GetInteresses()
        {
            return interesseRepository.GetInteresses();
        }
    }
}
