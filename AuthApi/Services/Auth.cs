using AuthApi.Datas;
using AuthApi.Models;
using AuthApi.Services.Dtos;
using AuthApi.Services.IAuthService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthApi.Services
{
    public class Auth : IAuth
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<ApplicationUser> userManager;

        public Auth(AppDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            this.userManager = userManager;
        }

        public async Task<object> Register(RegisterRequestDto registerRequestDto)
        {
            var user = new ApplicationUser
            {
                UserName = registerRequestDto.UserName,
                Email = registerRequestDto.Email,
                Birthdate = registerRequestDto.BirthDate
            };

            var result = await userManager.CreateAsync(user, registerRequestDto.Password);

            if (result.Succeeded)
            {
                var userReturn = await _dbContext.applicationUsers.FirstOrDefaultAsync(user => user.UserName == registerRequestDto.UserName);

                return new { result = userReturn, message = "Sikeres regisztráció." };
            }

            return new { result = "", message = result.Errors.FirstOrDefault().Description };
        }
    }
}
