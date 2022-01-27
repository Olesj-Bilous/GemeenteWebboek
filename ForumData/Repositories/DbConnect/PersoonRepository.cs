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

        //METHODS
        public async Task<Persoon> GetPersoonByIdAsync(int Id)
        {
            return await context.Personen.FindAsync(Id);
        }

        public async Task<Persoon> GetPersoonByLoginNaamAndPaswoordAsync(string naam, string pas)
        {
            return await context.Personen.Where(p => p.LoginNaam == naam && p.LoginPaswoord == pas).FirstOrDefaultAsync();
        }

        public async Task UpdatePersoonAsync(Persoon updatePersoon)
        {
            var existingPersoon = context.Personen.Find(updatePersoon.PersoonId);
            existingPersoon = updatePersoon;
            await context.SaveChangesAsync();




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
        }
    }
}
