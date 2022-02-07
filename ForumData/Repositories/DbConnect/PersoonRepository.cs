using ForumData.Entities;
using ForumData.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumData.Repositories.DbConnect
{
    public class PersoonRepository : IPersoonRepository
    {
        //INJECTIE
        readonly private GemeenteForumDbContext context;
        public PersoonRepository(GemeenteForumDbContext context) => this.context = context;

        //async METHODS
        public async Task<List<Persoon>> GetAllAsync()
        {
            return await context.Personen
                   .Include(p => p.Adres)
                       .ThenInclude(a => a.Straat)
                           .ThenInclude(s => s.Gemeente)
                    .ToListAsync();
        }

        public async Task<Persoon> GetPersoonByIdAsync(int id)
        {
            return await context.Personen
                .Include(p => p.Adres)
                    .ThenInclude(a => a.Straat)
                        .ThenInclude(s => s.Gemeente)
                .FirstOrDefaultAsync(p => p.PersoonId == id);
        }

        public async Task UpdatePersoonAsync(Persoon updatePersoon)
        {
            var existingPersoon = context.Personen.Find(updatePersoon.PersoonId);
            existingPersoon = updatePersoon;
            await context.SaveChangesAsync();
        }



            //if (existingPersoon != null)
            //{
            //    var attachedEntry = context.Entry(existingPersoon);
            //    attachedEntry.CurrentValues.SetValues(updatePersoon);
            //    await context.SaveChangesAsync();
            //}

            //context.Personen.Update(updatePersoon);
            //await context.SaveChangesAsync();




            ////context profiel ophalen
            //var existingProfiel = context.Profielen.Find(updateProfiel.PersoonId);

            //if (existingProfiel != null)
            //{
            //    //Context entry openzetten
            //    var attachedEntry = context.Entry(existingProfiel);
            //    //Context values plaatsn - opgepas met FK -> FK moet je meegeven
            //    attachedEntry.CurrentValues.SetValues(updateProfiel);
            //    //Context saven
            //    await context.SaveChangesAsync();

            //}
            //else
            //{
            //    throw new System.Exception("Update van het profiel is mislukt");
            //}
        public List<Persoon> GetAll()
        {
            return context.Personen.ToList();
        }
    }
}
