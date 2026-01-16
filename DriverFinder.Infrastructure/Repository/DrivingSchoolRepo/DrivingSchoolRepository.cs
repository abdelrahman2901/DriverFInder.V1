using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Domain.RepositoryContracts.IDrivingSchoolRepo;
using DriverFinder.Infrastructure.ApplicationContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace DriverFinder.Infrastructure.Repository.DrivingSchoolRepo
{
    public class DrivingSchoolRepository : IDrivingSchoolRepository
    {
        private readonly ApplicationDBContext _context; 
        private readonly ILogger<DrivingSchoolRepository> _logger;
        public DrivingSchoolRepository(ApplicationDBContext context, ILogger<DrivingSchoolRepository> logger)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IEnumerable<DrivingSchool>> GetDrivingSchools()
        {
            try
            {
                var schools = await _context.DrivingSchools.AsNoTracking().ToListAsync();
                return schools;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error from (DrivingSchoolRepository:GetDrivingSchools) {ex.Message}");
                return Enumerable.Empty<DrivingSchool>();
            }
        }


        public async Task<DrivingSchool?> AddDrivingSchool(DrivingSchool drivingSchool)
        {
            try
            {
                await _context.DrivingSchools.AddAsync(drivingSchool);
                await _context.SaveChangesAsync();
                return drivingSchool;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error from (DrivingSchoolRepository:AddDrivingSchool) {ex.Message}");
                _logger.LogError($"error from (DrivingSchoolRepository:AddDrivingSchool) : EF ERROR: {ex.InnerException?.Message}");
                return null;
            }
        }

        public async Task<DrivingSchool?> GetDrivingSchoolByID(Guid id)
        {
            try
            {
                DrivingSchool? school = await _context.DrivingSchools.AsNoTracking().Where(t => t.SchoolID == id).FirstOrDefaultAsync();
                return school;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error from (DrivingSchoolRepository:GetDrivingSchoolByID) {ex.Message}");
                return null;
            }
        }

        public async Task<DrivingSchool?> UpdateDrivingSchool(DrivingSchool drivingSchool)
        {
            try
            {
                _context.Entry(drivingSchool).State = EntityState.Modified;
                _context.DrivingSchools.Update(drivingSchool);

                await _context.SaveChangesAsync();
                return drivingSchool;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error from (DrivingSchoolRepository:GetDrivingSchoolByID) {ex.Message}");
                return null;
            }
        }

        public async Task<bool> DeleteDrivingSchool(DrivingSchool School)
        {
            try
            {
                _context.DrivingSchools.Remove(School);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error from (DrivingSchoolRepository:DeleteDrivingSchool) {ex.Message}");
                return false;
            }
        }

         public async Task<bool> isSchoolNameExists(string schoolName)
        {
            return await _context.DrivingSchools.AsNoTracking().Where(s => s.SchoolName == schoolName).FirstOrDefaultAsync() != null;
        }
        

    }
}
