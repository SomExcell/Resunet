using System;
using Resunet.DAL.Models;
using Resunet.DAL;
using System.ComponentModel.DataAnnotations;

namespace Resunet.BL.Auth
{
    public class AuthBL : IAuthBL
    {
        private readonly IAuthDAL authDal;
        private readonly IEncrypt encrypt;
        private readonly IHttpContextAccessor httpContextAccessor;

        public AuthBL(IAuthDAL authDal, IEncrypt encrypt, IHttpContextAccessor httpContextAccessor)
        {
            this.authDal = authDal;
            this.encrypt = encrypt;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<int> CreateUserAsync(UserModel user)
        {
            user.Salt = Guid.NewGuid().ToString();
            user.Password = encrypt.HashPassword(user.Password, user.Salt);
            int id = await authDal.CreateUserAsync(user);
            Login(id);
            return id;
        }

        public async Task<int> AuthenticateAsync(string email, string password, bool rememberMe)
        {
            var user = await authDal.GetUserAsync(email);
            if (user.UserId != null && user.Password == encrypt.HashPassword(password, user.Salt))
            {
                Login(user.UserId!.Value);
                return user.UserId!.Value;
            }
            throw new AuthorizationException();
        }

        public void Login(int id)
        {
            httpContextAccessor.HttpContext?.Session.SetInt32(AuthConstants.AUTH_SESSION_PARAM_NAME,id);
        }

        public async Task<ValidationResult?> ValidateEmailAsync(string email)
        {
            var user = await authDal.GetUserAsync(email);
            if (user.UserId != null)
                return new ValidationResult("Данный email уже зарегистрирован");
            return null;

        }
        
    }
}

