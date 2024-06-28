using Microsoft.AspNetCore.Mvc;
using Resunet.DAL.Models;
using Resunet.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace Resunet.BL.Auth
{
    public interface IAuthBL
    {
        Task<int> CreateUserAsync(UserModel user);

        Task<int> AuthenticateAsync(string email, string password,bool rememberMe);

        Task<ValidationResult?> ValidateEmailAsync(string email);
    }
}

