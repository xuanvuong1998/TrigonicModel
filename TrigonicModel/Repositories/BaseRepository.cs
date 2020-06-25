using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TrigonicModel.Models;

namespace TrigonicModel.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal DbContext dbContext;
        internal DbSet<TEntity> dbSet;

        public BaseRepository(DbContext context)
        {
            this.dbContext = context;
            this.dbSet = context.Set<TEntity>();
        }
      
        public TEntity Get(object id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, 
            string includeProperties = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var property in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }   
            }

            if (orderBy == null)
            {
                return query.ToList();
            }

            return orderBy(query);

        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }


        public void Add(TEntity newObj)
        {
            dbSet.Add(newObj);

        }

        public void Delete(TEntity objToDel)
        {
            dbSet.Remove(objToDel);

        }

        public void Update(TEntity curObj)
        {
            dbSet.Attach(curObj);

            dbContext.Entry(curObj).State = EntityState.Modified;

        }

    }
}
