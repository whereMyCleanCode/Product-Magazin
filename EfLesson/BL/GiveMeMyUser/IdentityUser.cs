using System;
using EfLesson.Models;
using EfLesson.DAL;
using EfLesson.Models;
using EfLesson.BL.Crypto;

namespace EfLesson.BL.GiveMeMyUser
{
    public class IdentityUser : IIdentityUser
    {
        private ProductDb _dbContext;
        private readonly IHttpContextAccessor _httpContex;
        private ICrypto _crypto;

        public IdentityUser(ProductDb dbContext,IHttpContextAccessor httpContext, ICrypto crypto)
        {
            _dbContext = dbContext;
            _httpContex = httpContext;
            _crypto = crypto;
        }

        public void Create(UserModel model)
        {
            if (model != null)
            {
                if(model.Password != null)
                {
                    model.Salt =  Guid.NewGuid().ToString();
                    model.Password = _crypto.HashPassword(model.Password, model.Salt);
                }
                _dbContext.Add<UserModel>(new UserModel
                {
                    Password = model.Password,
                    Email = model.Email,
                    Salt = model.Salt,
                    Name = model.Name,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber,

                });
            }

        }

        public int LoginUser(string email, string password, bool rememberMe)
        {

            IEnumerable<UserModel> user =  _dbContext.Users
                              .Where(p => _crypto
                              .HashPassword(p.Password, p.Salt) == password);

            if (user != null)
            {
                foreach (UserModel u in user)
                {
                    if (u.Id != 0)
                        return u.Id;
                }
                return 0;
            }
            else
                throw new Exception("fuck");
                     
        }
    }
}

