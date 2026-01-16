using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Domain.RepositoryContracts.ISchoolProgramsRepo;
using DriverFinder.Infrastructure.ApplicationContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace DriverFinder.Infrastructure.Repository.SchoolProgramsRepo
{
    public class SchoolProgramsRepository : ISchoolProgramsRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<SchoolProgramsRepository> _logger;
        public SchoolProgramsRepository(ApplicationDBContext context,ILogger<SchoolProgramsRepository>logger)
        {
            _context = context;
            _logger = logger; 
        }

        public async Task<IEnumerable<SchoolPrograms>> GetAllSchoolPrograms(Guid SchoolID)
        {
            return await _context.SchoolPrograms.AsNoTracking()
                .Where(sp => sp.SchoolID == SchoolID)
                .ToListAsync();
        }

        public async Task<IEnumerable<SchoolPrograms>> GetAllSchoolsPrograms()
        {
           return await _context.SchoolPrograms.AsNoTracking().ToListAsync();
        }

        public async Task<SchoolPrograms?> GetSchoolProgramByID(Guid ProgramID)
        {
            return await _context.SchoolPrograms.AsNoTracking()
               .Where(sp => sp.SchoolProgramID == ProgramID).FirstOrDefaultAsync();
        }
        public async Task<SchoolPrograms?> AddSchoolProgram(SchoolPrograms schoolProgram)
        {
            try
            {
                _context.SchoolPrograms.Add(schoolProgram);
                await _context.SaveChangesAsync();
                return schoolProgram;
            }
            catch(Exception ex)
            {
                _logger.LogError($"error adding school program (Error Message)  : {ex.Message}");
                _logger.LogError($"error adding school program (inner exception): {ex.InnerException}");
                return null;
            }
        }

        public async Task<bool> DeleteSchoolProgram(SchoolPrograms SchoolProgram)
        {
            try
            {
                _context.SchoolPrograms.Remove(SchoolProgram);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error deleting school program (Error Message)  : {ex.Message}");
                _logger.LogError($"error deleting school program (inner exception): {ex.InnerException}");
                return false;
            }
        }
        public async Task<SchoolPrograms?> UpdateSchoolProgram(SchoolPrograms UpdateschoolProgram)
        {
            try
            {
                _context.Entry(UpdateschoolProgram).State = EntityState.Modified;
                _context.SchoolPrograms.Update(UpdateschoolProgram);
                await _context.SaveChangesAsync();
                return UpdateschoolProgram;

            }
            catch(Exception ex)
            {
                _logger.LogError($"error deleting school program (Error Message)  : {ex.Message}");
                _logger.LogError($"error deleting school program (inner exception): {ex.InnerException}");
                return null;
            }
        }

      
    }
}
