using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.DTO.ReviewDTO;

namespace DriverFinder.Core.ServicesContracts.IReviewServices
{
    public interface IReviewService
    {
        public Task<Result<IEnumerable<ReviewResponse>>> GetReviews();
        public Task<Result<IEnumerable<ReviewResponse>>> GetSchoolReviews(Guid SchoolID);
        public Task<Result<ReviewResponse?>> GetReview(Guid id);
        public Task<Result<ReviewResponse?>> UpdateReview(ReviewUpdateRequest review);
        public Task<Result<ReviewResponse?>> UpdateHelpFullReview(Guid reviewID);
        public Task<Result<ReviewResponse?>> AddReview(ReviewRequest reviews);
        public Task<Result<bool>> DeleteReview(Guid ReviewID);
    }
}
