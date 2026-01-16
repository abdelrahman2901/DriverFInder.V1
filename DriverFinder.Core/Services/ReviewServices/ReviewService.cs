using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.Domain.RepositoryContracts.IReviewRepo;
using DriverFinder.Core.DTO.ReviewDTO;
using DriverFinder.Core.ServicesContracts.IReviewServices;

namespace DriverFinder.Core.Services.ReviewServices
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepo;
        public ReviewService(IReviewRepository reviewRepo)
        {
            _reviewRepo = reviewRepo;
        }
        public async Task<Result<IEnumerable<ReviewResponse>>> GetSchoolReviews(Guid SchoolID)
        {
            var Reviews = await _reviewRepo.GetSchoolReviews(SchoolID);
            //if (!Reviews.Any())
            //{
            //    return Result<IEnumerable<ReviewResponse>>.Failure("no Reviews For School Found.");
            //}
            return Result<IEnumerable<ReviewResponse>>.Success(Reviews.Select(r => r.ToReviewResponse()));
        }
        

    
        public async Task<Result<IEnumerable<ReviewResponse>>> GetReviews()
        {
            var Reviews = await _reviewRepo.GetReviews();
            if (!Reviews.Any())
            {
                return Result<IEnumerable<ReviewResponse>>.Failure("no Reviews Found.");
            }
            return Result<IEnumerable<ReviewResponse>>.Success(Reviews.Select(r => r.ToReviewResponse()));
        }

        public async Task<Result<ReviewResponse?>> GetReview(Guid id)
        {
            var review = await _reviewRepo.GetReview(id);
            if (review == null)
            {
                return Result<ReviewResponse?>.Failure("Review Doesnt Exists");
            }
            return Result<ReviewResponse?>.Success(review.ToReviewResponse());

        }

        public async Task<Result<ReviewResponse?>> AddReview(ReviewRequest review)
        {
            var NewReview = await _reviewRepo.AddReview(review.ToReviews());
            if (NewReview == null)
            {
                return Result<ReviewResponse?>.Failure("Failed To Add Review");
            }
            return Result<ReviewResponse?>.Success(NewReview.ToReviewResponse());
        }
        public async Task<Result<ReviewResponse?>> UpdateHelpFullReview(Guid ReviewID)
        {
            var review = await _reviewRepo.GetReview(ReviewID);
            if (review == null)
            {
                return Result<ReviewResponse?>.Failure("Review Doesnt Exists");
            }
            review.helpFullReviewCount=review.helpFullReviewCount++;
            var result = await _reviewRepo.UpdateReview(review);
            if (result == null)
            {
                return Result<ReviewResponse?>.Failure("Failed To Update Review");
            }
            return Result<ReviewResponse?>.Success(review.ToReviewResponse());

        }

        public async Task<Result<ReviewResponse?>> UpdateReview(ReviewUpdateRequest reviews)
        {
            var review = await _reviewRepo.GetReview(reviews.ReviewID);
            if (review == null)
            {
                return Result<ReviewResponse?>.Failure("Review Doesnt Exists");
            }
            var result= await _reviewRepo.UpdateReview(review);
            if (result == null)
            {
                return Result<ReviewResponse?>.Failure("Failed To Update Review");
            }
            return Result<ReviewResponse?>.Success(review.ToReviewResponse());

        }
        public async Task<Result<bool>> DeleteReview(Guid ReviewID)
        {
            var review = await _reviewRepo.GetReview(ReviewID);
            if (review == null)
            {
                return Result<bool>.Failure("Review Doesnt Exists");
            }
            var result = await _reviewRepo.DeleteReview(review);
            if (!result)
            {
                return Result<bool>.Failure("Failed to Delete Review");
            }
            return Result<bool>.Success(result);
        }

        
    }
}
