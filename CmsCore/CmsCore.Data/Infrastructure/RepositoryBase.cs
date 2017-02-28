using CmsCore.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CmsCore.Data.Infrastructure
{
    public abstract class RepositoryBase<T> where T : BaseEntity
    {
        #region Properties
        private ApplicationDbContext dataContext;
        private readonly DbSet<T> dbSet;

        

        protected ApplicationDbContext DbContext
        {
            get { return dataContext; }
        }
        #endregion

        protected RepositoryBase(ApplicationDbContext dbContext)
        {
            dataContext = dbContext;
            dbSet = DbContext.Set<T>();
        }

        #region Implementation
        public virtual void Add(T entity)
        {
            var date = DateTime.Now;
            entity.AddedBy = "username";
            entity.AddedDate = date;
            entity.ModifiedBy = "username";
            entity.ModifiedDate = date;
            dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            entity.ModifiedBy = "username";
            entity.ModifiedDate = DateTime.Now;
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbSet.Remove(obj);
        }

        public virtual T GetById(long id, params string[] navigations)
        {
            var set = dbSet.AsQueryable();
            foreach (string nav in navigations)
                set = set.Include(nav);

            return set.FirstOrDefault(f => f.Id == id);
        }

        public virtual IEnumerable<T> GetAll(params string[] navigations)
        {
            var set = dbSet.AsQueryable();
            foreach (string nav in navigations)
                set = set.Include(nav);
            return set.AsEnumerable();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where, params string[] navigations)
        {
            var set = dbSet.AsQueryable();
            foreach (string nav in navigations)
                set = set.Include(nav);
            return set.Where(where).AsEnumerable();
        }

        public T Get(Expression<Func<T, bool>> where, params string[] navigations)
        {
            var set = dbSet.AsQueryable();
            foreach (string nav in navigations)
                set = set.Include(nav);
            return set.Where(where).FirstOrDefault<T>();
        }

        #endregion

    }
}
