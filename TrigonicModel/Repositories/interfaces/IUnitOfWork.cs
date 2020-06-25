using System;
using System.Collections.Generic;
using System.Text;

namespace TrigonicModel.Repositories.interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IProjectRepository Projects { get; }
        public IUserRepository Users { get; }
        public IPaymentAccountRepository PaymentAccounts { get; }
        public ITransactionRepository Transactions { get; }
        public ITermRepository InvestmentTerms { get; }
        public ITermTypeRepository TermTypes { get; }
        public IBonusRepository Bonuses { get; }
        public ITransactionBonusRepository TransactionBonuses { get; }
        public IProjectTeamRepository Teams { get; }

        public void Commit();
    }
}
