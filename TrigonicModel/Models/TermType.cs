using System;
using System.Collections.Generic;

namespace TrigonicModel.Models
{
    public partial class TermType
    {
        public TermType()
        {
            InvestmentTerm = new HashSet<InvestmentTerm>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Desp { get; set; }

        public virtual ICollection<InvestmentTerm> InvestmentTerm { get; set; }
    }
}
