﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ForumData.Entities;

namespace ForumData.Repositories.Interface
{
    public interface IInteresseRepository
    {
        Task <List<Interesse>> GetInteressesToListAsync();
    }
}
