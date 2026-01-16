using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Domain.RepositoryContracts.ISchoolOwnerRepo;
using DriverFinder.Core.DTO.OwnerDTO;
using DriverFinder.Core.Identity;
using DriverFinder.Infrastructure.ApplicationContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DriverFinder.Infrastructure.Repository.SchoolOwnerRepo
{
    public class SchoolOwnerRepository : ISchoolOwnerRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<SchoolOwnerRepository> _logger;
        private readonly UserManager<ApplicationUser> _userManger;


        public SchoolOwnerRepository(ApplicationDBContext context,ILogger<SchoolOwnerRepository>logger,UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManger = userManager;
        }

        public async Task<IEnumerable<SchoolOwner>> GetSchoolOwners()
        {
            return await _context.SchoolOwners.AsNoTracking().ToListAsync();
        }

        public async Task<SchoolOwner?> GetSchoolOwner(Guid id)
        {
          return  await _context.SchoolOwners.AsNoTracking().Where(t=>t.OwnerID ==id).FirstOrDefaultAsync();
        }
        public async Task<SchoolOwner?> GetSchoolOwnerByUserID(Guid Userid)
        {
          return  await _context.SchoolOwners.AsNoTracking().Where(o=>o.UserID==Userid).FirstOrDefaultAsync();
        }

        public async Task<SchoolOwner?> AddSchoolOwner(SchoolOwner owner)
        {
            try
            {
                await _context.SchoolOwners.AddAsync(owner); 
                await _context.SaveChangesAsync();
                return owner;
            }
            catch(Exception ex)
            {
                _logger.LogError($"log from (SchoolOwnerRepository:AddSchoolOwner) : {ex.Message}");

                return null;
            }
        }

        public async Task<bool> DeleteOwner(SchoolOwner owner)
        {
            try
            {
                _context.Remove(owner);
                await _context.SaveChangesAsync();
                return true;
            }catch(Exception ex)
            {
                _logger.LogError($"log from (SchoolOwnerRepository:deleteOwner) : {ex.Message}");
                return false;
            }
            
        }
        public async Task<bool> ChangeRoles(OwnerResponse ownerResponse, string CurrentRole, string toRole)
        {
            var user = await _userManger.FindByIdAsync(ownerResponse.UserID.ToString());

            var result = await _userManger.RemoveFromRoleAsync(user, CurrentRole);
            if (!result.Succeeded)
            {
                return false;
            }
            await _userManger.AddToRoleAsync(user, toRole);
            return true;
        }
    }
}
