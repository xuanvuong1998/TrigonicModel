using System;
using System.Collections.Generic;

namespace TrigonicModel.Models
{
    public partial class InvestmentTerm
    {
        public InvestmentTerm()
        {
            Project = new HashSet<Project>();
        }

        public int Id { get; set; }
        public int TermTypeId { get; set; }
        public int Maturity { get; set; }
        public double MinRaiseGoal { get; set; }
        public double MaxRaiseGoal { get; set; }
        public double MinIndividualInvest { get; set; }
        public double AnualInvestRate { get; set; }
        public int PaymentPeriod { get; set; }

        public virtual TermType TermType { get; set; }
        public virtual ICollection<Project> Project { get; set; }
    }
}
