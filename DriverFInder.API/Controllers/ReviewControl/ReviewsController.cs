using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Domain.RepositoryContracts.IReviewRepo;
using DriverFinder.Core.DTO.ReviewDTO;
using DriverFinder.Core.ServicesContracts.IReviewServices;
using DriverFinder.Core.Validation.ReviewValidation;
using DriverFinder.Infrastructure.ApplicationContext;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DriverFinder.UI.Controllers.ReviewControl
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _ReviewService;
        private readonly ReviewRequestValidation _RequestValidation;
        private readonly ReviewUpdateRequestValidation _UpdateRequestValidation;

        public ReviewsController(IReviewService ReviewService , ReviewRequestValidation RequestValidation , ReviewUpdateRequestValidation UpdateRequestValidation)
        {
            _ReviewService = ReviewService;
            _RequestValidation = RequestValidation;
            _UpdateRequestValidation = UpdateRequestValidation;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reviews>>> GetReview()
        {
            var Reviews= await _ReviewService.GetReviews();
            if (!Reviews.IsSuccess)
            {
                return Problem(Reviews.ErrorMessage);
            }
            return Ok(Reviews.Data);
        }
        [HttpGet("GetSchoolReviews/{SchoolID}")]
        public async Task<ActionResult<IEnumerable<Reviews>>> GetSchoolReviews(Guid SchoolID)
        {
            var Reviews= await _ReviewService.GetSchoolReviews(SchoolID);
            if (!Reviews.IsSuccess)
            {
                return Problem(Reviews.ErrorMessage);
            }
            return Ok(Reviews.Data);
        }

        [HttpGet("GetReview/{ReviewID}")]
        public async Task<ActionResult<Reviews>> GetReviews(Guid ReviewID)
        {
            var Reviews = await _ReviewService.GetReview(ReviewID);
            if (!Reviews.IsSuccess)
            {
                return Problem(Reviews.ErrorMessage);
            }
            return Ok(Reviews.Data);
        }

        [HttpPut]
        public async Task<IActionResult> PutReviews( ReviewUpdateRequest Updatereview)
        {
            var ValidationResult =await _UpdateRequestValidation.ValidateAsync(Updatereview);
            if (!ValidationResult.IsValid)
            {
                return Problem(string.Join('\n',ValidationResult.Errors.Select(e => e.ErrorMessage)));
            }
            var result=await _ReviewService.UpdateReview(Updatereview);
            if (!result.IsSuccess)
            {
                return Problem(result.ErrorMessage);
            }
            return Ok(result.Data);
        }
        [HttpPut("{ReviewID}")]
        public async Task<IActionResult> UpdateHelpFullReview(Guid ReviewID)
        {
            
            var result=await _ReviewService.UpdateHelpFullReview(ReviewID);
            if (!result.IsSuccess)
            {
                return Problem(result.ErrorMessage);
            }
            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<ActionResult<Reviews>> PostReviews(ReviewRequest ReviewRequest)
        {
            var ValidationResult = await _RequestValidation.ValidateAsync(ReviewRequest);
            if (!ValidationResult.IsValid)
            {
                return Problem(string.Join('\n', ValidationResult.Errors.Select(e => e.ErrorMessage)));
            }
            var result = await _ReviewService.AddReview(ReviewRequest);
            if (!result.IsSuccess)
            {
                return Problem(result.ErrorMessage);
            }
            return Ok(result.Data);
        }
        
        [HttpDelete("{ReviewID}")]
        public async Task<IActionResult> DeleteReviews(Guid ReviewID)
        {
            var result = await _ReviewService.DeleteReview(ReviewID);
            if (!result.IsSuccess)
            {
                return Problem(result.ErrorMessage);
            }
            return Ok(result.Data);
        }

     
    }
}
