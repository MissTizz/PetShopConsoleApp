using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop.Core.DomainService;
using PetShop.Core.Entities;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        readonly PetShopAppContext _ctx;

        public UserRepository(PetShopAppContext ctx)
        {
            _ctx = ctx;
        }

        public User GetUser(string username)
        {
            return _ctx.Users.
                FirstOrDefault(user => user.UserName.ToLower().Equals(username.ToLower()));
        }
    }
}
