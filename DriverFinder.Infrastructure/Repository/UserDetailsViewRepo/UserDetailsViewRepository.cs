using DriverFinder.Core.Domain.EntitiesVIew;
using DriverFinder.Core.Domain.RepositoryContracts.IUserDetailsViewRepo;
using DriverFinder.Core.Identity;
using DriverFinder.Infrastructure.ApplicationContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace DriverFinder.Infrastructure.Repository.UserDetailsViewRepo
{
    public class UserDetailsViewRepository : IUserDetailsViewRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserDetailsViewRepository(ApplicationDBContext context, UserManager<ApplicationUser> usermanager)
        {
            _context = context;
            _userManager = usermanager;
        } 
        public async Task<IEnumerable<UsersDetailsView>> GetAllUsers()
        {
            try
            {
                var users=await _context.UsersDetailsView.AsNoTracking().ToListAsync();
            return users;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex);
                Console.WriteLine(ex.StackTrace);
                
                throw ;
            }
        }
        
        public async Task<bool> EditUserRole(ApplicationUser user,string UpdateRole)
        {
            string? oldRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault();

           try{
            await _userManager.RemoveFromRoleAsync(user, oldRole);
            await _userManager.AddToRoleAsync(user, UpdateRole);
            await _context.SaveChangesAsync();
                return true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        public async Task<bool> EditUserBlockStatus(ApplicationUser user)
        {
            try
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

        }

        public async Task<UsersDetailsView?> GetUserByID(Guid UserID)
        {
            return await _context.UsersDetailsView.Where(u => u.userID == UserID).FirstOrDefaultAsync();
        }
        public async Task<ApplicationUser?> GetUserEntityByID(Guid UserID)
        {
            return await _context.Users.Where(u => u.Id == UserID).FirstOrDefaultAsync();
        }

    }
}