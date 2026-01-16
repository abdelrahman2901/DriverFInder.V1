using DriverFinder.Core.Domain.Entites;
using DriverFinder.Infrastructure.ApplicationContext;
using DriverFinder.Core.Domain.RepositoryContracts.ProgramTypesRepo;
using Microsoft.EntityFrameworkCore;
using System;


namespace DriverFinder.Infrastructure.Repository.ProgramTypesRepo
{
    public class ProgramTypesRepository : IProgramTypesRepository
    {
        private readonly ApplicationDBContext _context;
        public ProgramTypesRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProgramTypes>> GetProgramTypes()
        {
            return await _context.ProgramTypes.AsNoTracking().ToListAsync();
        }

        public async Task<ProgramTypes?> GetProgramTypes(Guid id)
        {
            return await _context.ProgramTypes.AsNoTracking().FirstOrDefaultAsync(o=>o.ProgramTypeID==id);
        }

        public async Task<ProgramTypes?> AddProgramType(ProgramTypes programType)
        {

            await _context.ProgramTypes.AddAsync(programType);
            try
            {
            await _context.SaveChangesAsync();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return programType;
        }



    }
}
