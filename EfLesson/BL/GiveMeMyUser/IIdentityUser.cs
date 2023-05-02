using System;
using EfLesson.Models;

namespace EfLesson.BL
{
	public interface IIdentityUser
	{
        public Task<int> Create(UserModel model);
        public Task<int> LoginUser(string email, string password, bool rememberMe);
    }
}

