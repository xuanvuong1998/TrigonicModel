using System;
using System.Collections.Generic;

namespace TrigonicModel.Models
{
    public partial class TransactionBonus
    {
        public int Id { get; set; }
        public int BonusId { get; set; }
        public string TransactionNumber { get; set; }

        public virtual ProjectBonus Bonus { get; set; }
        public virtual Transaction TransactionNumberNavigation { get; set; }
    }
}
