using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Template.Model;

namespace Template.Repository
{
    public class GenericRepository<T> : IGenericRepository<T>
       where T : BaseEntity
    {
        protected DbContext _entities;
        protected readonly IDbSet<T> _dbset;

        public GenericRepository(DbContext context)
        {
            _entities = context;
            _dbset = context.Set<T>();
        }

        /// <summary>
        /// Get All the Entities
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll()
        {
            return _dbset.AsEnumerable<T>();
        }

        /// <summary>
        /// Find By a Condition / Filter
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            IEnumerable<T> query = _dbset.Where(predicate).AsEnumerable();
            return query;
        }

        /// <summary>
        /// Add a Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual T Add(T entity)
        {
            return _dbset.Add(entity);
        }

        /// <summary>
        /// Delete a Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual T Delete(T entity)
        {

            _entities.Set<T>().Remove(entity);
            _entities.Entry(entity).State = EntityState.Deleted;
            //_dbset.Remove(entity);
            _entities.SaveChanges();

            return entity;
        }

        /// <summary>
        /// Edit a Entity
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Edit(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;

        }


        /// <summary>
        /// Save a Entity
        /// </summary>
        public virtual void Save()
        {
            _entities.SaveChanges();
        }
    }
}
