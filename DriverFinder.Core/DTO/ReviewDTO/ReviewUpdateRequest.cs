namespace DriverFinder.Core.DTO.ReviewDTO
{
    public class ReviewUpdateRequest
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
}
