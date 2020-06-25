using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TrigonicModel.Models;
using TrigonicModel.Repositories.interfaces;

namespace TrigonicModel.Repositories
{
    public class TransactionBonusRepository : BaseRepository<TransactionBonus>, ITransactionBonusRepository
    {
        public TransactionBonusRepository(DbContext context) : base(context)
        {
        }

       
    }
}
