using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SamTech.ExpenseTrack.Data
{
    public interface IRepository<TEntity, TKey, TContext>
        where TEntity : class, IEntity<TKey>
        where TContext : DbContext
    {
        void Add(TEntity entity);
        void Edit(TEntity entityToUpdate);
        void Remove(TKey id);
        void Remove(TEntity entityToDelete);
        TEntity GetById(TKey id);
        IList<TEntity> GetAll();
        int GetCount(Expression<Func<TEntity, bool>> filter = null);
    }
}
