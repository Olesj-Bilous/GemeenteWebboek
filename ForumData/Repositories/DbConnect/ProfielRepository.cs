﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ForumData.Entities;
using ForumData.Repositories.Interface;

namespace ForumData.Repositories.DbConnect
{
    public class ProfielRepository : IProfielRepository
    {
        readonly private GemeenteForumDbContext context;
        public ProfielRepository(GemeenteForumDbContext context) => this.context = context;

        public async Task AddProfielAsync(Profiel nieuwProfiel)
        {
            await context.Profielen.AddAsync(nieuwProfiel);
        }

        public async Task DeleteProfielAsync(Profiel deleteProfiel)
        {
            context.Profielen.Remove(deleteProfiel);
            await context.SaveChangesAsync();
        }

        public async Task<Profiel> GetProfielByPersoonIdAsync(int id)
        {
            return
                await context.Profielen.FindAsync(id);
        }

        public async Task UpdateProfielAsync(Profiel updateProfiel)
        {
            context.Profielen.Update(updateProfiel);
            //var update = context.Profielen.Attach(updatePorfiel)
            //update.state = Mircrosoft.EntityFrameworkCore.EntityState.Modified;
            //Wat is het verschil? Wat is beter?
            await context.SaveChangesAsync();
        }
    }
}
