using En_Luna.Data.Models;

namespace En_Luna.Data.Services
{
    /// <inheritdoc />
    public class ReviewService : BaseService<Review>, IReviewService
    {
        public ReviewService(ApplicationContext context) : base(context)
        {
        }
    }
}
