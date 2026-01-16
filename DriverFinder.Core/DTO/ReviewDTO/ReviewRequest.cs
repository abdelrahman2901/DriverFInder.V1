using DriverFinder.Core.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace DriverFinder.Core.DTO.ReviewDTO
{
    public class ReviewRequest
    {
        public Guid UserID { get; set; }
        public Guid SchoolID { get; set; }
        public Guid InstructorID { get; set; }
        public short SchoolRating { get; set; }
        public short InstructorRating { get; set; }
        public string? SchoolReviewDescription { get; set; }
        public string? InstructorReviewDescription { get; set; }
        public string UserName { get; set; }

        public Reviews ToReviews()
        {
            return new Reviews()
            {
                ReviewID = Guid.NewGuid(),
                UserID = UserID,
                SchoolID = SchoolID,
                InstructorID = InstructorID,
                SchoolRating = SchoolRating,
                InstructorRating = InstructorRating,
                SchoolReviewDescription = SchoolReviewDescription,
                InstructorReviewDescription = InstructorReviewDescription,
                UserName = UserName,
                ReviewDate = DateTime.Now,
                helpFullReviewCount = 0,
            };
        }
    }
}
