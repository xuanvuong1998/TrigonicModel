using System;
using System.Collections.Generic;

namespace TrigonicModel.Models
{
    public partial class ProjectBonus
    {
        public ProjectBonus()
        {
            TransactionBonus = new HashSet<TransactionBonus>();
        }

        public int ProjectId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string BonusDesc { get; set; }
        public int AvaiableQty { get; set; }

        public virtual Project Project { get; set; }
        public virtual ICollection<TransactionBonus> TransactionBonus { get; set; }
    }
}
