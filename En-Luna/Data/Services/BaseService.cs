using En_Luna.Data.Models;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System.Linq.Expressions;

namespace En_Luna.Data.Services
{
    /// <inheritdoc />
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        protected ApplicationContext _context;

        public BaseService(ApplicationContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public virtual T Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        /// <inheritdoc />
        public virtual T Delete(T entity)
        {
            entity.IsDeleted = true;
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return entity;
        }

        /// <inheritdoc />
        public virtual T? Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).FirstOrDefault();
        }

        public virtual T? Get<TProperty>(Expression<Func<T, TProperty>> include, Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Include(include).Where(predicate).FirstOrDefault();
        }

        public virtual T? Get(string navigationalPath, Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Include(navigationalPath).Where(predicate).FirstOrDefault();
        }

        /// <inheritdoc />
        public virtual ICollection<T> List()
        {
            return _context.Set<T>().ToList();
        }

        /// <inheritdoc />
        public virtual ICollection<T> List(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public virtual ICollection<T> List<TProperty>(Expression<Func<T, TProperty>> include, Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Include(include).Where(predicate).ToList();
        }

        /// <inheritdoc />
        public virtual T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
