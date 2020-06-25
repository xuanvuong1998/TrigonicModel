using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TrigonicModel.Models;
using TrigonicModel.Repositories.interfaces;

namespace TrigonicModel.Repositories
{
    public class UserRepository : BaseRepository<UserAccount>, IUserRepository
    {
        private DbContext _dbContext;
        
        public UserRepository(DbContext context) : base(context)
        {
            _dbContext = context;
        }

    }
}
