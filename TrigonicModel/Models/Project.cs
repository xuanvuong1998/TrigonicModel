using System;
using System.Collections.Generic;

namespace TrigonicModel.Models
{
    public partial class Project
    {
        public Project()
        {
            ProjectBonus = new HashSet<ProjectBonus>();
            TeamMember = new HashSet<TeamMember>();
            Transaction = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public int TermId { get; set; }
        public string Creator { get; set; }
        public int RaiseDuration { get; set; }
        public double CurRaisedAmount { get; set; }
        public int Status { get; set; }
        public string BusinessModel { get; set; }
        public string LocationAnalysis { get; set; }
        public string Hightlights { get; set; }
        public string ImageUrl { get; set; }

        public virtual UserAccount CreatorNavigation { get; set; }
        public virtual InvestmentTerm Term { get; set; }
        public virtual ICollection<ProjectBonus> ProjectBonus { get; set; }
        public virtual ICollection<TeamMember> TeamMember { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
