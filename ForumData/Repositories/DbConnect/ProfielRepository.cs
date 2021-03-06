using System.Collections.Generic;
using System.Threading.Tasks;
using ForumData.Entities;
using ForumData.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace ForumData.Repositories.DbConnect
{
    public class ProfielRepository : IProfielRepository
    {
        readonly private GemeenteForumDbContext context;
        public ProfielRepository(GemeenteForumDbContext context) => this.context = context;

        //async
        public async Task AddProfielAsync(Profiel nieuwProfiel)
        {
            await context.Profielen.AddAsync(nieuwProfiel);
        }


        public async Task DeleteProfielAsync(Profiel deleteProfiel)
        {
            context.Profielen.Remove(deleteProfiel);
            await context.SaveChangesAsync();
        }

        public async Task<List<Profiel>> GetAllAsync()
        {
            return await context.Profielen.ToListAsync();
        }

        public async Task<Profiel> GetProfielByPersoonIdAsync(int id)
        {
            return
                await context.Profielen.Include(p => p.Adres).ThenInclude(p => p.Straat).FirstOrDefaultAsync(p => p.PersoonId == id);
        }

        public async Task UpdateProfielAsync(Profiel updateProfiel)
        {

            //context profiel ophalen
            var existingProfiel = context.Profielen.Find(updateProfiel.PersoonId);

            if(existingProfiel != null)
            {
                //Context entry openzetten
                var attachedEntry = context.Entry(existingProfiel);
                //Context values plaatsn - opgepas met FK -> FK moet je meegeven
                attachedEntry.CurrentValues.SetValues(updateProfiel);
                //Context saven
                await context.SaveChangesAsync();

            }
            else
            {
                throw new System.Exception("Update van het profiel is mislukt");
            }

        }

        //sync
        public void AddProfiel(Profiel profiel)
        {
            context.Profielen.Add(profiel);
            context.SaveChanges();
        }
        public Profiel GetProfielById(int id)
        {
            return context.Profielen.Find(id);
        }
    }
}
