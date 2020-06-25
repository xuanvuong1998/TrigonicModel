using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TrigonicModel.Models;
using TrigonicModel.Repositories.interfaces;

namespace TrigonicModel.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _dbContext;
        
        public UnitOfWork(DbContext context)
        {
            _dbContext = context;
            Projects = new ProjectRepository(context);
            Users = new UserRepository(context);
            PaymentAccounts = new PaymentAccountRepository(context);
            TransactionBonuses = new TransactionBonusRepository(context);
            Transactions = new TransactionRepository(context);
            InvestmentTerms = new ProjectTermsRepository(context);
            TermTypes = new TermTypeRepository(context);
            Bonuses = new BonusRepository(context);
            Teams = new ProjectTeamRepository(context);
        }

        public IProjectRepository Projects { get; private set; }

        public IUserRepository Users { get; private set; }

        public IPaymentAccountRepository PaymentAccounts { get; private set; }

        public ITransactionRepository Transactions { get; private set; }

        public ITermRepository InvestmentTerms { get; private set; }

        public ITermTypeRepository TermTypes { get; private set; }

        public IBonusRepository Bonuses { get; private set; }

        public IProjectTeamRepository Teams { get; private set; }

        public ITransactionBonusRepository TransactionBonuses { get; private set; }

        public void Commit()
        {
            try
            {
                _dbContext.SaveChanges();

            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            
        }
            
        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
