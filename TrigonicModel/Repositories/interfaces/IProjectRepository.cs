using System;
using System.Collections.Generic;
using System.Text;
using TrigonicModel.Models;

namespace TrigonicModel.Repositories.interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        public Project GetFullInfo(int projectId);

        public IEnumerable<Project> GetProjectsByStatus(string status);

        public IEnumerable<Project> GetProjectsOfUser(string username);

        
      
    }
}
