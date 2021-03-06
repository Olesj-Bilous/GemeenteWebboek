using ForumData.Entities;
using ForumData.Repositories.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumService
{
    public class TaalService
    {
        //INJECTIE     
        readonly private ITaalRepository taalRepository;
        public TaalService(ITaalRepository taalRepository) => this.taalRepository = taalRepository;

        //REPO METHODS
        public async Task<List<Taal>> GetTalenAsync()
        {
            return await taalRepository.GetTalenAsync();
        }

        public Taal GetTaalById(int id)
        {
            return taalRepository.GetTaalById(id);
        }

        public List<Taal> GetTalen()
        {
            return taalRepository.GetTalen();
        }

        //CUSTOM METHODS
        public Taal GetTaalByCode(string code)
        {
            return GetTalen().Where(t => t.TaalCode == code).FirstOrDefault();
        }
    }
}
