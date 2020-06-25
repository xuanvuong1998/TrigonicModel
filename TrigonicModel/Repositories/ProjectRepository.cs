using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrigonicModel.Models;
using TrigonicModel.Repositories.interfaces;

namespace TrigonicModel.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(DbContext context) : base(context)
        {
            
        }

        public TrigonicContext Context
        {
            get
            {
                return dbContext as TrigonicContext;
            }
        }

        #region Getters

     
        public Project GetFullInfo(int projectId)
        {
            return Context.Project
                    .Where(x => x.Id == projectId)
                    .Include(x => x.CreatorNavigation)
                    .Include(x => x.Term)
                    .Include(x => x.TeamMember)
                    .Include(x => x.ProjectBonus)
                    .SingleOrDefault();
        }

        public IEnumerable<Project> GetProjectsByStatus(string status)
        {
            var stt = -1;

            try
            {
                stt = (int) Enum.Parse(typeof(ProjectStatus), status);
            }
            catch (Exception)
            {
                return null;
            }
            
            return Get(x => (stt == -1 || x.Status == stt), null, null);
        }

        public IEnumerable<Project> GetProjectsOfUser(string username)
        {
            return Get(x => x.Creator == username, null, null);
        }

        public bool UpdateProjectInfomation(string projectId, string highlight, string location, string model)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Setters


        #endregion

    }
}
