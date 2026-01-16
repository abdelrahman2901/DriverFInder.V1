using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Domain.RepositoryContracts.IUserActivityRepo;
using DriverFinder.Core.DTO.UserActivityDTO;
using DriverFinder.Infrastructure.ApplicationContext;
using System;


namespace DriverFinder.Infrastructure.Repository.UserActivityRepo
{
    public class UserActivityRepository : IUserActivityRepository
    {
        private readonly ApplicationDBContext _context;

        public UserActivityRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<bool> LogUserActivity(UserActivity activity)
        {
            try
            {
             await _context.UserActivity.AddAsync(activity);
             await   _context.SaveChangesAsync();
                return true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public  UserActivityCountDTO GetUserActiviyCounts()
        {
            var Today = DateTime.Today;
         var daily= _context.UserActivity.Where(ua=>ua.Timestamp.Date==Today).Count();

         var Weakly= _context.UserActivity.Where(ua=>ua.Timestamp.Date>=DateTime.Now.AddDays(-7)&&ua.Timestamp.Date<=Today).Count();
            
         var MonthlyDate = new DateTime(Today.Year, Today.Month, 1);
         var Monthly= _context.UserActivity.Where(ua=>ua.Timestamp.Date>=MonthlyDate &&ua.Timestamp.Date<=Today).Count();

            var YearlyDate= new DateTime(Today.Year, 1, 1);

            var Annual = _context.UserActivity.Where(ua => ua.Timestamp >= YearlyDate && ua.Timestamp <= Today).Count();

            var NewUsers = _context.UserActivity.Where(ua => ua.LogType == "Register" &&ua.Timestamp.Date==Today).Count();
            var blockedUsers = _context.Users.Where(u => u.isblocked ==true).Count();

            return new UserActivityCountDTO() { Daily = daily, Weakly = Weakly, Monthly = Monthly ,Annual=Annual,NewUsers=NewUsers,blockedUsers=blockedUsers};
        }

    }
}
