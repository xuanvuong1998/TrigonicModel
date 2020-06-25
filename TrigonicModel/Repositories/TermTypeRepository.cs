using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TrigonicModel.Models;
using TrigonicModel.Repositories.interfaces;

namespace TrigonicModel.Repositories
{
    public class TermTypeRepository : BaseRepository<TermType>, ITermTypeRepository
    {
        public TermTypeRepository(DbContext context) : base(context)
        {
        }
    }
}
