﻿using System;

namespace Resunet.BL.Auth
{
    public interface IAuthBL
    {
        Task<int> CreateUser(Resunet.DAL.Models.UserModel user);
    }
}

