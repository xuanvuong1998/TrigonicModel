﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrigonicModel.Models;
using TrigonicModel.Repositories.interfaces;

namespace TrigonicModel.Repositories
{
    class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        private BaseRepository<TransactionBonus> _trancBonusRepo;
        public TransactionRepository(DbContext context) : base(context)
        {
            _trancBonusRepo = new TransactionBonusRepository(context);
        }


        public IEnumerable<ProjectBonus> GetInvestorsBonuses(string investor, int projectId)
        {
            var list = Get(x => x.ProjectId == projectId
                        && x.Actor == investor
                        && x.Type == (int)TransactionType.INVEST
                        && x.Status == (int)TransactionStatus.SUCCESS,
                            null, null);

            var tranc = list.SingleOrDefault();

            if (tranc == null) return null;

            return _trancBonusRepo.Get(
                    x => x.TransactionNumber == tranc.TransactionNumber,
                    null,
                    "Bonus"
                ).Select(x => x.Bonus);

        }

        public IEnumerable<Project> GetInvestedProjects(string investor)
        {
            var list = Get(x => x.Actor == investor
                    && x.Type == (int)TransactionType.INVEST
                    && x.Status == (int)TransactionStatus.SUCCESS,
                    null, "Project");

            return list.Select(x => x.Project);
        }

        private IEnumerable<Transaction> GetByType(
                               string actor, int projectId, int type)
        {
            return Get(x => x.Type == type
                        && x.ProjectId == projectId
                        && (actor == null || x.Actor == actor)
                        && x.Status == (int)TransactionStatus.SUCCESS,
                        null, null);
        }

        public IEnumerable<Transaction> GetInvestTransaction(int projectId, string investor)
        {
            return GetByType(investor, projectId, (int)TransactionType.INVEST);
        }

        public IEnumerable<Transaction> GetProfitReturnTransactions(int projectId, string investor)
        {
            return GetByType(investor, projectId, (int)TransactionType.INVEST_PROFIT_RETURN);
        }

        public IEnumerable<Transaction> GetRevenueReturnTransactions(int projectId)
        {
            return GetByType(null, projectId, (int)TransactionType.REVENUE_RETURN);
        }

        #region Setters

        private string GenerateTransactionNumber()
        {
            int length = 50;

            Random rand = new Random();
            string res = "";

            do
            {
                for (int i = 0; i < length; i++)
                {
                    res += (char)rand.Next(0, 10);
                }
            } while (Get(res) != null);

            return res;            
        }
        private Transaction CreateNewTransaction(int projectId, string actor, float amount, TransactionType type)
        {
            var obj = new Transaction
            {
                ProjectId = projectId,
                Actor = actor,
                Amount = amount,
                Type = (int)type,
                Date = DateTime.Now,
                Status = (int)TransactionStatus.SUCCESS,
                TransactionNumber = GenerateTransactionNumber()
            };

            Add(obj);

            return obj;
        }
        public Transaction CreateInvestTransaction(int projectId, string investor, float investAmount)
        {
            return CreateNewTransaction(projectId, investor, investAmount, TransactionType.INVEST);
        }

        public Transaction CreateProfitReturn(int projectId, string investor, float amount)
        {
            return CreateNewTransaction(projectId, investor, amount, TransactionType.INVEST_PROFIT_RETURN);

        }

        public Transaction CreateRevenueReturn(int projectId, string enterprise, float amount)
        {
            return CreateNewTransaction(projectId, enterprise, amount, TransactionType.REVENUE_RETURN);
        }


        #endregion
    }
}