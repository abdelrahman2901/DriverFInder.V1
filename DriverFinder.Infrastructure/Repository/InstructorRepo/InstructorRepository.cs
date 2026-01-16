using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Domain.RepositoryContracts.IInstructorRepo;
using DriverFinder.Core.DTO.InstructorDTO;
using DriverFinder.Infrastructure.ApplicationContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DriverFinder.Infrastructure.Repository.InstructorRepo
{
    public class InstructorRepository : IInsturctorRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<InstructorRepository> _logger;
        public InstructorRepository(ApplicationDBContext context, ILogger<InstructorRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<DrivingInstructors>> GetDrivingInstructors()
        {
            return await _context.DrivingInstructors.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<DrivingInstructors>> GetDrivingInstructorsForSchool(Guid SchoolID)
        {
            return await _context.DrivingInstructors.AsNoTracking().Where(i => i.SchoolID == SchoolID).ToListAsync();
        }

        public async Task<DrivingInstructors?> GetInstructor(Guid InstructorID)
        {
            return await _context.DrivingInstructors.AsNoTracking().Where(i => i.InstructorID == InstructorID).FirstOrDefaultAsync();
        }

        public async Task<DrivingInstructors?> AddDrivingInstructors(DrivingInstructors drivingInstructors)
        {
            try
            {
                await _context.DrivingInstructors.AddAsync(drivingInstructors);
                await _context.SaveChangesAsync();
                return drivingInstructors;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error adding driving instructor: {ex.Message}");
                return null;
            }
        }
        public async Task<DrivingInstructors?> UpdateDrivingInstructors(DrivingInstructors UpdateInstructors)
        {
            try
            {
                _context.DrivingInstructors.Update(UpdateInstructors);
                await _context.SaveChangesAsync();
                return UpdateInstructors;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Updating driving instructor: {ex.Message}");
                return null;
            }
        }
        public async Task<bool> DeleteInstructors(DrivingInstructors drivingInstructors)
        {
            try
            {
                _context.DrivingInstructors.Remove(drivingInstructors);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Deleting driving instructor: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> CheckUserDataExistance(InstructorRequest request)
        {
            return await _context.DrivingInstructors.AnyAsync(i => i.PhoneNumber == request.PhoneNumber||i.InstructorName==request.InstructorName);
        }
        public async Task<bool> CheckImgExistance(string ImageHash)
        {
            return await _context.DrivingInstructors.AnyAsync(i => i.ImageHash == ImageHash);
        }

    }
}
