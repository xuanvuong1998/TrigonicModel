using System;
using System.Collections.Generic;
using System.Text;
using TrigonicModel.Models;

namespace TrigonicModel.Repositories.interfaces
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        public IEnumerable<Transaction> GetInvestTransaction(int projectId, string investor);
        public IEnumerable<Transaction> GetProjectInvesment(int projectId);

        
        public IEnumerable<Transaction> GetProfitReturnTransactions(int projectId, string investor);
        public double GetTotalProfitReturned(int projectId, string investor);
        
        public IEnumerable<Transaction> GetRevenueReturnTransactions(int projectId);

        public IEnumerable<ProjectBonus> GetInvestorsBonuses(string investor, int projectId);

        public IEnumerable<Project> GetInvestedProjects(string investor);

        public Transaction CreateInvestTransaction(int projectId, string investor, double investAmount);

        public Transaction CreateProfitReturn(int projectId, string investor, double amount);

        public Transaction CreateRevenueReturn(int projectId, string enterprise, double amount);
    }
}
