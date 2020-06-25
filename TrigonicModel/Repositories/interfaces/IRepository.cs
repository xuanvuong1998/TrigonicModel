using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace TrigonicModel.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(object id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                    string includeProperties = "");
   
        void Delete(TEntity objToDel);

        void Add(TEntity newObj);

        void Update(TEntity curObj);
    }
}
