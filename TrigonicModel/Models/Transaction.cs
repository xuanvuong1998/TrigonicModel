using System;
using System.Collections.Generic;

namespace TrigonicModel.Models
{
    public partial class Transaction
    {
        public Transaction()
        {
            TransactionBonus = new HashSet<TransactionBonus>();
        }

        public string Actor { get; set; }
        public int ProjectId { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string TransactionNumber { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }

        public virtual UserAccount ActorNavigation { get; set; }
        public virtual Project Project { get; set; }
        public virtual ICollection<TransactionBonus> TransactionBonus { get; set; }
    }
}
