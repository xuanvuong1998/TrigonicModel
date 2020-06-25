using System;
using System.Collections.Generic;

namespace TrigonicModel.Models
{
    public partial class TeamMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public string AvatarImageUrl { get; set; }
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}
