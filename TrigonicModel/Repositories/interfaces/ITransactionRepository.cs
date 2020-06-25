using System;
using System.Collections.Generic;
using System.Text;
using TrigonicModel.Models;

namespace TrigonicModel.Repositories.interfaces
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        public IEnumerable<Transaction> GetInvestTransaction(int projectId, string investor);
        public IEnumerable<Transaction> GetProfitReturnTransactions(int projectId, string investor);
        public IEnumerable<Transaction> GetRevenueReturnTransactions(int projectId);

        public Transaction CreateInvestTransaction(int projectId, string investor, float investAmount);

        public Transaction CreateProfitReturn(int projectId, string investor, float amount);

        public Transaction CreateRevenueReturn(int projectId, string enterprise, float amount);
    }
}
