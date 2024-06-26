using System;
using Resunet.DAL.Models;

namespace Resunet.DAL
{
    public interface IAuthDAL
    {
        Task<UserModel> GetUserAsync(string email);
        Task<UserModel> GetUserAsync(int id);
        Task<int> CreateUserAsync(UserModel model);
    }
}

