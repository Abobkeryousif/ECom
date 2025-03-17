using Ecom.Core.DTO;
using Ecom.Core.Entities;
using Ecom.Core.Interface;
using Ecom.Core.Services;
using Microsoft.AspNetCore.Identity;

namespace Ecom.Infrstrucure.Repositories
{
    public class AuthRepository : IAuth
    {
        private readonly UserManager<UserApp> _manager;
        private readonly IGenretToken _token;
        private readonly SignInManager<UserApp> _signInManager;
        

        public AuthRepository(UserManager<UserApp> manager, SignInManager<UserApp> signInManager , IGenretToken token)
        {
            _manager = manager;
            _signInManager = signInManager;
            _token = token;
            
        }

        public async Task<string> RegisterAsync(RegisterDto register)
        {
            if (register is null)
            {
                return null;
            }
            if (await _manager.FindByNameAsync(register.UserName) is not null && await _manager.FindByEmailAsync(register.Email) is not null)
            {
                return "This User Already Register!";
            }

            UserApp user = new UserApp()
            {
                UserName = register.UserName,
                Email = register.Email,
                DisplayName = register.DisplayName
            };
            var result = await _manager.CreateAsync(user,register.Password);
            if (result.Succeeded is not true)
            {
                return result.Errors.ToList()[0].Description;
            }
            //Send Active Email
            return $"Register Complete! Go To Login MR: {user.UserName}";
        }
        public async Task<string> LoginAsync(LoginDto login)
        {
            if (login == null)
            {
                return null;
            }

            var FindUser = await _manager.FindByEmailAsync(login.Email);
            if (FindUser is null)
            {
                return "Email Or Password Incorrrect";
            }
            var result = await _signInManager.CheckPasswordSignInAsync(FindUser, login.Password, true);
            if (result.Succeeded) 
            {
                return _token.CreateToken(FindUser);
            }

            return "Email or Password Incorrect";

        }

    }
}







