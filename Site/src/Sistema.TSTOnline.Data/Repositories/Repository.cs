using Microsoft.EntityFrameworkCore;
using Sistema.TSTOnline.Domain.Interfaces;
using Sistema.TSTOnline.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Sistema.TSTOnline.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DataBaseContext _dbContext;

        public Repository(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual TEntity GetByID(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public virtual void Edit(TEntity entity)
        {
            _dbContext.Set<TEntity>().Attach(entity);
        }

        public virtual void Save(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            TEntity entity = GetByID(id);
            Delete(entity);
        }

        public virtual IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
        {
            return _dbContext.Set<TEntity>().Where(expression).ToList();
        }

        public virtual IEnumerable<TEntity> All()
        {
            var query = _dbContext.Set<TEntity>();

            if (query.Any())
                return query.ToList();

            return new List<TEntity>();
        }

        private string ApplyList(string sql, ListParameter parameter)
        {
            if (parameter.Value == null)
            {
                if (sql.Contains(parameter.ParameterName))
                    throw new ArgumentException($"O parâmetro {parameter.ParameterName} está presente na query sql, porém recebeu um valor nulo");
            }
            else
            {
                if (!(parameter.Value is IEnumerable<int> list))
                    throw new ArgumentException($"[SqlListParameter] O parâmetro '{parameter.ParameterName}' deve ser compatível com IEnumerable<int>");

                var joinedListItems = string.Join(",", list);

                sql = sql.Replace(parameter.ParameterName, joinedListItems);
            }

            return sql;
        }

        public IQueryable<TEntity> FromSql(string sql/*, params object[] parameters*/)
        {
            //var listParameters = parameters.Where(n => n.GetType() == typeof(ListParameter)).ToArray();
            //sql = listParameters.Aggregate(sql, (dbSql, parameter) => ApplyList(dbSql, parameter as ListParameter));
            //parameters = parameters.Where(n => n.GetType() != typeof(ListParameter)).ToArray();

            //return _dbContext.Set<TEntity>().FromSql(sql, parameters);
            return _dbContext.Set<TEntity>().FromSql(sql);
        }
    }
}