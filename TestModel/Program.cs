using Microsoft.EntityFrameworkCore;
using System;
using TrigonicModel;
using TrigonicModel.Models;
using TrigonicModel.Repositories;
using TrigonicModel.Repositories.interfaces;

namespace TestModel
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnitOfWork unitOfWork = new UnitOfWork(new TrigonicContext());

            var term = new InvestmentTerm
            {
                Maturity = 48,
            };

            var type = new TermType
            {
                Id = 213,
                Desp = "this is a new tyupe",
                Name = "HX_SHARING"
            };

            unitOfWork.InvestmentTerms.Add(term);
            unitOfWork.TermTypes.Add(type);
            
            try
            {
                unitOfWork.Commit();

                term.TermTypeId = type.Id;

                unitOfWork.InvestmentTerms.Update(term);

                Console.WriteLine(  term.Id + " " + term.TermTypeId);

            }
            catch (DbUpdateException ex)
            {
                Console.Write(ex.InnerException.Message);
            }

            unitOfWork.Dispose();

        }
    }
}
