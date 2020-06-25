using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TrigonicModel.Models;
using TrigonicModel.Repositories.interfaces;

namespace TrigonicModel.Repositories
{
    class ProjectTeamRepository : BaseRepository<TeamMember>, IProjectTeamRepository
    {
        public ProjectTeamRepository(DbContext context) : base(context)
        {
        }
    }
}
