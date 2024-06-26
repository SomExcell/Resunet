using Resunet.DAL.Models;
using System;

namespace Resunet.BL.Auth
{
    public interface IAuthBL
    {
        Task<int> CreateUserAsync(UserModel user);

        Task<int> AuthenticateAsync(string email, string password,bool rememberMe);
    }
}

