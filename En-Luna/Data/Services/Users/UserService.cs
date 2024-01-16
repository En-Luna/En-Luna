using En_Luna.Data.Models;
using En_Luna.Extensions;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System.Linq.Expressions;

namespace En_Luna.Data.Services
{
    /// <inheritdoc />
    public class UserService : IUserService
    {
        private readonly ApplicationContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UserService(ApplicationContext context)
        {
            _context = context;
        }

        public User Create(User entity)
        {
            var userName = $"{entity.FirstName.Substring(0, 1)}{entity.LastName}";

            var possibleDuplicateUsernames = _context.Users.Where(x => x.UserName != null && x.UserName.Contains(userName)).ToList();

            // if we have an account with the generated username
            if (possibleDuplicateUsernames.Any(x => x.UserName != null && x.UserName.RemoveDigits().Equals(userName)))
            {
                // get a count of how many accounts have the same user name
                int count = _context.Users.Count(x => x.UserName != null && x.UserName.RemoveDigits().Equals(userName));

                // append the count + 1 to the username
                userName += count + 1;
            }

            return entity;
        }

        /// <inheritdoc />
        public virtual User Delete(User entity)
        {
            entity.IsDeleted = true;
            _context.Users.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        /// <inheritdoc />
        public virtual User? Get(Expression<Func<User, bool>> predicate)
        {
            return _context.Users.Where(predicate).FirstOrDefault();
        }

        public User? Get<TProperty>(Expression<Func<User, TProperty>> include, Expression<Func<User, bool>> predicate)
        {
            return _context.Users.Include(include).Where(predicate).FirstOrDefault();
        }

        public User? Get(string navigationalPath, Expression<Func<User, bool>> predicate)
        {
            return _context.Users.Include(navigationalPath).Where(predicate).FirstOrDefault();
        }

        /// <inheritdoc />
        public virtual ICollection<User> List()
        {
            return _context.Users.ToList();
        }

        /// <inheritdoc />
        public virtual ICollection<User> List(Expression<Func<User, bool>> predicate)
        {
            return _context.Users.Where(predicate).ToList();
        }

        public ICollection<User> List<TProperty>(Expression<Func<User, TProperty>> include, Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public virtual User Update(User entity)
        {
            _context.Users.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        /// <inheritdoc />
        public User Verify(User entity)
        {
            entity.IsVerified = true;
            _context.Users.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
