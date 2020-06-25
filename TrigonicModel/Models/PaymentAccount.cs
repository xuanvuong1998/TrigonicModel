using System;
using System.Collections.Generic;

namespace TrigonicModel.Models
{
    public partial class PaymentAccount
    {
        public PaymentAccount()
        {
            UserAccount = new HashSet<UserAccount>();
        }

        public int Id { get; set; }
        public string OwnerName { get; set; }
        public string AccountNumber { get; set; }
        public int Type { get; set; }

        public virtual ICollection<UserAccount> UserAccount { get; set; }
    }
}
