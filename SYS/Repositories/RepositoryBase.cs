using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SYS.Models;

namespace SYS.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected contextclass ContextClass { get; set; }

        public RepositoryBase(contextclass contextClass)
        {
            this.ContextClass = contextClass;
        }

        public IQueryable<T> FindAll()
        {
            return this.ContextClass.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.ContextClass.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.ContextClass.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.ContextClass.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.ContextClass.Set<T>().Remove(entity);
        }
    }
}

