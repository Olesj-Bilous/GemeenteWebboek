using ForumData.Entities;
using ForumData.Repositories.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForumService
{
    public class MedewerkerService
    {
        //INJECTIE    
        private IMedewerkerRepository medewerkerRepository;
        public MedewerkerService(IMedewerkerRepository medewerkerRepository) => this.medewerkerRepository = medewerkerRepository;

        //METHODS
        public async Task<Medewerker> GetMedewerkerOpPersoonIdAsync(int Id)
        {
            return await medewerkerRepository.GetMedewerkerOpPersoonIdAsync(Id);
        }

        public async Task AddMedewerkerAsync(Medewerker nieuwMedewerker)
        {
            await medewerkerRepository.AddMedewerkerAsync(nieuwMedewerker);
        }

        public async Task DeleteMederwerkerAsync (Medewerker deleteMedewerker)
        {
            await medewerkerRepository.DeleteMedewerkerAsync(deleteMedewerker);
        }

        public async Task UpdateMedewerkerAsync (Medewerker updateMedewerker)
        {
            await medewerkerRepository.UpdateMedewerkerAsync(updateMedewerker);
        }

    }
}
