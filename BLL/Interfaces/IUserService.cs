﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> Register(UserRegistrationModel model);

        Task<SignInResult> Login(UserLoginModel model);

        Task SignOut();
    }
}