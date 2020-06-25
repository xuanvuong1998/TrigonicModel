using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TrigonicModel.Models;
using TrigonicModel.Repositories.interfaces;

namespace TrigonicModel.Repositories
{
    public class BonusRepository : BaseRepository<ProjectBonus>, IBonusRepository
    {
        public BonusRepository(DbContext context) : base(context)
        {
        }
    }
}
