using System;
using EfLesson.Models;

namespace EfLesson.BL
{
	public interface IIdentityUser
	{
       public void Create(UserModel model);
       public int LoginUser(string email, string password, bool rememberMe);
    }
}

