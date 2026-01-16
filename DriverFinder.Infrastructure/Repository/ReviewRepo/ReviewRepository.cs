using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Domain.RepositoryContracts.IReviewRepo;
using DriverFinder.Infrastructure.ApplicationContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DriverFinder.Infrastructure.Repository.ReviewRepo
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<ReviewRepository> _logger;
        public ReviewRepository(ApplicationDBContext context, ILogger<ReviewRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IEnumerable<Reviews>> GetReviews()
        {
            return await _context.Review.AsNoTracking().ToListAsync();
        }

        public async Task<Reviews?> GetReview(Guid id)
        {
            return await _context.Review.AsNoTracking().FirstOrDefaultAsync(i=>i.ReviewID==id);
        }

        public async Task<Reviews?> UpdateReview(Reviews reviews)
        {
            try
            {
                _context.Review.Update(reviews);
                await _context.SaveChangesAsync();
                return reviews;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                if (ex.InnerException != null)
                {
                    _logger.LogError(ex.InnerException.Message);
                }
                return null;
            }

        }

        public async Task<Reviews?> AddReview(Reviews reviews)
        {
            try
            {
                _context.Review.Add(reviews);
                await _context.SaveChangesAsync();
                return reviews;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                if (ex.InnerException != null)
                {
                    _logger.LogError(ex.InnerException.Message);
                }
                return null;
            }

        }

        public async Task<bool> DeleteReview(Reviews reviews)
        {
            try
            {
                _context.Review.Remove(reviews);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                if (ex.InnerException != null)
                {
                    _logger.LogError(ex.InnerException.Message);
                }
                return false;
            }

        }

        public async Task<bool> ReviewsExists(Guid id)
        {
            return await _context.Review.AnyAsync(e => e.ReviewID == id);
        }

        public async Task<IEnumerable<Reviews>> GetSchoolReviews(Guid SchoolID)
        {
            return await _context.Review.Where(i => i.SchoolID == SchoolID).ToListAsync();
        }
    }
}
