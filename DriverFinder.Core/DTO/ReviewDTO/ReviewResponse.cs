using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DriverFinder.Core.DTO.ReviewDTO
{
    public class ReviewResponse
    {
        public Guid ReviewID { get; set; }
        public Guid UserID { get; set; }
        public Guid SchoolID { get; set; }
        public Guid InstructorID { get; set; }
        public short SchoolRating { get; set; }
        public short InstructorRating { get; set; }
        public string? SchoolReviewDescription { get; set; }
        public string? InstructorReviewDescription { get; set; }
        public string UserName { get; set; }
        public int helpFullReviewCount { get; set; }
        public DateTime ReviewDate { get; set; }
    }
    public static class ReviewResponseEXtensions
    {
        public static ReviewResponse ToReviewResponse(this Reviews review)
        {
            return new ReviewResponse()
            {
                ReviewID = review.ReviewID,
                UserID = review.UserID,
                SchoolID = review.SchoolID,
                InstructorID = review.InstructorID,
                SchoolRating = review.SchoolRating,
                InstructorRating = review.InstructorRating,
                SchoolReviewDescription = review.SchoolReviewDescription,
                InstructorReviewDescription = review.InstructorReviewDescription,
                UserName = review.UserName,
                ReviewDate = review.ReviewDate,
                helpFullReviewCount = review.helpFullReviewCount,
            };
        }
    }
}
