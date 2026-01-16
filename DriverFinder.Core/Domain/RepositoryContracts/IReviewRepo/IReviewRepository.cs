using DriverFinder.Core.Domain.Entites;
 

namespace DriverFinder.Core.Domain.RepositoryContracts.IReviewRepo
{
    public interface IReviewRepository
    {
        public Task<IEnumerable<Reviews>> GetReviews();
        public Task<IEnumerable<Reviews>> GetSchoolReviews(Guid SchoolID);
        public Task<Reviews?> GetReview(Guid id);
        public Task<Reviews?> UpdateReview(Reviews reviews);
        public Task<Reviews?> AddReview(Reviews reviews);
        public Task<bool> DeleteReview(Reviews Review);
        public Task<bool> ReviewsExists(Guid id);
    }
}
