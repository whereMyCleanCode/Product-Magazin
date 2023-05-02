using System;
using EfLesson.Models;

namespace EfLesson.BL.GiveMeMyUser
{
    public class IdentityUser : IIdentityUser
    {

        private readonly IHttpContextAccessor _httpContex;

        public Task<int> Create(UserModel model)
        {

        }

        public Task<int> LoginUser(string email, string password, bool rememberMe)
        {

        }
    }
}

