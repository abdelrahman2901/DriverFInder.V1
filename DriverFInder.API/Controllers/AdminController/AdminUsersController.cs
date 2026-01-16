using DriverFinder.Core.Domain.EntitiesVIew;
using DriverFinder.Core.DTO.RegisterDTO;
using DriverFinder.Core.Identity;
using DriverFinder.Core.ServicesContracts.IUserDetailsServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DriverFinder.UI.Controllers.AdminController
{
    [Authorize(Roles ="Admin")]
    [Route("api/Admin/[controller]")]
    [ApiController]
    public class AdminUsersController : ControllerBase
    {
        private readonly IUserDetailsViewService _userViewService;
        private readonly UserManager<ApplicationUser> _userManager;
        public AdminUsersController(IUserDetailsViewService UserSerivce, UserManager<ApplicationUser> userManager)
        {
            _userViewService = UserSerivce;
            _userManager = userManager;
        } 

        [HttpPost]
        public async Task<ActionResult<UsersDetailsView>> AddModerator(UserRegisterRequest moderator)
        {

            if (!ModelState.IsValid)
            {
                var errors = string.Join("\n", ModelState.Values.SelectMany(s => s.Errors).Select(u => u.ErrorMessage));
                return Problem(errors);
            }
            ApplicationUser user = new ApplicationUser()
            {
                Id = Guid.NewGuid(),
                Email=moderator.Email,
                PersonName=moderator.PersonName,
                PhoneNumber=moderator.PhoneNumber,
                isblocked=false
            };

            await  _userManager.CreateAsync(user,moderator.Password);
            
            await _userManager.AddToRoleAsync(user,"Moderator");

            
            var userDetails = _userViewService.GetUserByID(user.Id);
            return Ok(userDetails);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersDetailsView>>> GetAllUsers()
        {
            var users = await _userViewService.GetAllUsers();
            if (!users.IsSuccess)
            {
                return Problem(users.ErrorMessage);
            }
            return Ok(users.Data);
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> EditUserBlockStatus(Guid id,bool status)
        {
            var result =await _userViewService.EditUserBlockStatus(id, status);
            if (!result.IsSuccess)
            {
                return Problem(result.ErrorMessage);
            }
            return Ok(result.Data);
        }

        [HttpPut("[action]/{id}")]
        public async Task<ActionResult<UsersDetailsView>> EditUserRole(Guid id,string UpdatedRole)
        {
            
            var result = await _userViewService.EditUserRole(id, UpdatedRole);
            if (!result.IsSuccess)
            {
                return Problem(result.ErrorMessage);
            }
            return Ok(result.Data);
        }
        
    }
}
