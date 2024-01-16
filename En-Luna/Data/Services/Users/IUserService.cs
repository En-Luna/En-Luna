using En_Luna.Data.Models;
using System.Linq.Expressions;

namespace En_Luna.Data.Services
{
    public interface IUserService : IBaseService<User>
    {
        /// <summary>
        /// Verifies the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public User Verify(User entity);
    }
}
