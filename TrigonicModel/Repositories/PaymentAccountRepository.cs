using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TrigonicModel.Models;
using TrigonicModel.Repositories.interfaces;

namespace TrigonicModel.Repositories
{
    public class PaymentAccountRepository : BaseRepository<PaymentAccount>, IPaymentAccountRepository
    {
        public PaymentAccountRepository(DbContext context) : base(context)
        {
            
        }
    }
}
