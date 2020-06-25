using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TrigonicModel.Models;
using TrigonicModel.Repositories.interfaces;

namespace TrigonicModel.Repositories
{

    class ProjectTermsRepository : BaseRepository<InvestmentTerm>, ITermRepository
    {
        public ProjectTermsRepository(DbContext context) : base(context)
        {

        }
    }
}
