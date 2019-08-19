using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Sistema.TSTOnline.Domain.Interfaces
{
    public interface IRepository<TEntity>
    {
        TEntity GetByID(int id);
        void Edit(TEntity entity);
        void Save(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int id);
        IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> expression);
        IEnumerable<TEntity> All();
    }
}