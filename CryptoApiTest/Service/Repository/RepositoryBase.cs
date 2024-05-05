using Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext;

        public RepositoryBase(RepositoryContext repositoryContext) => RepositoryContext = repositoryContext;
        /// <summary>
        /// Base function to find all records of a given entity
        /// </summary>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ? RepositoryContext.Set<T>().AsNoTracking()
                          : RepositoryContext.Set<T>();
        /// <summary>
        /// Base function to find records of a given entity by a condition
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ? RepositoryContext.Set<T>().Where(expression).AsNoTracking()
                          : RepositoryContext.Set<T>().Where(expression);
        /// <summary>
        /// Base function to create a new record of a given entity
        /// </summary>
        /// <param name="entity"></param>
        public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);
        /// <summary>
        /// Base function to update a record of a given entity
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);
        /// <summary>
        /// Base function to delete a record of a given entity
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);
    }
}
