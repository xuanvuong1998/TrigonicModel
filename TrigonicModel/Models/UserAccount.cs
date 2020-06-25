using System;
using System.Collections.Generic;

namespace TrigonicModel.Models
{
    public partial class UserAccount
    {
        public UserAccount()
        {
            Project = new HashSet<Project>();
            Transaction = new HashSet<Transaction>();
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Role { get; set; }
        public string Address { get; set; }
        public int? PaymentId { get; set; }

        public virtual PaymentAccount Payment { get; set; }
        public virtual ICollection<Project> Project { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
