using DriverFinder.Core.Domain.Entites;
using DriverFinder.Infrastructure.ApplicationContext;
using DriverFinder.Core.Domain.RepositoryContracts.IProgramRepo;
using Microsoft.EntityFrameworkCore;
using System;

namespace DriverFinder.Infrastructure.Repository.ProgramRepo
{
    public class ProgramRepository : IProgramRepository
    {
        private readonly ApplicationDBContext _context;
       public ProgramRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Programs>> GetDrivingPrograms()
        {
            return await _context.DrivingProgram.AsNoTracking().ToListAsync();
        }

        public async Task<Programs> AddDrivingProgram(Programs? newprogram)
        {
            
            await _context.DrivingProgram.AddAsync(newprogram);
            try
            {

            await _context.SaveChangesAsync();
            }catch(Exception ex)
            {
               
                throw;
            }

            return newprogram;
        }

        public async Task<Programs?> GetDrivingProgram(Guid id)
        {
            return await _context.DrivingProgram.AsNoTracking().FirstOrDefaultAsync(o=>o.ProgramID==id);
        }
    }
}
