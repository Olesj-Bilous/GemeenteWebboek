﻿using ForumData.Entities;
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
        private GemeenteForumDbContext context;
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
            context.Personen.Update(updatePersoon);
            await context.SaveChangesAsync();
        }
    }
}
